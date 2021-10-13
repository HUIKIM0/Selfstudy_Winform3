using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Selfstudy_Winform3
{
    public partial class Form1 : Form
    {
        // 함수 먼저 만들고 delegate만들어야 편함
        // 반환값을 void아닌 int로 해줘서 각 함수 계산값 return 받을거임 _iTotalPrice(전역)에 넣게

        public delegate int delFuncDow_Edge(int i);   //int 도우 or int 엣지
        public delegate int delFuncTopping(string strOrder, int Ea);  //string 토핑종류, int 토핑추가횟수

        public delegate object delFuncOrder(object i);  //var, object

        int _iTotalPrice = 0;

        public Form1()
        {
            InitializeComponent();
        }

        /* ★주문하기 버튼★ */
        private void btnOrder_Click(object sender, EventArgs e)
        {

            Dictionary<string, int> dPizzaOrder = new Dictionary<string, int>(); // ★ Pizza 주문을 담을 그릇 (Key : 주문 종류, value : 개수)


            delFuncDow_Edge delDow = new delFuncDow_Edge(fDow);   // int 도우  함수 fDow와 연결
            delFuncDow_Edge delEdge = new delFuncDow_Edge(fEdge);  // int 엣지  함수 fEdge와 연결


            int iDowOrder = 0;
            int iEdgeOrder = 0;

            if (rdoDow1.Checked)
            {
                iDowOrder = 1;
                dPizzaOrder.Add("오리지널", 1);  //사장님 오리지널 하나요^^
            }
            else if (rdoDow2.Checked)
            {
                iDowOrder = 2;
                dPizzaOrder.Add("씬", 1);
            }
            //delDow(iDowOrder);    return _iTotalPirce

            if (rdoEdge1.Checked)
            {
                iEdgeOrder = 1;
                dPizzaOrder.Add("리치골드", 1);
            }
            else if (rdoEdge2.Checked)
            {
                iEdgeOrder = 2;
                dPizzaOrder.Add("치즈크러스트", 1);
            }

            //delEdge(iEdgeOrder);   return _iTotalPrice


            // fCallBackDelegate 함수에다가 int타입, delegate호출(함수호출이 아님 함수대리자 delegate)
            // ★ delegate랑 연결한 함수 fDow와 fEdge에 iDowOrder값 넘겨주고, iEdgeOrder값 넘겨줌! delegate이용해서!! ★
            // fDow(iDowOrder)
            // fEdge(iEdgeOrder)  랑 같은맥락
            fCallBackDelegate(iDowOrder, fDow);        //delDow(iDowOrder);
            fCallBackDelegate(iEdgeOrder, fEdge);      //delEdge(iEdgeOrder);



            delFuncTopping delTopping = null;      //토핑종류(string), 추가횟수(int)

            /* 토핑 선택 확인 */
            if (cboxTopping1.Checked)
            {
                delTopping = new delFuncTopping(fTopping1);           // ★ delegate인 delTopping과 함수인 fTopping1 연결


                dPizzaOrder.Add("소세지", (int)numEa.Value);       
            }

            if (cboxTopping2.Checked)
            {
                delTopping += fTopping2;                           
                dPizzaOrder.Add("감자", (int)numEa.Value);
            }

            if (cboxTopping3.Checked)
            {
                delTopping += fTopping3;
                dPizzaOrder.Add("치즈", (int)numEa.Value);
            }

            if(!cboxTopping1.Checked && !cboxTopping2.Checked && !cboxTopping3.Checked)
            {
                delTopping = delTopping + fTopping4;
            }

            // ★ delegate인 delTopping
            int Result = delTopping("토핑", (int)numEa.Value);   //string,int


            flboxOrderText("----------------------------------");
            flboxOrderText(string.Format("전체 주문가격은 {0}원 입니다.", _iTotalPrice));
            flboxOrderText("\r\n");



            //주문하기 버튼 누르면 frmPizza.cs 폼 작업!! frmLoading에 매개변수를 딕셔너리로 dPizzaOrder(모든값 다 가지고있음)
            frmLoading(dPizzaOrder);          

        }



        /* 도우
            비선택/오리지널 : 1번 (10000원)
            씬 :2번 (11000)원  */
        private int fDow(int iOrder)    //iOrder에 iDowOrder 1,2 해준거 들어감
        {
            string strOrder = string.Empty;
            string strEnder = "\n";
            int iPrice = 0; //도우 가격

            if (iOrder == 1)
            {
                iPrice = 10000;
                lboxOrderList.Items.Add(strEnder);
                strOrder = string.Format("도우는 오리지널을 선택 하셨습니다. ({0}원)", iPrice);
            }
            else if (iOrder == 2)
            {
                iPrice = 11000;
                lboxOrderList.Items.Add(strEnder);
                strOrder = string.Format("도우는 씬을 선택 하셨습니다. ({0}원)", iPrice);
            }

            flboxOrderText(strOrder);   //ListBox.Items.Add
            return _iTotalPrice = _iTotalPrice + iPrice;
        }


        /* 엣지
            리치골드 : 1번 (2000원)
            치즈크러스트 : 2번 (3000원)
            엣지변경X 비선택 : 3번 (0원) */
        private int fEdge(int iOrder)
        {
            string strOrder = string.Empty;
            int iPrice = 0; //도우 가격

            if (iOrder == 1)
            {
                iPrice = 2000;
                strOrder = string.Format("엣지는 리치골드를 선택 하셨습니다. ({0}원)", iPrice);
            }
            else if (iOrder == 2)
            {
                iPrice = 3000;
                strOrder = string.Format("엣지는 치즈 크러스트를 선택 하셨습니다. ({0}원)", iPrice);
            }

            else if (iOrder == 3)
            {
                iPrice = 0;
                strOrder = string.Format("엣지는 변경하지 않으셨습니다. ({0}원)", iPrice);
            }

            flboxOrderText(strOrder);
            return _iTotalPrice = _iTotalPrice + iPrice;
        }


        public int fCallBackDelegate(int i, delFuncDow_Edge dFunction)
        {
            return dFunction(i);
        }


        /* 토핑 
           소시지 500원
           치즈 400원 
           감자 300원
           몇개 추가하는지 (EA)도 봐야함

           텔리게이트 체인 해줘서 fTopping1~3의 매개변수 Order , iEa는 다 같음
        */

        // 소세지
        private int fTopping1(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = 500 * iEa;    // 소세지 가격 * 개수

            strOrder = string.Format("소세지 {0} {1}개를 선택 하셨습니다. ({2}원 (1ea 500원)",Order,iEa,iPrice);
            flboxOrderText(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        //치즈
        private int fTopping2(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = 400 * iEa;    // 치즈 가격 * 개수

            strOrder = string.Format("치즈 {0} {1}개를 선택 하셨습니다. ({2}원 (1ea 500원)", Order, iEa, iPrice);
            flboxOrderText(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        //감자
        private int fTopping3(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = 300 * iEa;    // 소세지 가격 * 개수

            strOrder = string.Format("감자 {0} {1}개를 선택 하셨습니다. ({2}원 (1ea 500원)", Order, iEa, iPrice);
            flboxOrderText(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        private int fTopping4(string Order, int Ea)
        {
            string strOrder = string.Empty;
            int iPrice = 0;
            strOrder = string.Format("토핑은 선택하지 않으셨습니다. ({0}원)", iPrice);
            lboxOrderList.Items.Add(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        //ListBox에 보여주기
        private void flboxOrderText(string strOrderText)
        {
           lboxOrderList.Items.Add(strOrderText);
        }


        /* 새로 만든 fmPizza.cs 선언 */
        frmPizza fPizza;

        // Dictionary<string 주문종류(key 중복X), int 개수(value)>
        // 함수 매개변수로 받은 Dictionary에 사용자가 고른 항목에 대한 모든게 들어가있음
        private void frmLoading(Dictionary<string,int> dPizzaOrder)
        {

            if(fPizza != null)      //fPizza form이 이미 띄워져있으면(이거 때문에 위에서 전역으로 
            {
                fPizza.Dispose();    //삭제하기
                fPizza = null;
            }


            fPizza = new frmPizza();     //클래스 인스턴스 생성. ()파라미터에 값 없음 .기본생성자

            //frmPizza.cs에서 만들어준 delegate event와 연결
            fPizza.eventdelPizzaComplete += FPizza_eventdelPizzaComplete;  
            fPizza.Show();  //폼 띄우기

            fPizza.fPizzaCheck(dPizzaOrder);  //fPizzaCheck 함수에 Dictionary 값 넘겨줌

        }

        // event delegate. 위의 fPizza.eventdelPizzaComplete += 탭탭 해서 나온거
        // ★ frmPiaaza.cs에 있는 delegate와 반환타입, 매개변수가 같다!! delegate에 영향받음
        // int iRet = eventdelPizzaComplete("Pizza가 완성 되었습니다", iTotalTime); 
        // ★ 자식form에서 event로 넘겨주면 이쪽에서 받아줌!!
        private int FPizza_eventdelPizzaComplete(string strResult, int iTime)
        {
            flboxOrderText("----------------------------------");
            flboxOrderText(string.Format("{0} / 걸린 시간 : {1}", strResult, iTime));  // 피자가 완성되었습니다 / 걸린시간 
            flboxOrderText("\r\n");



            //frmPizza.cs의 int iRet = eventdelPizzaComplete(string, int) iRet에 return값 준다
            //시간 계산을 해서 해당 시간이 넘어가면 - 1을 아니면 0을 return해서 iRet에 준다
            if (iTime > 10000)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }




    }
}
