using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace log4net.Kafka.FrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建文件对象
            ILog log = LogManager.GetLogger("log4netDemo");
            log.Info($"任务1执行第1-erp我是Info");
            log.Info($"任务1执行第1-erp我是Error");
            Task[] tasks = new Task[3];
            for (int i = 0; i < 3; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => testTask(i, log));
            }
            Task.WaitAll(tasks);


            Console.WriteLine("结束写入");
            Console.ReadKey();
        }
        public static void testTask(int n, ILog log)
        {
            for (int i = 0; i < 100; i++)
            {
                log.Info($"任务{n}执行第{i}-erp我是Info");
                log.Info($"任务{n}执行第{i}-erp我是Error");
            }
            
        }
    }
    }
