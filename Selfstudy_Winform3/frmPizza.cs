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


        public delegate int delPizzaComplete(string strResult, int iTime); // main에 넘겨주고픈 값 담을 delegate 생성
        public event delPizzaComplete eventdelPizzaComplete;  //delegate event

        private bool orderComplete = false;  //피자 제작 완료되었는지
        // ↑캡슐화 
        public bool OrderComplete { get => orderComplete; set => orderComplete = value; }

        public frmPizza()    //기본 생성자
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
         * Main에서 받은 Dictionary(모든 주문 정보 있음)로 계산하는 함수
         * event 를 써준다고 해서 delegate랑 반환타입, 매개변수 맞출 필요 전혀 없음!!!!! 함수를 넘기는게 아니니까
         */

        internal void fPizzaCheck(Dictionary<string,int> dPizzaOrder)
        {
            orderComplete = false;  //아직 다 안 만들었어요~

            int iTotalTime = 0;  //총 소요시간

            //키 - 벨류 세트 하나씩 빼옴 ex) 오리지널, 1 / 치즈크러스트 , 1 / 감자 , 2
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
                iTime = iNowTime * iCount;   //고른 항목 제작에 걸리는 시간 * 개수
                iTotalTime = iTotalTime + iTime;    //총 소요된 시간 
                lboxPizzaMake.Items.Add(string.Format("{0}) {1} : {2}초 ({3}초, {4}개)", strType, oOrder.Key, iTime, iNowTime, iCount));

                Refresh();
                Thread.Sleep(1000);  //1초마다 멈춤
            }

            // FPizza_eventdelPizzaComplete("완료했으니 부모Form으로 가야지", iTotalTime);  
            // ★ Main Form으로 가서 끝났다고 event. 
            //★  public delegate int delPizzaComplete 가 반환값이 int 이므로 int iRet으로 보내고,
            // ★ 탭탭해서 만들어준 Main함수또한 int(delegate영향)임!! 그쪽에서 return하면 iRet으로 옴
            int iRet = eventdelPizzaComplete("Pizza가 완성 되었습니다", iTotalTime);   

            // eventdelPizzaComplete("Pizza가 완성 되었습니다", iTotalTime); //<- delegate가 void거나 / return int 작업 싫으면 이래도OK

            orderComplete = true;


            lboxPizzaMake.Items.Add("--------------------");
            if (iRet == 0)     //Main에서 return으로 받은거. delegate가 void였으면 return으로 이런거 못함. Main도 void이니까
            {
                lboxPizzaMake.Items.Add("주문 완료 확인!");
            }
            else
            {
                lboxPizzaMake.Items.Add("늦어졌어요! 빨리 배송해야 합니다!");
            }
        }



    }
}
