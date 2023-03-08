using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    /**
     * 定义：泛型允许我们延迟编写类或方法中的编程元素的数据类型的规范，直到实际在程序中使用它的时候。
     * （也就是说泛型是可以与任何数据类型一起工作的类或方法）模块内高内聚，模块间低耦合。
     * 当我们的类/方法不需要关注调用者传递的实体是什么(公共基类工具类)，这个时候就可以使用泛型
     * 
     * 为何不使用object？
     * object类型参数有2个问题：
     * 装箱拆箱，性能损耗传入一个int值(栈)object又在堆里面，如果把int传递进来，就会把值从栈里面copy到堆里使用的时候，又需要用对象值，又会copy到栈(拆箱)
     * 类型安全问题，可能会有，因为传递的对象是没有限制的
     */
    public class Generic
    {
        // 泛型方法
        public static void Test<T>(T value)
        {
            Console.WriteLine(value);
        }

        // 泛型约束
        /**
         * where T:base-class   //表示必须是某个父类的子类
         * where T:interface    //表示必须实现某个接口，当然一般这样自身就是类
         * where T:class        //表示必须是引用类型
         * where T:struct       //表示必须是值类型，不包括可空类型
         * where T:new()        //表示必须有一个无参数的构造函数
         * where U:T            //U必须继承于T
         */
        public static void Test2<T>(T value) where T : new()
        {
            Console.WriteLine(value);
        }

        public Generic()
        {
            Test2(this);
        }
    }

    public class GenericClass<T>
    {
        public void DoMethod(T t)
        {
            Console.WriteLine(t.ToString());
        }
    }
}
