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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //ucInfo1.eventDELEVENTsender += UcInfo1_eventDELEVENTsender;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var oControls in pMain.Controls)
            {
                if(oControls is UCInfo)    //pMain에 담긴 컨트롤이 UCInfo인걸 찾을것
                {
                    UCInfo oInfo = oControls as UCInfo;   //형태가 안정해진 var oControls를 UCInfo로 변경

                    oInfo.eventDELEVENTsender += OInfo_eventDELEVENTsender;

                }
            }
        }

        private int OInfo_eventDELEVENTsender(object sender, string strText)  //버튼, 수배/중지/검거
        {
            UCInfo oInfo = sender as UCInfo;

            lboxList.Items.Add(string.Format("No{0}. {1}", oInfo.UserNo, strText));
            return 0;
        }

        //private int UcInfo1_eventDELEVENTsender(object sender, string strText)
        //{
        //lboxList.Items.Add(string.Format("{0}) {1}", UCInfo.UserNo, strText));
        //    return 0;
        //}

    }

}
