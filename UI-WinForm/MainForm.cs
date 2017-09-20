using ChatGame.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_WinForm
{
    public partial class MainForm : Form
    {
        private int MaxLines;

        public MainForm()
        {
            InitializeComponent();
            InitializeValues();
            MainProgram();
        }

        private void InitializeValues()
        {
            MaxLines = 2;
        }

        private async void MainProgram()
        {
            await AppendLine($"{Resources.Welcome} {Resources.GameTitle} {Resources.Version} {Resources.VersionId}",
                MainTxtBx);
            await AppendLine(new string('-',
                Resources.Welcome.Length
                + Resources.GameTitle.Length
                + Resources.Version.Length
                + Resources.VersionId.Length
                + 3),
                MainTxtBx);
            await AppendLine(Resources.Disclaimer, MainTxtBx);
        }

        private Task AppendLine(string newString, TextBox txtBx)
        {
            return Task.Run(() =>
            {
                while (!txtBx.IsHandleCreated)
                {
                    Task.Delay(100);
                }

                if (txtBx.Text.Length < 1)
                {
                    txtBx.Invoke(new Action(() => txtBx.Text = newString));
                }
                else if (txtBx.Text.Length < MaxLines)
                {
                    txtBx.Invoke(new Action(() => txtBx.AppendText($"\r\n{newString}")));
                }
                else
                {
                    txtBx.Invoke(new Action(() =>
                    {
                        //first add the new line at the end
                        txtBx.AppendText($"\r\n{newString}");

                        //remove the first line
                        txtBx.Text.Remove(0, txtBx.Text.IndexOf('\n', 0) + 1);
                    }));
                }
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
