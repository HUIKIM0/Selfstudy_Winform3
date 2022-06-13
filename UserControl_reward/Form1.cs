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
                if(oControls is UCInfo)    
                {
                   
                    UCInfo oInfo = oControls as UCInfo;   

                    oInfo.eventDELEVENTsender += OInfo_eventDELEVENTsender;   

                }
            }
        }

        
        private int OInfo_eventDELEVENTsender(object sender, string strText)  // UCInfo , 수배/중지/검거 관련 텍스트
        {

            UCInfo oInfo = sender as UCInfo;

            lboxList.Items.Add(string.Format("No.{0}) {1}", oInfo.UserNo ,strText));   
            return 0;
        }


    }

}
