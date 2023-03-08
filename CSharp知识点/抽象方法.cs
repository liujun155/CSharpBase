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
     * 
     * 抽象类和普通类的区别：
     * 1、实例化：普通类可以直接被实例化，而抽象类不能被实例化，只能被继承。
     * 2、方法实现：普通类中的所有方法都有默认实现，而抽象类中可以包含抽象方法，这些方法只有定义，没有实现，需要在子类中进行具体实现。
     * 3、继承：普通类可以被普通类或抽象类继承，而抽象类只能被继承，不能被实例化。
     * 4、多态性：抽象类的抽象方法可以被子类实现，从而实现多态性，而普通类的方法也可以实现多态性，但需要通过虚方法或接口来实现。
     * 抽象类和接口的区别：
     * 1、实现方式：抽象类是一种类，而接口是一种接口。抽象类可以包含字段、方法和属性，而接口只能包含方法和属性的定义。
     * 2、实现要求：抽象类中的方法可以有实现，也可以没有实现，而接口中的方法都没有实现，必须在实现接口的类中进行具体实现。
     * 3、实现数量：一个类只能继承一个抽象类，但可以实现多个接口。因此，使用接口可以实现更灵活的多继承。
     * 4、设计目的：抽象类通常用于表示一种抽象的概念或者基类，而接口通常用于描述一组相关的操作或者功能。
     */

    // ---抽象类---
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

    // ---接口---
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
