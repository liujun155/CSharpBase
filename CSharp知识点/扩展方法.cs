using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    /**
     * 扩展方法所在的类必须声明为static
     * 扩展方法必须声明为public和static
     * 扩展方法的第一个参数必须包含关键字this，并且在后面指定扩展的类的名称
     */
    public static class ExtendMethod
    {
        public static int StringToInt(this string str)
        {
            return Convert.ToInt32(str);
        }

        public static int Sum(this int num1, int num2)
        {
            return num1 + num2;
        }
    }

    public class TestExtendMethod
    {
        public TestExtendMethod()
        {
            string s = "111";
            s.StringToInt();

            int i = 1.Sum(2);
        }
    }
}
