using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    /**
     * 抽象类可以包含：抽象方法、抽象属性、具体方法和具体属性
     * 抽象类不能实例化
     * 接口只能包含方法的声明
     */
    public abstract class AbstractClass
    {
        string name = "111";//可包含实例字段
        public abstract int Calculate(int a, int b);
    }

    public class AbstractClassChild : AbstractClass
    {
        public override int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    public interface IPerson
    {
        string Name { get; set; }
        void Eat();
    }

    public class Person : IPerson
    {
        public string Name { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name}吃饭了");
        }
    }
}
