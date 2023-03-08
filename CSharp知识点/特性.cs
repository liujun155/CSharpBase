using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    /**
     * 特性（Attribute）是一种注释代码的方法，可以为程序元素（如类、方法、属性等）添加元数据信息，以提供额外的信息或指示如何处理这些元素。
     */

    #region 预定义特性
    /**
     * 常见的预定义特性及其作用：
     *  1.[Obsolete] 特性：用于标记已过时的代码元素，编译器会给出警告或错误提示。
     *  2.[Serializable] 特性：用于标记可序列化的类型，表明该类型可以被序列化到二进制流或XML等格式中。
     *  3.[Conditional] 特性：用于标记条件编译的代码块，只有在指定的编译器宏定义被定义时才会编译这段代码。
     *  4.[DllImport] 特性：用于调用非托管代码库中的函数。
     *  5.[AttributeUsage] 特性：用于定义自定义特性的使用方式，比如可以定义该特性只能用于类或方法等代码元素中。
     *  6.[WebMethod] 特性：用于标记 Web 服务中的方法。
     *  7.[DataContract] 和 [DataMember] 特性：用于标记 WCF 服务中的数据类型和成员，用于序列化和反序列化操作。
     *  8.[Authorize] 特性：用于标记需要授权访问的方法或类。
     *  9.[TestMethod] 特性：用于标记单元测试中的测试方法。
     * 10.[DebuggerStepThrough] 特性：用于标记调试器跳过该代码块的步骤。
     */

    public class ObsoleteExample
    {
        [Obsolete("Don't use OldMethod, use NewMethod instead", true)]
        static void OldMethod()
        {
            Console.WriteLine("It is the old method");
        }
        static void NewMethod()
        {
            Console.WriteLine("It is the new method");
        }
        public static void Run()
        {
            //OldMethod();
        }
    }
    #endregion

    #region 自定义特性
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class LogTimeAttribute : Attribute
    {
        Stopwatch _stopwatch;

        public void OnEntry()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnExit()
        {
            _stopwatch.Stop();
            Console.WriteLine($"Method execution time: {_stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public class CustomAttribute
    {
        [LogTime]
        public static void Run()
        {
            Console.WriteLine("Hello, world!");
        }
    }
    #endregion
}
