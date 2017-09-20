namespace UI_WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.MainTxtBx = new System.Windows.Forms.TextBox();
            this.ChatTab = new System.Windows.Forms.TabPage();
            this.ChatTxtBx = new System.Windows.Forms.TextBox();
            this.MessageTxtBx = new System.Windows.Forms.TextBox();
            this.TabControl.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.ChatTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendButton.Location = new System.Drawing.Point(397, 226);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.MainTab);
            this.TabControl.Controls.Add(this.ChatTab);
            this.TabControl.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(460, 208);
            this.TabControl.TabIndex = 0;
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.MainTxtBx);
            this.MainTab.Location = new System.Drawing.Point(4, 22);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(452, 182);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "Main";
            this.MainTab.UseVisualStyleBackColor = true;
            // 
            // MainTxtBx
            // 
            this.MainTxtBx.AcceptsReturn = true;
            this.MainTxtBx.AcceptsTab = true;
            this.MainTxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTxtBx.Location = new System.Drawing.Point(6, 6);
            this.MainTxtBx.Multiline = true;
            this.MainTxtBx.Name = "MainTxtBx";
            this.MainTxtBx.ReadOnly = true;
            this.MainTxtBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainTxtBx.Size = new System.Drawing.Size(440, 170);
            this.MainTxtBx.TabIndex = 0;
            this.MainTxtBx.TabStop = false;
            // 
            // ChatTab
            // 
            this.ChatTab.Controls.Add(this.ChatTxtBx);
            this.ChatTab.Location = new System.Drawing.Point(4, 22);
            this.ChatTab.Name = "ChatTab";
            this.ChatTab.Padding = new System.Windows.Forms.Padding(3);
            this.ChatTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChatTab.Size = new System.Drawing.Size(452, 182);
            this.ChatTab.TabIndex = 1;
            this.ChatTab.Text = "Chat Log";
            this.ChatTab.UseVisualStyleBackColor = true;
            // 
            // ChatTxtBx
            // 
            this.ChatTxtBx.AcceptsReturn = true;
            this.ChatTxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatTxtBx.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatTxtBx.Location = new System.Drawing.Point(7, 7);
            this.ChatTxtBx.Multiline = true;
            this.ChatTxtBx.Name = "ChatTxtBx";
            this.ChatTxtBx.ReadOnly = true;
            this.ChatTxtBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatTxtBx.Size = new System.Drawing.Size(439, 169);
            this.ChatTxtBx.TabIndex = 0;
            this.ChatTxtBx.TabStop = false;
            // 
            // MessageTxtBx
            // 
            this.MessageTxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTxtBx.Location = new System.Drawing.Point(12, 228);
            this.MessageTxtBx.Name = "MessageTxtBx";
            this.MessageTxtBx.Size = new System.Drawing.Size(379, 20);
            this.MessageTxtBx.TabIndex = 1;
            this.MessageTxtBx.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.MessageTxtBx);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.SendButton);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Chat Game";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabControl.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.MainTab.PerformLayout();
            this.ChatTab.ResumeLayout(false);
            this.ChatTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MainTab;
        private System.Windows.Forms.TabPage ChatTab;
        private System.Windows.Forms.TextBox MessageTxtBx;
        private System.Windows.Forms.TextBox ChatTxtBx;
        protected System.Windows.Forms.TextBox MainTxtBx;
    }
}

