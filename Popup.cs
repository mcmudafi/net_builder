using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace net_builder
{
    public partial class Popup : Form
    {
        private const char StepCharacter = '.';
        private const int MaxStep = 5;
        private int step = 0;
        private string text = string.Empty;
        
        public Popup()
        {
            InitializeComponent();

            new Timer(_ =>
            {
                if (!Visible || string.IsNullOrWhiteSpace(text)) return;
                
                void _setText()
                {
                    step++;
                    step %= MaxStep;

                    label.Text = text + new string(StepCharacter, step);
                }

                if (label.InvokeRequired) label.Invoke((MethodInvoker)delegate { _setText(); });
                else _setText();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        public void SetText(string text)
        {
            step = 0;
            this.text = text.Trim();
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["MainForm"];
            Location = new Point(
                mainForm.Location.X + (mainForm.Size.Width - Size.Width) / 2,
                mainForm.Location.Y + (mainForm.Size.Height - Size.Height) / 2
            );
        }
    }
}
