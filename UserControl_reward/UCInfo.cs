using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControl_reward
{
    public partial class UCInfo : UserControl
    {

        public delegate int delEvent(object sender, string strText);  //버튼, 수배/중지/검거
        public event delEvent eventDELEVENTsender;  


        // 이미지
        [Category("UserProperty"), Description("Image")]
        public Image UserFace  //속성
        {
            get
            {
                return this.pboxFace.BackgroundImage;
            }
            set
            {
                this.pboxFace.BackgroundImage = value;
            }
        }

        // 번호
        [Category("UserProperty"), Description("No")]
        public string UserNo
        {
            get
            {
                return this.lblNo.Text;
            }
            set
            {
                this.lblNo.Text = value;
            }
        }

        // 범죄자 이름
        [Category("UserProperty"), Description("criminal name")]
        public string UserName
        {
            get
            {
                return this.lblName.Text;
            }
            set
            {
                this.lblName.Text = value;
            }
        }

        // 범죄자 금액
        [Category("UserProperty"), Description("criminal Money")]
        public string UserMoney
        {
            get
            {
                return this.lblMoney.Text;
            }
            set
            {
                this.lblMoney.Text = value;
            }
        }


        public UCInfo()
        {
            InitializeComponent();
        }


        /*  수배 중지 검거  */
        private void btn_Click(object sender, EventArgs e)   //sender -> 이벤트를 발생 시킨 주체가 전달됨
        {
            Button oBtn = sender as Button;

            string strText = string.Empty;

            switch (oBtn.Name)
            {
                case "btnReg":
                    this.BackColor = Color.Red;
                    //eventDELEVENTsender(this, string.Format("{0}은 지금 {1}금액으로 수배중 입니다. 제보전화 112", lblName.Text,lblMoney.Text);
                    strText = string.Format("{0}는 지금 {1} 금액으로 수배중 입니다. 제보전화 112", lblName.Text,lblMoney.Text);
                    break;
                case"btnStop":
                    this.BackColor = Color.Yellow;
                    strText = string.Format("{0}는 지금 수배중지 상태 입니다.", lblName.Text);
                    break;
                case"btnCatch":
                    this.BackColor = Color.Blue;
                    strText = string.Format("{0}는 검거완료 되었습니다.", lblName.Text);
                    break;
                default:
                    break;
            }

            if (eventDELEVENTsender != null)    // 부모가 Event를 생성하지 않았을수도 있으므로 생성했을때만 보냄
            {
                eventDELEVENTsender(this, strText);   
            }

        }

       

    }
}
