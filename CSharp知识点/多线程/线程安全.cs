using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp知识点
{
    //线程安全是指在多线程环境下，保证程序的正确性和稳定性。在多线程环境下，多个线程同时访问共享资源时，可能会出现竞态条件（Race Condition），导致数据不一致或者程序崩溃。为了保证线程安全，需要采取一些措施，例如：
    //1、使用互斥量（Mutex）或者信号量（Semaphore）来保证临界区代码的互斥访问，避免多个线程同时访问共享资源。
    //2、使用锁（Lock）关键字来对共享资源进行加锁，保证每次只有一个线程能够访问共享资源。
    //3、使用线程安全的集合类，例如 ConcurrentDictionary、ConcurrentQueue、ConcurrentStack 等，它们内部实现了线程同步机制，可以在多线程环境下安全地访问共享资源。
    //4、使用原子操作，例如 Interlocked 类提供的原子操作方法，可以在不使用锁的情况下实现线程安全。
    //具体实现方式取决于具体的应用场景和需求。在实现线程安全时，需要考虑多个线程同时访问共享资源的情况，避免出现竞态条件，同时要保证程序的性能和效率。如果没有必要，应尽量避免使用锁或者其他线程同步机制，以提高程序的并发能力和性能。

    #region Mutex
    public class MutexDemo
    {
        static Mutex mutex = new Mutex();

        public static void Run()
        {
            Console.WriteLine("Mutex加锁：");
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(DoWork);
                t.Start(i);
            }
        }

        static void DoWork(object id)
        {
            Console.WriteLine("线程 {0} 正在等待锁", id);
            // 等待锁
            mutex.WaitOne();
            Console.WriteLine("线程 {0} 已获取锁", id);
            // 模拟访问共享资源
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("线程 {0} 正在访问共享资源", id);
                Thread.Sleep(100);
            }
            // 释放锁
            mutex.ReleaseMutex();
            Console.WriteLine("线程 {0} 已释放锁", id);
        }
    }
    #endregion
}
