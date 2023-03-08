using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    /**
     * 主要用于定义迭代器
     * yield return 用于可遍历的数组的数据返回，不会退出当前方法体，直接将结果返回后再继续执行方法
     * 和普通return的区别：普通return是把结果集全部加载到内存中再遍历
     * yield return是客户端每调用一次，yield return就返回一个值给客户端，是"按需供给"
     * 
     * 简易概括：yield就是一个一个返回，提升性能
     */
    public static class YieldReturn
    {
        /* IEnumerable声明迭代器，以实现foreach方法，迭代器方法不可使用return返回 */
        public static IEnumerable<int> FilterWithYield(List<int> nums)
        {
            foreach (int num in nums)
            {
                if (num > 2)
                    yield return num;
            }
            yield break;
        }
    }
}
