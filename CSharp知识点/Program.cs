using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region ----------重写、隐藏----------
            Console.WriteLine("----------重写、隐藏----------");
            A a = new B();
            B b = new B();
            Console.WriteLine("====A a = new B()====");
            a.SaySomething();
            a.EatFood();
            Console.WriteLine("====B b = new B()====");
            b.SaySomething();
            b.EatFood();
            #endregion

            #region ----------算法题----------
            Console.WriteLine("\n----------算法题----------");
            Console.WriteLine("冒泡排序：");
            int[] nums = { 5, 7, 1, 11, 9, 4, 3, 2, 10, 19, 15 };
            CalculateClass.BubbleSort(nums);

            Console.WriteLine("计算字符串中字符个数：");
            CalculateClass.CountChar("aaaabbbbcdefffffffffffAAAAAAA");

            Console.WriteLine("计算斐波那契数列：");
            foreach (int i in CalculateClass.Foo2(10))
            {
                Console.WriteLine(i.ToString());
            }
            //非递归算法
            //foreach (int i in CalculateClass.Fibonacci2(10))
            //{
            //    Console.WriteLine(i.ToString());
            //}
            #endregion

            #region ----------yield return----------
            Console.WriteLine("\n----------yield return----------");
            foreach (var item in YieldReturn.FilterWithYield(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }))
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 抽象方法
            //AbstractClass abstractClass = new AbstractClassChild();
            //Console.WriteLine(abstractClass.Calculate(1, 2));

            //Person person = new Person();
            //person.Name = "小王";
            //person.Eat();
            #endregion

            #region ----------泛型----------
            Console.WriteLine("\n----------泛型----------");
            string str = "我是泛型";
            var genericClass = new GenericClass<String>();
            genericClass.DoMethod(str);
            #endregion

            #region ----------特性----------
            Console.WriteLine("\n----------特性----------");
            CustomAttribute.Run();
            #endregion

            #region ----------反射----------
            //Reflection.ReflectionMethod();
            #endregion

            #region ----------序列化----------
            Console.WriteLine("\n----------序列化----------");
            JsonSerializeExample.Run();
            XmlSerializeExample.Run();
            #endregion

            #region ----------委托----------
            Console.WriteLine("\n----------委托----------");
            SimpleDelegate.Run();
            Console.WriteLine("复杂委托：");
            ComplexDelegate.Run();
            Console.WriteLine("泛型委托：");
            GenericDelegateExample.Run();
            Console.WriteLine("Invoke方法：");
            InvokeExample.Run();
            Console.WriteLine("回调函数：");
            CallbackExample.Run();
            #endregion

            #region ----------多线程----------
            //TaskDemo taskDemo = new TaskDemo();
            #endregion

            #region ----------线程安全----------
            //Console.WriteLine("\n----------线程安全----------");
            //MutexDemo.Run();
            #endregion

            #region HTTP请求
            Console.WriteLine("\n----------HTTP请求----------");
            Console.WriteLine("HttpWebRequest方式：");
            var res = HttpWebRequestClass.Get<string>(@"https://api.uomg.com/api/comments.163?format=text");
            Console.WriteLine(res);
            Console.WriteLine("HttpClient方式：");
            var res1 = HttpClientClass.Instance.Get<string>(@"https://api.uomg.com/api/comments.163?format=text");
            Console.WriteLine(res1);
            #endregion

            Console.ReadLine();
        }
    }
}
