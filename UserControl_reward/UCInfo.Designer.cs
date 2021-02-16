
namespace UserControl_reward
{
    partial class UCInfo
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pboxFace = new System.Windows.Forms.PictureBox();
            this.lblNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCatch = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxFace
            // 
            this.pboxFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxFace.Location = new System.Drawing.Point(51, 17);
            this.pboxFace.Name = "pboxFace";
            this.pboxFace.Size = new System.Drawing.Size(156, 181);
            this.pboxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxFace.TabIndex = 0;
            this.pboxFace.TabStop = false;
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(3, 17);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(15, 15);
            this.lblNo.TabIndex = 1;
            this.lblNo.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "이름:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "금액:";
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(12, 287);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 33);
            this.btnReg.TabIndex = 4;
            this.btnReg.Text = "수배";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(96, 287);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 33);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "중지";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCatch
            // 
            this.btnCatch.Location = new System.Drawing.Point(177, 287);
            this.btnCatch.Name = "btnCatch";
            this.btnCatch.Size = new System.Drawing.Size(75, 33);
            this.btnCatch.TabIndex = 6;
            this.btnCatch.Text = "검거";
            this.btnCatch.UseVisualStyleBackColor = true;
            this.btnCatch.Click += new System.EventHandler(this.btn_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(97, 217);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(15, 15);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "-";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(97, 252);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(15, 15);
            this.lblMoney.TabIndex = 8;
            this.lblMoney.Text = "-";
            // 
            // UCInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCatch);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.pboxFace);
            this.Name = "UCInfo";
            this.Size = new System.Drawing.Size(265, 334);
            ((System.ComponentModel.ISupportInitialize)(this.pboxFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxFace;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnCatch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMoney;
    }
}
