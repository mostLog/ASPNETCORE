using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace L.LCore.Logger
{
    public class LogEnqueManager
    {
        public readonly static LogEnqueManager Instance = new LogEnqueManager();
        private LogEnqueManager()
        { }
        private Queue<Func<int>> listQueue = new Queue<Func<int>>();
        /// <summary>
        /// 添加入列
        /// </summary>
        /// <param name="action"></param>
        public void AddQueue(Func<int> func)
        {
            listQueue.Enqueue(func);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Start()//启动  
        {
            var task=Task.Factory.StartNew(()=> {
                while (true)
                {
                    if(listQueue.Count>0)
                    {
                        var log = listQueue.Dequeue();
                        var r= log();
                        if (r>0)
                        {
                            continue;
                        }
                    }else
                    {
                        Thread.Sleep(3000);
                    }
                }
            });
        }
    }
}
