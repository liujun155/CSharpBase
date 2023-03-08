using System;
using System.Threading;

namespace CSharp知识点
{
    /**
     * 委托是一种类型，它可以用来引用一个或多个方法。
     * 委托定义了一个函数的签名，然后可以用该委托类型的实例引用该函数。
     * 这样，可以将委托实例作为参数传递给另一个函数，并在另一个函数中调用该委托。
     * 使用场景：
     * 1、回调方法：当一个事件发生时，需要调用一个或多个方法来响应该事件。通过委托可以将这些方法作为参数传递给事件处理程序，以便在事件发生时调用这些方法。
     * 2、异步编程：当需要异步执行一些方法并在执行完成后通知调用方时，可以使用异步委托来实现。例如，使用BeginInvoke和EndInvoke方法来启动和完成异步方法的执行。
     * 3、泛型编程：使用泛型委托可以使代码更具有可重用性和灵活性。例如，Func和Action委托是泛型委托，它们可以用来表示各种不同类型的方法。
     * 4、LINQ查询：使用委托可以定义一个查询操作，以便在运行时确定要查询的数据。
     * 5、事件处理：使用委托可以将一个或多个方法绑定到事件处理程序，以便在事件发生时自动调用这些方法。
     */

    #region 简单委托
    public class SimpleDelegate
    {
        delegate void IntDelegate(int x);

        public static void Run()
        {
            IntDelegate del = new IntDelegate(PrintInt);

            del.Invoke(5);
        }

        static void PrintInt(int x)
        {
            Console.WriteLine("数字是：" + x);
        }
    }
    #endregion

    #region 泛型委托
    delegate TResult MyFunc<T, TResult>(T arg);

    public class GenericDelegateExample
    {
        public static void Run()
        {
            MyFunc<int, string> myFunc = new MyFunc<int, string>(ConvertToString);

            Console.WriteLine(myFunc.Invoke(15));
        }

        static string ConvertToString(int arg)
        {
            return arg.ToString();
        }
    }
    #endregion

    #region 复杂委托
    // 定义一个委托类型，它可以表示一个参数为int，返回值为bool的方法
    delegate bool IntPredicate(int x);

    public class ComplexDelegate
    {
        public static void Run()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            // 使用Where方法和委托实例过滤数组中的元素
            int[] evenNumbers = Where(numbers, IsEven);

            // 输出过滤后的数组
            Console.WriteLine("Even numbers:");
            foreach (int n in evenNumbers)
            {
                Console.WriteLine(n);
            }

            // 使用Where方法和匿名方法过滤数组中的元素
            int[] bigNumbers = Where(numbers, delegate (int x)
            {
                return x > 3;
            });

            // 输出过滤后的数组
            Console.WriteLine("Big numbers:");
            foreach (int n in bigNumbers)
            {
                Console.WriteLine(n);
            }

            // 使用Where方法和Lambda表达式过滤数组中的元素
            int[] smallNumbers = Where(numbers, x => x < 3);

            // 输出过滤后的数组
            Console.WriteLine("Small numbers:");
            foreach (int n in smallNumbers)
            {
                Console.WriteLine(n);
            }
        }

        // 这是一个静态方法，它接收一个int类型的数组和一个IntPredicate类型的委托实例，返回值为一个int类型的数组
        static int[] Where(int[] array, IntPredicate predicate)
        {
            // 创建一个新的数组，用于存储过滤后的元素
            int[] result = new int[array.Length];
            int index = 0;

            // 遍历数组中的元素，并使用委托实例对每个元素进行判断
            foreach (int n in array)
            {
                if (predicate(n))
                {
                    result[index] = n;
                    index++;
                }
            }

            // 返回过滤后的数组，其中只包含符合条件的元素
            int[] filteredResult = new int[index];
            Array.Copy(result, filteredResult, index);
            return filteredResult;
        }

        // 这是一个静态方法，它接收一个int类型的参数，返回值为bool
        static bool IsEven(int x)
        {
            return x % 2 == 0;
        }
    }

    #endregion

    #region Invoke和BeginInvoke
    //Invoke方法是同步调用，会阻塞当前线程直到委托执行完成并返回结果。如果委托执行时间较长，可能会导致应用程序的响应性下降。
    //BeginInvoke方法是异步调用，不会阻塞当前线程。它会在另一个线程上执行委托实例，并立即返回IAsyncResult对象，以便在后续的某个时间点查询委托是否执行完成。可以使用EndInvoke方法来获取委托的返回值，或者在异步操作完成时回调一个方法。
    //.Net Core中不支持BeginInvoke方法，建议用Task 和 async/await
    public class InvokeExample
    {
        public static void Run()
        {
            // 创建一个委托实例
            Action<int> action = i => Console.WriteLine($"线程{i}开始执行");

            // 使用Invoke方法同步调用委托
            Console.WriteLine("同步调用委托开始");
            action.Invoke(1);
            action.Invoke(2);
            Console.WriteLine("同步调用委托结束");

            // 使用BeginInvoke方法异步调用委托
            Console.WriteLine("异步调用委托开始");
            //action.BeginInvoke(3, ar =>
            //{
            //    Console.WriteLine($"线程{Thread.CurrentThread.ManagedThreadId}完成异步调用");
            //}, null);
            //action.BeginInvoke(4, ar =>
            //{
            //    Console.WriteLine($"线程{Thread.CurrentThread.ManagedThreadId}完成异步调用");
            //}, null);
            Task.Run(() => action.Invoke((int)Task.CurrentId)).ContinueWith(t => Console.WriteLine($"线程{t.Id}完成异步调用")).Wait();
            Task.Run(() => action.Invoke((int)Task.CurrentId)).ContinueWith(t => Console.WriteLine($"线程{t.Id}完成异步调用")).Wait();
            Console.WriteLine("异步调用委托结束");
        }
    }
    #endregion

    #region 回调函数
    delegate void CallbackFunc(string message);

    public class CallbackExample
    {
        public static void Run()
        {
            // 回调函数绑定方法
            CallbackFunc callback = new CallbackFunc(PrintMessage);

            DoSomething("Hello Callback", callback);
        }

        // 定义带回调函数的方法
        static void DoSomething(string message, CallbackFunc callback)
        {
            callback(message);
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine($"Callback: {message}");
        }
    }
    #endregion
}

