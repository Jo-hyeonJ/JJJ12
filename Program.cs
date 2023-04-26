using System.Collections;
using System.Diagnostics.Metrics;

namespace JJJ12
{
    interface Itemp
    {
        // 인터페이스는 함수 제한처럼 변수도 제한 할 수 있다.
        string Name { get; }
        void Func();

    }


    internal class Program
    {
        class MyList : IEnumerable, IEnumerator // 에러 코드 우클릭 퀵 액션으로 쉽게 오류 해결 가능
        {
            int[] array;
            int capacity;
            
            public int Capacity
            {
                get { return Capacity; }    
            }
            // IEnumerator 멤버
            public object Current
            { get { return array[position]; } }
            int position = -1;

            public MyList()
            {
                array = new int[4];
                capacity = 4;
            }
            // indexer 인덱서
            // 인덱스를 통해 내부 값에 접근하게 해주는 프로퍼티

            public int this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    // 배열의 길이를 바꾸는 법.
                    // Resize : 제시 받은 인덱스의 크기에 해당하는 메모리 크기를 할당한 뒤, 값을 복사해준다.
                    // 인위적으로 가변 길이 배열로 바꾸는 형태
                    capacity = index + 1;
                    Array.Resize<int>(ref array, capacity);

                    array[index] = value; // value는 외부에서 가져온 값을 뜻한다.
                }
            }
            // IEnumerable 멤버
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < array.Length; i++)
                    yield return array[i];
            }

            public bool MoveNext()
            {
             if(position == array.Length -1)
                {
                    Reset();
                    return false;
                }
                position++;
                return true;
            }

            public void Reset()
            {
                position = - 1;
            }
        }



        static void Main(string[] args)
        {
            // 컬렉션(Collection)
            #region
            // = 같은 성격을 띠는 데이터의 모음. 배열도 .NET Framework가 제공하는 컬렉션의 일종
            // 대부분의 상황에서 기존 컬렉션 자료구조가 아닌 일반화 전용 컬렉션을 사용한다.

            // ArrayList
            // Queue
            // Stack
            // Hashtable

            // ArrayList
            /*
        // 배열과 성질이 비슷하나 갯수의 제한이 없다.
        // 데이터 삽입과 제거는 뒤로 데이터를 받고 맨 앞 데이터를 내보내는 식으로 진행되며 집합의 크기가 배열의 기존 용량보다 더 커질 경우.
        // 배수 혹은 제곱의 크기를 가진 새로운 메모리를 할당하고 값을 이동시킨다.
        // arraylist의 자료형은 object이기 때문에 어떤 자료형이든 수용이 가능하다.


        // 요소를 추가하는 법.

        ArrayList arrayList = new ArrayList();
        arrayList.Add(10);
        arrayList.Add(20);
        arrayList.Add(30);

        // arraylist에 어떠한 자료형 값이라도 추가할 수 있는 이유는 object형으로 데이터를 받기 때문이다.
        arrayList.Add("string");
        arrayList.Add(3.14f);

        Console.WriteLine("arraylist의 요소 개수 : " + arrayList.Count);

        // 지우는 법
        arrayList.RemoveAt(0);
        Console.WriteLine("arraylist의 요소 개수 : " + arrayList.Count);

        Console.WriteLine();

        // 중간 데이터 삽입
        arrayList.Insert(0, 40);        // 0번째 인덱스에 40을 삽입한다. 이때 기존의 값은 뒤로 한칸씩 밀려난다.

        // foreach(int num in arrayList) foreach 수용한다.
        // {  Console.WriteLine(num); }

        for(int i = 0; i < arrayList.Count; i++)
        {
            Console.WriteLine(arrayList[i]);
        }

        // 데이터 받기
        // object형 자료형을 받기 위해선 명시적으로 형변환을 해주어야한다. (언박싱)
        int number = (int)arrayList[0];
        Console.WriteLine("number의 값은 : " + number);
*/

            // 큐와 스택 (Queue & Stack)
            /*
        // 큐(Queue) = 대기열
        // 선입선출(FIFO) 형태의 컬렉션이다. 리스트와 다르게 값의 축출 후에 데이터의 이동이 없다.
        // 값을 빼내는 순간 리스트에서 제외된다.

        Queue queue = new Queue(); 
        queue.Enqueue(100);                     // 데이터 삽입
        queue.Enqueue(200);

        Console.WriteLine(queue.Dequeue());     // 가장 앞에 있는 데이터를 꺼낸다.
        Console.WriteLine(queue.Count);         // 카운트 출력
        Console.WriteLine(queue.Peek);          // 가장 앞에 있는 데이터를 참조 (빼내지는 않는다)
        Console.WriteLine(queue.Count);

        // 스택(Stack) : 아래서부터 위로 쌓아가는 형태의 자료구조로 후입선출 (LIFO)의 형태를 뛴다.
        // 가장 최근 삽입한 값이 먼저 출력 되기에 [선입선출의 큐(Queue)]와 반대되는 성질을 가지고 있다.
        // 역시 컬렉션을 상속하기에 object 자료형을 사용한다.
        Stack stack = new Stack();
        stack.Push(100);
        stack.Push(200);        // 스택에 데이터를 추가한다.
        stack.Push(300);

        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());        // 큐의 Peek과 같게 출력될 데이터를 참조한다. (값을 빼지 않음)
        Console.WriteLine(stack.Count);


        // foreach를 사용한다면 값을 모두 빼지 않고 순회가 가능하다.
        foreach(object obj in stack) 
        { Console.WriteLine("stack의 값 : " + obj); }
*/

            // Hashtable (해쉬 테이블)
            /*
        // 키, 값이 쌍으로 이루어진 데이터
        // 제공 받은 키 값을 hash로 치환한 후, 자료구조 내부에서 적합한 인덱스를 다이렉트로 찾아내는 형식. 

        Hashtable table = new Hashtable();
        table.Add("book", "책");
        table.Add("cat", "고양이");

        Console.WriteLine("book : " + table["book"]);       // book이라는 키값을 통해 데이터를 찾는다.
        Console.WriteLine("dog : " + table["dog"]);       // 존재하지 않는 키값을 입력할 경우 null값을 출력한다.

        if (table.ContainsKey("dog"))                   // 해당 키값을 가진 데이터가 있는지 확인하는 함수 (출력값 : bool)
        { Console.WriteLine("dog : " + table["dog"]); }
        else
        { Console.WriteLine("dog라는 키 값을 가진 데이터가 없습니다."); }


        // var 키워드 : 자료형을 유추시킨다. 그 뒤 적합하게 형변환을 시킨다.
        // 프로그램에게 맡기는 형식이기에 예상하지 못한 형태가 될 수 있다. 때문에 권장되지 않는다. (시스템에 따라 변칙 가능성 또한 있다.)
        var index = 10;     // 사실상 int의 자료형을 가진다.

        foreach(var value in table)
        {
            DictionaryEntry entry = (DictionaryEntry)value;
            Console.WriteLine("table의 키 값은 : " + entry.Key + ", value 값은 : " + entry.Value);
            // DictionaryEntry 라는 자료형으로 표시되며 키 값과 밸류 값을 지니고 있음을 알 수 있다.
        }

        Console.Write("key 값들은 : ");
        foreach(var key in table.Keys)
        {
            Console.Write(key+", ");
        }
*/
            #endregion

            MyList list = new MyList();
            // list[0] = 10; 함수 내부에 있는 배열에는 접근이 불가능함.
            Console.WriteLine(list[0]);

            // 배열을 초과하는 인덱스에 값을 집어넣음
            list[4] = 100;
            // 인덱서 set 프로퍼티에 resize를 집어넣음으로써 문제 없이 수행함.
            Console.WriteLine(list[4]);

            // foreach(int i in list) 직접 만든 배열은 foreach 수용이 되지 않는다. Getenumerator를 확장하지 않고 있기 때문

            // yield : 프로그램의 흐름을 밖으로 전달하고 잠시 대기하겠다.
            // 병렬처리를 위해 사용함

            // 게임
            // (물리처리 피직스)
            // 입력 인풋
            // 처리 프로세스
            // 출력 아웃풋 순으로 진행됨. 이 전체의 순회를 1프레임이라고 한다.
            // 이 전체의 연속된 순환을 병렬로 진행하기 위해 사용하는 키워드가 yield이다.

/*
            // 기존의 존재하던 클래스로 함수를 만들경우 자동으로 동일한 형태의 함수로 제작된다.
            // 유니티에서 코루틴 다룰 때 자주 쓴다고 함.
            IEnumerator count = Counter();sss
            count.MoveNext();
            count.MoveNext();
            count.MoveNext();
*/

        }
/*
        static IEnumerator Counter()
        {
            int counter = 0 ;
            while(true)
            {
                Console.WriteLine("counter는 : " + counter++);
                yield return null;
            }

            for (int i = 0; i<3; i++)
            {
                Console.WriteLine("무언가 진행했다. 값은 : " + i);
                yield return i;
                // yield : 프로그램의 흐름을 밖으로 전달하고 잠시 대기하겠다.
            }

        }
*/

    }
}