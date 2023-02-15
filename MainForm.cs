using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.Build.Construction;

namespace net_builder;

public partial class MainForm : Form
{
    #region Private classes
    
    class Config
    {
        public List<Parameter> CommonParameters { get; set; }

        public Config()
        {
            CommonParameters = new List<Parameter>();
        }
    }

    class Parameter
    {
        public string Key { get; set; }
        public List<string> CommonValues { get; set; }

        public Parameter()
        {
            Key = string.Empty;
            CommonValues = new List<string>();
        }
    }
    
    #endregion
    
    #region Constants
    
    private const string App7Zip = @"C:\Program Files\7-Zip\7z.exe";
    private const string AppCommandPrompt = "cmd.exe";
    private const string AppExplorer = "explorer.exe";
    private const string AppNotepad = "notepad.exe";
    private const string BuildLogFilePath = "buildLog.txt";
    private const string BuildResultPath = "build_result";
    private const string ConfigJsonFile = "config.json";
    private const string OutputPath = "output";
    private const string ProjectFilesFilter = "C# Project|*.csproj|All Files|*.*";
    private const string RuntimeLinux = "linux-x64";
    private const string RuntimeWindows = "win-x64";

    #endregion
    
    #region Fields

    private Config config;
    private Popup popup;
    private Thread popupThread;
    
    #endregion

    #region Constructor

    public MainForm()
    {
        InitializeComponent();
        LoadConfig();

        popup = new Popup();
    }

    private void LoadConfig()
    {
        if (File.Exists(ConfigJsonFile))
        {
            config = JsonSerializer.Deserialize<Config>(File.ReadAllText(ConfigJsonFile));
        }
        else
        {
            config = new Config();
            config.CommonParameters.Add(new Parameter
            {
                Key = "APP_MODE",
                CommonValues = { "DEVELOPMENT", "STAGING", "DEMO", "LIVE" }
            });
            config.CommonParameters.Add(new Parameter
            {
                Key = "AS_WINDOWS_SERVICE",
                CommonValues = { "TRUE", "FALSE" }
            });
        }
    }

    #endregion
    
    #region Control events

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        File.WriteAllText(ConfigJsonFile, JsonSerializer.Serialize(config));
    }

    private void btnOpenProject_Click(object sender, EventArgs e)
    {
        using OpenFileDialog fileDialog = new OpenFileDialog();
        fileDialog.Filter = ProjectFilesFilter;

        if (fileDialog.ShowDialog() == DialogResult.OK)
        {
            txtProjectPath.Text = fileDialog.FileName;
            ParseProjectFile();
        }
    }

    private void btnOpenOutput_Click(object sender, EventArgs e)
    {
        if (Directory.Exists(OutputPath))
        {
            Process.Start(AppExplorer, OutputPath);
        }
        else
        {
            MessageBox.Show($"Path {OutputPath} not exists. No builds have been ran.");
        }
    }

    private void btnOpenLog_Click(object sender, EventArgs e)
    {
        Process.Start(AppNotepad, BuildLogFilePath);
    }

    private void btnBuild_Click(object sender, EventArgs e)
    {
        if (!ValidateParameters()) return;

        UpdateCommonParameters();
        DeleteOutputDirectory();

        OpenPopup();

        string version = lblProjecteVersion.Text.Contains(' ') ?
            lblProjecteVersion.Text.Substring(0, lblProjecteVersion.Text.LastIndexOf(' ')) :
            lblProjecteVersion.Text;
        foreach (string runtime in new [] { RuntimeWindows, RuntimeLinux })
        {
            if (!RunBuildProcess(runtime))
            {
                ClosePopup();
                MessageBox.Show($"Build error, see {BuildLogFilePath} for more details.");
                
                return;
            }

            CompressBuildResult(version, runtime);

            Directory.Delete(Path.Join(OutputPath, BuildResultPath), true);
        }

        ClosePopup();
        MessageBox.Show("Build completed.");
    }

    private void buildCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        UpdateBuildCommand();
    }

    private void txtProjectPath_Leave(object sender, EventArgs e)
    {
        ParseProjectFile();
    }

    private void dgvParameters_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        UpdateBuildCommand();
    }

    private void dgvParameters_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            if (dgvParameters.Rows.Count > 0 && dgvParameters.SelectedCells.Count > 0)
            {
                dgvParameters.Rows.RemoveAt(dgvParameters.SelectedCells[0].RowIndex);
            }
        }
    }

    private void dgvParameters_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        AutoCompleteStringCollection strings = new AutoCompleteStringCollection();

        DataGridViewCell cell = dgvParameters.SelectedCells[0]; 
        if (cell.ColumnIndex == 0)
        {
            strings.AddRange(config.CommonParameters.Select(p => p.Key).ToArray());
        }
        else
        {
            string key = dgvParameters.Rows[cell.RowIndex].Cells[0].Value.ToString();
            Parameter parameter = config.CommonParameters.FirstOrDefault(p => p.Key.Equals(key));
            if (parameter != null)
            {
                strings.AddRange(parameter.CommonValues.ToArray());
            }
        }
            
        TextBox textBox = (DataGridViewTextBoxEditingControl)e.Control;
        textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        textBox.AutoCompleteCustomSource = strings;
    }
    
    #endregion
    
    #region Popup

    private void OpenPopup()
    {
        if (popup.IsDisposed) popup = new Popup();
        
        popupThread = new Thread(() => { popup.ShowDialog(); });
        popupThread.SetApartmentState(ApartmentState.STA);
        popupThread.Start();
    }

    private void ClosePopup()
    {
        popup.Invoke((MethodInvoker)delegate { popup.Close(); });
        Focus();
    }
    
    #endregion
    
    #region Build process

    private bool ValidateParameters()
    {
        foreach (DataGridViewRow row in dgvParameters.Rows)
        {
            if (row.IsNewRow) continue;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    MessageBox.Show("Empty parameter key/value is not allowed.");
                    return false;
                }
            }
        }

        return true;
    }

    private void UpdateCommonParameters()
    {
        foreach (DataGridViewRow row in dgvParameters.Rows)
        {
            if (row.IsNewRow) continue;

            string key = row.Cells[0].Value.ToString();
            string value = row.Cells[1].Value.ToString();

            if (!config.CommonParameters.Any(p => p.Key.Equals(key)))
            {
                config.CommonParameters.Add(new Parameter { Key = key });
            }

            Parameter parameter = config.CommonParameters.First(p => p.Key.Equals(key));
            if (!parameter.CommonValues.Any(v => v.Equals(value)))
            {
                parameter.CommonValues.Add(value);
            }
        }
    }

    private static void DeleteOutputDirectory()
    {
        if (Directory.Exists(OutputPath))
        {
            MessageBox.Show($"{OutputPath} is not empty. It'll be deleted before the build process.");
            Directory.Delete(OutputPath, true);
        }

        if (File.Exists(BuildLogFilePath))
        {
            File.Delete(BuildLogFilePath);
        }
    }

    private bool RunBuildProcess(string runtime)
    {
        popup.SetText($"Building for {runtime} runtime");
        
        StringBuilder output = new StringBuilder();
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo(AppCommandPrompt, "/c " + ConstructBuildCommand(runtime))
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            }
        };
        process.OutputDataReceived += (_, outputData) =>
        {
            if (outputData.Data != null)
            {
                output.AppendLine(outputData.Data.TrimEnd());
            }
        };
        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            File.WriteAllTextAsync(BuildLogFilePath, output.ToString());
            return false;
        }

        return true;
    }

    private void CompressBuildResult(string version, string runtime)
    {
        popup.SetText($"Compressing for {runtime} runtime");
        
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo(App7Zip, $"a -m0=lzma -mx=9 \"..\\{lblProjectName.Text}_{version}_{runtime}.zip\" .")
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WorkingDirectory = Path.Join(OutputPath, BuildResultPath)
            }
        };
        process.Start();
        process.WaitForExit();
    }
    
    #endregion
    
    #region Project and Build info

    private void ParseProjectFile()
    {
        txtProjectPath.Text = txtProjectPath.Text.Trim();
        if (string.IsNullOrWhiteSpace(txtProjectPath.Text)) return;
        if (!File.Exists(txtProjectPath.Text))
        {
            MessageBox.Show($"File \"{txtProjectPath.Text}\" not found.");
            return;
        }

        ProjectRootElement project = ProjectRootElement.Open(txtProjectPath.Text);
        string fileName = Path.GetFileName(txtProjectPath.Text);
        string name = fileName.Substring(0, fileName.LastIndexOf('.'));
        string framework = project.Properties.First(p => p.Name.Equals("TargetFramework")).Value;
        string version = "1.0.0 (default)";
        
        ProjectPropertyElement versionElement;
        if ((versionElement = project.Properties.FirstOrDefault(p => p.Name.Equals("Version"))) != null)
        {
            version = versionElement.Value;
        }

        lblProjectName.Text = name.Trim();
        lblProjectFramework.Text = framework.Trim();
        lblProjecteVersion.Text = version.Trim();
        
        UpdateBuildCommand();
    }

    private string ConstructBuildCommand(string runtime)
    {
        StringBuilder cmd = new StringBuilder("dotnet publish");
        cmd.Append($" \"{txtProjectPath.Text}\"");
        cmd.Append($" --output \"{Path.Join(OutputPath, BuildResultPath)}\"");
        cmd.Append($" --runtime {runtime}");
        cmd.Append($" --self-contained {(chkSelfContained.Checked ? "true" : "false")}");
        cmd.Append(" --configuration Release");
        
        if (chkForceRestore.Checked) cmd.Append(" --force");
        if (chkAsSingleFile.Checked) cmd.Append(" -p:PublishSingleFile=true");
        if (chkTrimmed.Checked) cmd.Append(" -p:PublishTrimmed=true");

        foreach (DataGridViewRow row in dgvParameters.Rows)
        {
            if (row.IsNewRow) continue;
            cmd.Append($" -p:{row.Cells[0].Value}={row.Cells[1].Value}");
        }

        return cmd.ToString();
    }

    private void UpdateBuildCommand()
    {
        string text = $"{ConstructBuildCommand(RuntimeWindows)}\n\n{ConstructBuildCommand(RuntimeLinux)}";
        lblBuildCommand.Text = text;
    }

    #endregion
}