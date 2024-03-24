/*#define LEVEL1*/
#define LEVEL2

using System;
using System.Diagnostics;
using System.Dynamic;
using System.Numerics;
using System.Text;

#if(LEVEL1)
namespace CSharpPractice {
    class Easy{

        static void Input()
        {
            //입력과 출력
            string inp = Console.ReadLine();
            Console.WriteLine(int.Parse(inp));
            //입력이 복수개일 경우
            string[] arr = Console.ReadLine().Split(' ');

            //자리 수 맞추기
            Console.WriteLine("{0:D3}", 10); // 십진수 정수 3자리
            Console.WriteLine("{0:F3}", 1.23456); // 부동소수점 3자리 반올림
        }

        static void Vari()
        {
            //정수형(u를 붙이면 양수 정수형으로 범위 변경)
            byte by = byte.MaxValue; //255
            short sh = short.MaxValue; //32767
            int i = int.MaxValue; // 2147483647 
            long l = long.MaxValue; // 9223372036854775807 

            float f = float.MaxValue; // 3.4028235E+38
            double d = double.MaxValue; // 1.7976931348623157E+308

            char c = '가'; //utf-16 리틀앤디안 
            string s = "가나다";

            bool b = true;

            Console.WriteLine(" " + by + " " + sh + " " + i + " " + l + " " + f + " " + d + " " + c + " " + s + " " + b);


            //형변환
            by = (byte)sh; //명시적 형변
            i = by; //묵시적 형변
            i = (int)d; //명시적 소수점 정수형변환(범위내에 있으면 정상작동, 범위초과시 최대값으로)
            i = (char)(c + 1); //글자 형변환
        }


        static void StrUse()
        {
            //문자열을 더 성능좋게 다루는 법
            StringBuilder sb = new StringBuilder();
            sb.Append("1번: 가나다");
            sb.Append("2번: 라마바");

            //길이만큼 삭제, 삽입
            sb.Remove(0, 2);
            sb.Insert(0, "0번");
            Console.WriteLine(sb.ToString());

        }


        static void Cal()
        {
            int a = 2;
            int b = 3;
            int c = 4;
            int re = 0;

            //가감승제(승제 먼저 계산후, 오른쪽에서 왼쪽으로 계산)
            re = a + b;
            re = a - b;
            re = a * b;
            re = c / a;
            re = b % 2;

            //단항연산
            a++;
            --a;

            //논리연산(true, false로 나옴)
            bool bo = a < b;
            bo = a > b;
            bo = a < b && b < c; //and
            bo = a < b || b < c; //or
            bo = !bo; //not

        }

        static void WhatIf()
        {

            int test = 10;
            //if 구문
            if (test == 100) Console.Write(100);
            else if (test == 50) Console.Write(50);
            else if (test == 10) Console.Write(10);
            else Console.Write("default");

            //스위치 구문
            switch (test)
            {
                case 100:
                    Console.WriteLine(100);
                    break;//break 구문이 없으면 아래것들도 실행
                case 50:
                    Console.WriteLine(50);
                    break;
                case 10:
                    Console.WriteLine(10);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }

        }

        static void Repeat()
        {

            int i = 10;
            while (i-- > 0)
            {
                if (i < 5) break;// 반복문을 강제로 끝냄
                Console.WriteLine(i);

            }

            Console.WriteLine("----");

            for (int start = 0; start < 10; start++)
            {
                if (start % 2 == 0) continue; //반복문을 다음단계로 넘김
                Console.WriteLine(start);

            }

        }

        //함수생성법
        static int Func(int a = 0)
        {
            Console.WriteLine($"{a}");
            return 0;
        }

        static int Mathma(int a = 2, int b = 3)
        {

            Console.WriteLine($"{Math.Abs(a)} | {Math.Max(a, b)} | {Math.Min(a, b)} | {Math.Pow(a, b)} | {Math.Sqrt(a)}");
            return 0;
        }
        //어레이는 참조(주소)로 넘어간다.
        static int Arr(int[] arr)
        {
            //생성
            int[] arr1 = new int[4] { 0, 1, 2, 3 };
            int[] arr2 = { 10, 20, 30, 40 };

            //값변경
            arr[0] = 10;
            Console.WriteLine(arr1.Length);//미리정한 범위를 벗어나는건 불가능

            return 0;
        }


    }
    class Program
    {

        static void Main(string[] args)
        {

        }

    }


}

#elif(LEVEL2)
namespace CSharpPractice
{

    struct Str
    {
        public int X;
        public int Y;

        public Str(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public override string ToString()
        {
            return string.Format("(X, Y): ({0}, {1})", X, Y);
        }
    }

    class Cls
    {

        public int X=0;
        public int Y=0;

        public Cls()
        {
            Console.WriteLine("Make Class Instance With No Arg");
            this.X = 1;
            this.Y = 1;

        }

        public Cls(int x, int y)
        {
            Console.WriteLine("Make Class Instance");
            this.X = x;
            this.Y = y;
        }
        public override string ToString()
        {
            return string.Format("(X, Y): ({0}, {1})", X, Y);
        }

        //오버라이드 가능하게 만들어줌
        public virtual void Prite()
        {
            Console.WriteLine("{} {}", X, Y);
        }
    }

    class ChildCls : Cls
    {
        
        //부모생성자를 명시적으로 호출하지 않으면 디폴트 생성자가 호출됨(없을경우 에러)
        public ChildCls(int x, int y):base(x,y)
        {
            Console.WriteLine("Make Child Instance");
        }

        //버추얼 오버라이드를 통해서 부모의 클래스를 덮어쓰기가 가능함
        //오버라이드 표시가 없으면 다형성을 이용 못함
        public override void Prite()
        {
            Console.WriteLine("Child Call X Y: {0} {1}", X, Y);
        }
    }

    interface IParent
    {
        void Hello();
    }
    class ImprementCls : IParent
    {

        //부모생성자를 명시적으로 호출하지 않으면 디폴트 생성자가 호출됨(없을경우 에러)
        public ImprementCls()
        {
            Console.WriteLine("Make ImprementCls");
        }
        public void Hello() {
            Console.WriteLine("Hello Interface");
        }

    }

    class MyGeneric<T> where T : struct
    {
        T element;

        public T Returner(T t)
        {
            element = t;
            return t;
        }


    }
    class IndexerTest
    {
        private double val;
        public float this[float index]
        {
            get {
                Console.WriteLine(val);
                return index;
            }
            set {
                val = index;
            }
        }
        static void UseIT()
        {
            IndexerTest ind=new IndexerTest();
            float f = ind[1];
            ind[1]=1;
            f = ind[1];
        }
    }


    //델리게이트 선언(클래스 선언과 같음)
    delegate int TestDel(int i);
    class Dele
    {
        public static event TestDel myEvent;

        //public static TestDel
        static int DumpMethod(int i)
        {
            Console.WriteLine($"첫번때 메소드 입력값: {i}");
            return i;
        }
        static int DumpMethod2(int i)
        {
            Console.WriteLine($"두번째 메소드 입력값: {i}");
            return i;
        }
        public static void CallDel()
        {
            Console.WriteLine("사용법");
            TestDel m = new TestDel(DumpMethod);
            m.Invoke(10);
            m(9);

            //델리게이터에 함수 추가
            Console.WriteLine("함수추가");
            m += DumpMethod2;
            m(8);
            Console.WriteLine("함수추가2");
            m += DumpMethod2;//같은 함수를 두번 추가 가능
            Console.WriteLine(m(7));

            //델리게이터에 함수 제거
            Console.WriteLine("함수제거");
            m -= DumpMethod2;
            m!(6);

            //재할당(기존의 것들은 다 제거)
            Console.WriteLine("재할당");
            m = DumpMethod;

            //이벤트
            myEvent = DumpMethod; //오직 클래스 내부에서만 대입, 호출 가능하다.
            myEvent(5);

            //무명 메서드와 람다
            Console.WriteLine("무명메서드와 람다");
            m = delegate (int i)
            {
                Console.WriteLine($"무명 메소드 입력값: {i}");
                return 0;
            };
            m += (int i) => {
                Console.WriteLine($"람다 메소드 입력값: {i}");
                return i;
            };
            m += (i) => i; //즉시 리턴값을 반환도 가능
            m(4);

        }
    }

    enum NumberEnum
    {
        Zero,   // 0
        One,  // 1
        Five = 5,  // 5
        Ten = 10   // 10
    }

    class Tas
    {
        public static int LongTask(int num)
        {
            Console.WriteLine("Sub: " + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");

            }
            Console.WriteLine("SubEnd: " + Thread.CurrentThread.ManagedThreadId);

            return num;
        }

        public async static void StartTask()
        {
            var t = Task.Run(() => LongTask(10));//테스크를 시작
            Console.WriteLine("테스크와 별개로 동시에 실행됨");
            await t;//테스크의 종료를 기다림
            Console.WriteLine("테스크가 끝나고 실행됨");


        }
        public static void Test()
        {
            Console.WriteLine("Main: " + Thread.CurrentThread.ManagedThreadId);
            StartTask();
            Console.WriteLine("MainEnd: " + Thread.CurrentThread.ManagedThreadId);
        }


    }
    class Program
    {
       
        public static void Main()
        {


        }

    }



}
#endif