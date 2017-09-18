using ChatGame.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_WinForm
{
    public partial class MainForm : Form
    {
        private int TxttxtQueueLength;
        private Queue<string> MainTxtQueue;

        public MainForm()
        {
            InitializeComponent();
            InitializeValues();
            MainProgram();
        }

        private void InitializeValues()
        {
            TxttxtQueueLength = 1000;
            MainTxtQueue = new Queue<string>(TxttxtQueueLength);
        }

        private void MainProgram()
        {
            NewMsg($"{Resources.Welcome} {Resources.GameTitle} {Resources.Version} {Resources.VersionId}", MainTxtQueue, MainTxtBx);
        }

        private void NewMsg(string newString, Queue<string> txtQueue, RichTextBox txtBx)
        {
            #region update queue
            //check if the queue is at its maximum size
            if (txtQueue.Count < TxttxtQueueLength)
            {
                //if not just add the new string
                txtQueue.Enqueue(newString);
            }
            else
            {
                //else RemoveOwnedForm the oldest line
                txtQueue.Dequeue();
                //and then add the new string
                txtQueue.Enqueue(newString);
            }
            #endregion

            #region update textbox
            //copy everything into a stringbuilder
            //and add an enter after each line in the queue for the textbox
            StringBuilder newTxt = new StringBuilder();
            for (int i = 0; i < txtQueue.Count; i++)
            {
                newTxt.Append($"{txtQueue.ElementAt(i)}\n");
            }
            //update the actual textbox
            txtBx.Text = newTxt.ToString();
            #endregion
        }
    }
}
