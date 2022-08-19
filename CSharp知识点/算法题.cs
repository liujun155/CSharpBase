using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    public static class CalculateClass
    {
        /*冒泡排序(升序)*/
        public static void BubbleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
                Console.WriteLine(nums[i]);
            }
            Console.ReadLine();
        }

        /*一列数的规则如下 : 1 、 1 、 2 、 3 、 5 、 8 、 13 、 21 、 34… 求第 30 位数是多少，用递归算法实现*/
        public static int Foo(int i)
        {
            if (i <= 0) return 0;
            else if (i > 0 && i <= 2) return 1;
            else return Foo(i - 1) + Foo(i - 2);
        }

        /*计算字符串中每个字符个数*/
        public static void CountChar(string str)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }
            foreach (var dicItem in dic)
            {
                Console.WriteLine($"字符：{dicItem.Key},数量：{dicItem.Value}个");
            }
            Console.ReadLine();
        }
    }
}
