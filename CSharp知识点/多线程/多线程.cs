using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp知识点
{
    public class TaskDemo
    {
        //声明CancellationTokenSource对象
        CancellationTokenSource cts = new CancellationTokenSource();

        //public TaskDemo()
        //{
        //    Console.WriteLine("==========取消单个任务==========");

        //    //将cts.Token传入任务中，在外部通过控制cts实现对任务的控制
        //    Task.Run(MyTask, cts.Token);

        //    Console.WriteLine("请按回车键停止");
        //    Console.ReadLine();

        //    cts.Cancel();//传达取消请求

        //    Console.WriteLine("已停止");
        //    Console.ReadLine();
        //}

        //void MyTask()
        //{
        //    //判断任务是否取消，如果取消则跳出本次循环
        //    while (!cts.IsCancellationRequested)
        //    {
        //        Console.WriteLine("当前时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        //        Thread.Sleep(1000);
        //    }
        //}

        public TaskDemo()
        {
            TaskMethod();

            Console.WriteLine("请按回车键停止");
            Console.ReadLine();

            cts.Cancel();//传达取消请求

            Console.WriteLine("已停止");
            Console.ReadLine();
        }

        private async void TaskMethod()
        {
            while (true)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        Console.WriteLine("当前时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        Thread.Sleep(1000);
                    }, cts.Token);
                }
                catch (TaskCanceledException ex)
                {
                }
            }
        }
    }
}
