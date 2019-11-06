using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace log4net.Kafka.Core.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new LoggerFactory()
                            .AddLog4Net()
                            .CreateLogger(nameof(Program));

            logger.LogInformation("这是一条普通日志");

            logger.LogDebug("这是一条 Debug 日志");

            logger.LogWarning("这是一条警告日志");

            logger.LogError("这是一条错误日志");
            //LogMessage log = new LogMessage();
            //log.trace_id = "1000";
            //log.trace_type = "查询";
            //logger.LogError(JsonConvert.SerializeObject(log));
            //LogMessage log1 = new LogMessage();
            //log.trace_id = "1001";
            //log.trace_type = "删除";
            //logger.LogError(JsonConvert.SerializeObject(log1));
            try
            {
                throw new DivideByZeroException();
            }
            catch (Exception ex)
            {
                logger.LogTrace(ex, "这是一条异常日志");
            }
           

            Task[] tasks = new Task[3];
            for (int i = 0; i < 3; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => testTask(i, logger));
            }
            Task.WaitAll(tasks);

            Console.WriteLine("结束写入");
            Console.ReadKey();
        }
        public static void testTask(int n, ILogger logger)
        {
            for (int i = 0; i < 100; i++)
            {
                logger.LogWarning($"任务{n}执行第{i}-EHS我是Info");
                logger.LogError($"任务{n}执行第{i}-EHS我是Error");
            }

        }
    }
  
    /// <summary>
    /// Kafka 参数配置
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// 跟踪ID
        /// </summary>
        public string trace_id { get; set; }

        /// <summary>
        /// 跟踪类型
        /// </summary>
        public string trace_type { get; set; }
    }
}
