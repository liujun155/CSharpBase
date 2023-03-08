using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    /**
     * 反射（Reflection）是指在运行时获取类型的信息、访问对象属性、调用对象方法，并动态地操作它们。
     * 反射提供了在编译时无法获得的程序元数据，例如类型、成员、属性和方法等信息。
     * 它可以让程序在运行时动态地创建对象、调用方法和访问属性等，使程序更加灵活和可扩展。
     * 优点：
     * 1、反射提高了程序的灵活性和扩展性。
     * 2、降低耦合性，提高自适应能力。
     * 3、它允许程序创建和控制任何类的对象，无需提前硬编码目标类。
     * 缺点：
     * 1、性能问题：使用反射基本上是一种解释操作，用于字段和方法接入时要远慢于直接代码。因此反射机制主要应用在对灵活性和拓展性要求很高的系统框架上，普通程序不建议使用。
     * 2、使用反射会模糊程序内部逻辑；程序员希望在源代码中看到程序的逻辑，反射却绕过了源代码的技术，因而会带来维护的问题，反射代码比相应的直接代码更复杂。
     * 常见的应用场景：
     * 1、动态加载程序集：反射可以通过程序集名称或文件路径来动态加载程序集，并获取程序集中的类型信息和成员信息，实现动态的程序集加载和卸载。
     * 2、插件机制：反射可以通过扫描指定目录中的程序集，获取其中的插件类型，并实例化插件对象，实现插件化的架构设计。
     * 3、序列化和反序列化：反射可以通过获取对象的类型信息，实现将对象转换为 XML 或 JSON 格式的字符串，以及将 XML 或 JSON 格式的字符串转换为对象的过程。
     * 4、ORM 映射：反射可以通过获取对象的类型信息和成员信息，实现对象与数据库表之间的映射，使得开发者可以通过面向对象的方式来操作数据库。
     * 5、AOP 面向切面编程：反射可以通过获取对象类型和方法信息，实现动态代理，从而在方法执行前后插入自定义的逻辑，实现 AOP 编程。
     */

    public static class Reflection
    {
        public static void ReflectionMethod()
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); //获取当前程序集
            Type[] types = assembly.GetTypes(); //获取程序集中所有类型
            foreach (var type in types)
            {
                if (type.Name == "ReflectionEnt")
                {
                    object obj = Activator.CreateInstance(type); //实例化
                    MethodInfo methodInfo = type.GetMethod("Score"); //获取方法
                    var result = methodInfo.Invoke(obj, new object[2] { 10, 10 }); //执行方法
                }
            }
        }

    }

    internal class ReflectionEnt
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public ReflectionEnt()
        {
            Name = "张三";
            Age = 18;
        }

        public ReflectionEnt(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Score(int a, int b)
        {
            return a + b;
        }
    }
}
