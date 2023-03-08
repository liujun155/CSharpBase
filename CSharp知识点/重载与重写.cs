using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    /**
     * sealed密封类不可被继承
     * 重载：方法名相同，参数不同，返回结果可以不同
     * 重写：子类重写父类方法，父类虚方法virtual表示可以被重写，父类私有方法不可被重写
     */
    public class A
    {
        #region 重载
        private void DoIt()
        {
            // TODO
        }
        private int DoIt(string thing)
        {
            // TODO
            return 0;
        }
        #endregion

        public virtual void SaySomething()
        {
            Console.WriteLine("Hello");
        }

        public void EatFood()
        {
            Console.WriteLine("吃东西");
        }
    }

    public class B : A
    {
        public override void SaySomething()
        {
            Console.WriteLine("Bye");
        }

        /* new代表隐藏父类方法，调用后执行子类方法 */
        public new void EatFood()
        {
            Console.WriteLine("不吃东西");
        }
    }
}
