using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    public class CalculateClass
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
        }

        #region 排序获取索引列表
        public static List<int> GetSortIndex(int[] arr)
        {
            return arr.Select((num, index) => new { num, index })
                .OrderBy(item => item.num)
                .Select(item => item.index)
                .ToList();
        }
        #endregion

        /*一列数的规则如下 : 1 、 1 、 2 、 3 、 5 、 8 、 13 、 21 、 34… 求第 30 位数是多少，用递归算法实现*/
        public static int Foo(int i)
        {
            if (i <= 0) return 0;
            else if (i > 0 && i <= 2) return 1;
            else return Foo(i - 1) + Foo(i - 2);
        }
        public static IEnumerable<int> Foo2(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                yield return Foo(i);
            }
        }
        // 非递归算法
        public static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            int a = 0, b = 1, c = 0;
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
        public static IEnumerable<int> Fibonacci2(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                yield return Fibonacci(i);
            }
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
        }
    }
}
