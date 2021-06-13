using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selfstudy_Winform3
{
    public partial class frmPizza : Form
    {
        public delegate int delPizzaComplete(string strResult, int iTime); //form1.cs의 int FPizza_eventdelPizzaComplete
        public event delPizzaComplete eventdelPizzaComplete;  //delegate event

        private bool orderComplete = false;  //피자 제작 완료되었는지
        // ↑캡슐화 
        public bool OrderComplete { get => orderComplete; set => orderComplete = value; }

        public frmPizza()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* Pizza 주문 진행 상황을 표시 하기 위한 함수
           Dictionary 주문종류(string),개수(int)*/
        // 2
        internal void fPizzaCheck(Dictionary<string,int> dPizzaOrder)
        {
            orderComplete = false;  //아직 다 안 만들었어요~

            int iTotalTime = 0;  //총 소요시간

            //키랑 벨류를 같이 빼옴
            foreach (KeyValuePair<string,int> oOrder in dPizzaOrder)
            {
                int iNowTime = 0;
                int iTime = 0;
                int iCount = oOrder.Value;   //개수
                string strType = string.Empty;

                switch (oOrder.Key)
                {
                    //도우
                    case "오리지널":
                        iNowTime = 3000;
                        strType = "도우";
                        break;
                    case "씬":
                        iNowTime = 4000;
                        strType = "도우";
                        break;
                    //엣지
                    case "리치골드":
                        iNowTime = 2000;
                        strType = "엣지";
                        break;
                    case "치즈크러스트":
                        iNowTime = 2500;
                        strType = "엣지";
                        break;
                    //토핑
                    case "소세지":
                        iNowTime = 600;
                        strType = "토핑";
                        break;
                    case "치즈":
                        iNowTime = 1000;
                        strType = "토핑";
                        break;
                    case "감자":
                        iNowTime = 500;
                        strType = "토핑";
                        break;

                    default:
                        break;
                }
                iTime = iNowTime * iCount;   //제작에 걸리는 시간 * 개수
                iTotalTime = iTotalTime + iTime;    //총 소요된 시간 
                lboxPizzaMake.Items.Add(string.Format("{0}) {1} : {2}초 ({3}초, {4}개)", strType, oOrder.Key, iTime, iNowTime, iCount));

                Refresh();
                Thread.Sleep(1000);
            }

            // FPizza_eventdelPizzaComplete("완료했으니 부모Form으로 가야지", iTotalTime);  
            // ★ Main Form으로 가서 끝났다고 event. return값 받으면 여기로 다시옴!! 
            //★ int FPizza_eventdelPizzaComplete가 int 타입이므로 return해줄때 int로~~
            int iRet = eventdelPizzaComplete("Pizza가 완성 되었습니다", iTotalTime);   
            orderComplete = true;


            lboxPizzaMake.Items.Add("--------------------");
            if (iRet == 0)
            {
                lboxPizzaMake.Items.Add("주문 완료 확인!");
            }
            else  //return -1을 받음
            {
                lboxPizzaMake.Items.Add("늦어졌어요! 빨리 배송해야 합니다!");
            }
        }



    }
}
