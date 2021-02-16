
namespace UserControl_reward
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lboxList = new System.Windows.Forms.ListBox();
            this.ucInfo3 = new UserControl_reward.UCInfo();
            this.ucInfo2 = new UserControl_reward.UCInfo();
            this.ucInfo1 = new UserControl_reward.UCInfo();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Moccasin;
            this.panel1.Controls.Add(this.ucInfo3);
            this.panel1.Controls.Add(this.ucInfo2);
            this.panel1.Controls.Add(this.ucInfo1);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 374);
            this.panel1.TabIndex = 0;
            // 
            // lboxList
            // 
            this.lboxList.FormattingEnabled = true;
            this.lboxList.ItemHeight = 15;
            this.lboxList.Location = new System.Drawing.Point(13, 401);
            this.lboxList.Name = "lboxList";
            this.lboxList.Size = new System.Drawing.Size(889, 199);
            this.lboxList.TabIndex = 1;
            // 
            // ucInfo3
            // 
            this.ucInfo3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ucInfo3.Location = new System.Drawing.Point(610, 16);
            this.ucInfo3.Name = "ucInfo3";
            this.ucInfo3.Size = new System.Drawing.Size(265, 343);
            this.ucInfo3.TabIndex = 2;
            this.ucInfo3.UserFace = global::UserControl_reward.Properties.Resources._13;
            this.ucInfo3.UserMoney = "2800만원";
            this.ucInfo3.UserName = "이수박";
            this.ucInfo3.UserNo = "3";
            // 
            // ucInfo2
            // 
            this.ucInfo2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ucInfo2.Location = new System.Drawing.Point(313, 16);
            this.ucInfo2.Name = "ucInfo2";
            this.ucInfo2.Size = new System.Drawing.Size(265, 343);
            this.ucInfo2.TabIndex = 1;
            this.ucInfo2.UserFace = global::UserControl_reward.Properties.Resources._11;
            this.ucInfo2.UserMoney = "2500만원";
            this.ucInfo2.UserName = "김똥개";
            this.ucInfo2.UserNo = "2";
            // 
            // ucInfo1
            // 
            this.ucInfo1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ucInfo1.Location = new System.Drawing.Point(14, 16);
            this.ucInfo1.Name = "ucInfo1";
            this.ucInfo1.Size = new System.Drawing.Size(265, 343);
            this.ucInfo1.TabIndex = 0;
            this.ucInfo1.UserFace = global::UserControl_reward.Properties.Resources._12;
            this.ucInfo1.UserMoney = "3000만원";
            this.ucInfo1.UserName = "아무개";
            this.ucInfo1.UserNo = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 615);
            this.Controls.Add(this.lboxList);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UCInfo ucInfo3;
        private UCInfo ucInfo2;
        private UCInfo ucInfo1;
        private System.Windows.Forms.ListBox lboxList;
    }
}

