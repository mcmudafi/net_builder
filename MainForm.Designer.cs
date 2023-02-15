namespace net_builder;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectPath = new System.Windows.Forms.TextBox();
            this.btnOpenProject = new System.Windows.Forms.Button();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpProjectInfo = new System.Windows.Forms.GroupBox();
            this.lblProjecteVersion = new System.Windows.Forms.Label();
            this.lblProjectFramework = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBuildInfo = new System.Windows.Forms.GroupBox();
            this.chkTrimmed = new System.Windows.Forms.CheckBox();
            this.chkAsSingleFile = new System.Windows.Forms.CheckBox();
            this.lblBuildCommand = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSelfContained = new System.Windows.Forms.CheckBox();
            this.chkForceRestore = new System.Windows.Forms.CheckBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnOpenOutput = new System.Windows.Forms.Button();
            this.btnOpenLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            this.grpProjectInfo.SuspendLayout();
            this.grpBuildInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project path";
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectPath.Location = new System.Drawing.Point(89, 12);
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(245, 23);
            this.txtProjectPath.TabIndex = 1;
            this.txtProjectPath.Leave += new System.EventHandler(this.txtProjectPath_Leave);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenProject.Location = new System.Drawing.Point(340, 12);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(75, 23);
            this.btnOpenProject.TabIndex = 2;
            this.btnOpenProject.Text = "Open";
            this.btnOpenProject.UseVisualStyleBackColor = true;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // dgvParameters
            // 
            this.dgvParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.dgvParameters.Location = new System.Drawing.Point(12, 41);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowHeadersVisible = false;
            this.dgvParameters.RowTemplate.Height = 25;
            this.dgvParameters.Size = new System.Drawing.Size(403, 429);
            this.dgvParameters.TabIndex = 3;
            this.dgvParameters.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParameters_CellEndEdit);
            this.dgvParameters.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvParameters_EditingControlShowing);
            this.dgvParameters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvParameters_KeyDown);
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.Width = 150;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // grpProjectInfo
            // 
            this.grpProjectInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProjectInfo.Controls.Add(this.lblProjecteVersion);
            this.grpProjectInfo.Controls.Add(this.lblProjectFramework);
            this.grpProjectInfo.Controls.Add(this.lblProjectName);
            this.grpProjectInfo.Controls.Add(this.label4);
            this.grpProjectInfo.Controls.Add(this.label3);
            this.grpProjectInfo.Controls.Add(this.label2);
            this.grpProjectInfo.Location = new System.Drawing.Point(421, 12);
            this.grpProjectInfo.Name = "grpProjectInfo";
            this.grpProjectInfo.Size = new System.Drawing.Size(198, 108);
            this.grpProjectInfo.TabIndex = 4;
            this.grpProjectInfo.TabStop = false;
            this.grpProjectInfo.Text = "Project info";
            // 
            // lblProjecteVersion
            // 
            this.lblProjecteVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjecteVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProjecteVersion.Location = new System.Drawing.Point(80, 77);
            this.lblProjecteVersion.Margin = new System.Windows.Forms.Padding(3);
            this.lblProjecteVersion.Name = "lblProjecteVersion";
            this.lblProjecteVersion.Size = new System.Drawing.Size(112, 20);
            this.lblProjecteVersion.TabIndex = 10;
            // 
            // lblProjectFramework
            // 
            this.lblProjectFramework.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjectFramework.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProjectFramework.Location = new System.Drawing.Point(80, 51);
            this.lblProjectFramework.Margin = new System.Windows.Forms.Padding(3);
            this.lblProjectFramework.Name = "lblProjectFramework";
            this.lblProjectFramework.Size = new System.Drawing.Size(112, 20);
            this.lblProjectFramework.TabIndex = 9;
            // 
            // lblProjectName
            // 
            this.lblProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjectName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProjectName.Location = new System.Drawing.Point(80, 25);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(3);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(112, 20);
            this.lblProjectName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Framework";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // grpBuildInfo
            // 
            this.grpBuildInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBuildInfo.Controls.Add(this.chkTrimmed);
            this.grpBuildInfo.Controls.Add(this.chkAsSingleFile);
            this.grpBuildInfo.Controls.Add(this.lblBuildCommand);
            this.grpBuildInfo.Controls.Add(this.label6);
            this.grpBuildInfo.Controls.Add(this.chkSelfContained);
            this.grpBuildInfo.Controls.Add(this.chkForceRestore);
            this.grpBuildInfo.Location = new System.Drawing.Point(421, 126);
            this.grpBuildInfo.Name = "grpBuildInfo";
            this.grpBuildInfo.Size = new System.Drawing.Size(350, 344);
            this.grpBuildInfo.TabIndex = 5;
            this.grpBuildInfo.TabStop = false;
            this.grpBuildInfo.Text = "Build info";
            // 
            // chkTrimmed
            // 
            this.chkTrimmed.AutoSize = true;
            this.chkTrimmed.Location = new System.Drawing.Point(180, 47);
            this.chkTrimmed.Name = "chkTrimmed";
            this.chkTrimmed.Size = new System.Drawing.Size(73, 19);
            this.chkTrimmed.TabIndex = 12;
            this.chkTrimmed.Text = "Trimmed";
            this.chkTrimmed.UseVisualStyleBackColor = true;
            this.chkTrimmed.CheckedChanged += new System.EventHandler(this.buildCheckbox_CheckedChanged);
            // 
            // chkAsSingleFile
            // 
            this.chkAsSingleFile.AutoSize = true;
            this.chkAsSingleFile.Location = new System.Drawing.Point(180, 22);
            this.chkAsSingleFile.Name = "chkAsSingleFile";
            this.chkAsSingleFile.Size = new System.Drawing.Size(92, 19);
            this.chkAsSingleFile.TabIndex = 11;
            this.chkAsSingleFile.Text = "As single file";
            this.chkAsSingleFile.UseVisualStyleBackColor = true;
            this.chkAsSingleFile.CheckedChanged += new System.EventHandler(this.buildCheckbox_CheckedChanged);
            // 
            // lblBuildCommand
            // 
            this.lblBuildCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuildCommand.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBuildCommand.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBuildCommand.Location = new System.Drawing.Point(8, 90);
            this.lblBuildCommand.Margin = new System.Windows.Forms.Padding(3);
            this.lblBuildCommand.Name = "lblBuildCommand";
            this.lblBuildCommand.Size = new System.Drawing.Size(336, 248);
            this.lblBuildCommand.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Command";
            // 
            // chkSelfContained
            // 
            this.chkSelfContained.AutoSize = true;
            this.chkSelfContained.Location = new System.Drawing.Point(8, 47);
            this.chkSelfContained.Name = "chkSelfContained";
            this.chkSelfContained.Size = new System.Drawing.Size(103, 19);
            this.chkSelfContained.TabIndex = 1;
            this.chkSelfContained.Text = "Self-contained";
            this.chkSelfContained.UseVisualStyleBackColor = true;
            this.chkSelfContained.CheckedChanged += new System.EventHandler(this.buildCheckbox_CheckedChanged);
            // 
            // chkForceRestore
            // 
            this.chkForceRestore.AutoSize = true;
            this.chkForceRestore.Location = new System.Drawing.Point(8, 22);
            this.chkForceRestore.Name = "chkForceRestore";
            this.chkForceRestore.Size = new System.Drawing.Size(94, 19);
            this.chkForceRestore.TabIndex = 0;
            this.chkForceRestore.Text = "Force restore";
            this.chkForceRestore.UseVisualStyleBackColor = true;
            this.chkForceRestore.CheckedChanged += new System.EventHandler(this.buildCheckbox_CheckedChanged);
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuild.Location = new System.Drawing.Point(625, 48);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(146, 72);
            this.btnBuild.TabIndex = 6;
            this.btnBuild.Text = "BUILD";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // btnOpenOutput
            // 
            this.btnOpenOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenOutput.Location = new System.Drawing.Point(701, 12);
            this.btnOpenOutput.Name = "btnOpenOutput";
            this.btnOpenOutput.Size = new System.Drawing.Size(70, 30);
            this.btnOpenOutput.TabIndex = 7;
            this.btnOpenOutput.Text = "Output";
            this.btnOpenOutput.UseVisualStyleBackColor = true;
            this.btnOpenOutput.Click += new System.EventHandler(this.btnOpenOutput_Click);
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenLog.Location = new System.Drawing.Point(625, 12);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(70, 30);
            this.btnOpenLog.TabIndex = 8;
            this.btnOpenLog.Text = "Log";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 482);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.btnOpenOutput);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.grpBuildInfo);
            this.Controls.Add(this.grpProjectInfo);
            this.Controls.Add(this.dgvParameters);
            this.Controls.Add(this.btnOpenProject);
            this.Controls.Add(this.txtProjectPath);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = ".NET Core project builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            this.grpProjectInfo.ResumeLayout(false);
            this.grpProjectInfo.PerformLayout();
            this.grpBuildInfo.ResumeLayout(false);
            this.grpBuildInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label label1;
    private TextBox txtProjectPath;
    private Button btnOpenProject;
    private DataGridView dgvParameters;
    private GroupBox grpProjectInfo;
    private Label label4;
    private Label label3;
    private Label label2;
    private DataGridViewTextBoxColumn Key;
    private DataGridViewTextBoxColumn Value;
    private Label lblProjecteVersion;
    private Label lblProjectFramework;
    private Label lblProjectName;
    private GroupBox grpBuildInfo;
    private Label lblBuildCommand;
    private Label label6;
    private CheckBox chkSelfContained;
    private CheckBox chkForceRestore;
    private Button btnBuild;
    private Button btnOpenOutput;
    private Button btnOpenLog;
    private CheckBox chkTrimmed;
    private CheckBox chkAsSingleFile;
}