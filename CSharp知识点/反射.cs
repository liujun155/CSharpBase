using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    public static class Reflection
    {
        public static void ReflectionMethod()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();//获取当前程序集
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
