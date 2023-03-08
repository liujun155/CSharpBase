using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    //泛型常见的实际应用场景：
    //1、数据结构：泛型可以用于构建各种数据结构，如列表、堆栈、队列、字典等。例如，在实现一个通用的缓存类时，可以使用泛型来存储缓存的值，以及根据需要指定缓存的类型。
    //2、数据访问层：泛型可以用于数据访问层，例如，可以编写一个通用的仓储库类，以便在不同的实体上执行CRUD操作。
    //3、算法和数据处理：泛型可以用于实现各种算法和数据处理操作。例如，在处理集合中的数据时，可以使用泛型来指定操作的数据类型，这样就可以避免在运行时进行类型转换。
    //4、事件和委托：泛型可以用于事件和委托，以便在定义事件和委托时指定它们所使用的类型。这样可以避免在事件和委托处理程序中进行类型转换。

    #region 1.数据结构
    // 定义一个泛型列表类
    public class MyList<T>
    {
        private List<T> items = new List<T>();

        public void Add(T t)
        {
            items.Add(t);
        }

        public T Get(int index)
        {
            return items[index];
        }

        //...
    }

    public class GenericExample1
    {
        public static void Run()
        {
            // 使用泛型列表存储字符串
            var myStringList = new MyList<string>();
            myStringList.Add("apple");
            myStringList.Add("banana");
            string item = myStringList.Get(0); // "apple"

            // 使用泛型列表存储整数
            var myIntList = new MyList<int>();
            myIntList.Add(1);
            myIntList.Add(2);
            int item2 = myIntList.Get(0); // 1
        }
    }
    #endregion

    #region 2.数据访问层
    // 定义一个泛型仓储库类
    public class Repository<T>
    {
        public void Add(T entity)
        {
            // 将实体添加到数据库
        }

        public void Update(T entity)
        {
            // 更新实体在数据库中的记录
        }

        public void Delete(T entity)
        {
            // 从数据库中删除实体
        }

        // ...
    }

    public class GenericExample2
    {
        public static void Run()
        {
            // 使用泛型仓储库操作不同的实体
            //var userRepository = new Repository<User>();
            //var orderRepository = new Repository<Order>();
            //userRepository.Add(new User());
            //orderRepository.Delete(new Order());
        }
    }
    #endregion

    #region 3.算法和数据处理
    public class GenericExample3
    {
        // 使用泛型实现一个通用的最大值函数
        public static T Max<T>(T a, T b) where T : IComparable
        {
            if (a.CompareTo(b) > 0)
                return a;
            else
                return b;
        }

        public static void Run()
        {
            // 使用泛型最大值函数比较不同类型的值
            int maxInt = Max(1, 2); // 2
            double maxDouble = Max(1.0, 2.0); // 2.0
            string maxString = Max("apple", "banana"); // "banana"
        }
    }
    #endregion

    #region 4.事件和委托
    // 定义一个泛型事件委托
    delegate void MyEventHandler<T>(T arg);

    // 定义一个泛型事件类
    class MyEvent<T>
    {
        private MyEventHandler<T> handlers;

        public event MyEventHandler<T> Event
        {
            add { handlers += value; }
            remove { handlers -= value; }
        }

        public void Raise(T arg)
        {
            handlers?.Invoke(arg);
        }
    }

    public class GenericExample4
    {
        public static void Run()
        {
            // 使用泛型事件和委托处理不同类型的数据
            var myStringEvent = new MyEvent<string>();
            myStringEvent.Event += s => Console.WriteLine($"Received string: {s}");
            myStringEvent.Raise("hello"); // 输出：Received string: hello

            var myIntEvent = new MyEvent<int>();
            myIntEvent.Event += i => Console.WriteLine($"Received int: {i}");
            myIntEvent.Raise(123); // 输出：Received int: 123
        }
    }
    #endregion
}
