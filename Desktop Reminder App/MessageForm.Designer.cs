namespace r
{
    partial class PopUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpForm));
            this.btnStop = new MetroFramework.Controls.MetroButton();
            this.txtDestination = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStop.Location = new System.Drawing.Point(108, 264);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseCustomBackColor = true;
            this.btnStop.UseCustomForeColor = true;
            this.btnStop.UseSelectable = true;
            this.btnStop.UseStyleColors = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDestination.CustomButton.Image = null;
            this.txtDestination.CustomButton.Location = new System.Drawing.Point(32, 2);
            this.txtDestination.CustomButton.Name = "";
            this.txtDestination.CustomButton.Size = new System.Drawing.Size(235, 235);
            this.txtDestination.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDestination.CustomButton.TabIndex = 1;
            this.txtDestination.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDestination.CustomButton.UseSelectable = true;
            this.txtDestination.CustomButton.Visible = false;
            this.txtDestination.Lines = new string[0];
            this.txtDestination.Location = new System.Drawing.Point(15, 18);
            this.txtDestination.MaxLength = 32767;
            this.txtDestination.Multiline = true;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.PasswordChar = '\0';
            this.txtDestination.ReadOnly = true;
            this.txtDestination.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDestination.SelectedText = "";
            this.txtDestination.SelectionLength = 0;
            this.txtDestination.SelectionStart = 0;
            this.txtDestination.ShortcutsEnabled = true;
            this.txtDestination.Size = new System.Drawing.Size(270, 240);
            this.txtDestination.TabIndex = 1;
            this.txtDestination.UseSelectable = true;
            this.txtDestination.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDestination.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.btnStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "PopUpForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopUpForm_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnStop;
        private MetroFramework.Controls.MetroTextBox txtDestination;
    }
}