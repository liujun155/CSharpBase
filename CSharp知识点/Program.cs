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
            //B b = new B();
            //A a = new B();
            //a.SaySomething();
            //a.EatFood();
            //b.SaySomething();
            //b.EatFood();
            #endregion

            #region ----------算法题----------
            //int[] nums = { 5, 7, 1, 11, 9, 4, 3, 2, 10, 19, 15 };
            //BubbleSort(nums);

            //CountChar("aaaabbbbcdefffffffffffAAAAAAA");

            //foreach (int i in CalculateClass.Foo2(10))
            //{
            //    Console.WriteLine(i.ToString());
            //}
            #endregion

            #region ----------yield return----------
            //foreach (var item in YieldReturn.FilterWithYield(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }))
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 抽象方法
            //AbstractClass abstractClass = new AbstractClassChild();
            //Console.WriteLine(abstractClass.Calculate(1, 2));

            //Person person = new Person();
            //person.Name = "小王";
            //person.Eat();
            #endregion

            #region ----------泛型----------
            //string str = "我是泛型";
            //var methodClass = new MethodClass<String>();
            //methodClass.DoMethod(str);
            #endregion

            Console.ReadLine();
        }
    }
}
