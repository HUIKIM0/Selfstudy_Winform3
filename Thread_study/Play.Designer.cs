
namespace Thread_study
{
    partial class Play
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
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.pbarPlayer = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(12, 16);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(84, 15);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "PlayerName";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(279, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(83, 29);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "포기";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(370, 16);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(136, 15);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "진행 상황 표시: 0%";
            // 
            // pbarPlayer
            // 
            this.pbarPlayer.Location = new System.Drawing.Point(15, 54);
            this.pbarPlayer.Name = "pbarPlayer";
            this.pbarPlayer.Size = new System.Drawing.Size(491, 23);
            this.pbarPlayer.TabIndex = 3;
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 101);
            this.Controls.Add(this.pbarPlayer);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblPlayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Play";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Play";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ProgressBar pbarPlayer;
    }
}