using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace L.Pathogen
{
    public class SinglePathogen : IPathogen
    {
        /// <summary>
        /// 解析器
        /// </summary>
        private IProcessor _processor;
        /// <summary>
        /// 开启线程数
        /// </summary>
        private Task[] _task;
        /// <summary>
        /// 线程是否休眠
        /// </summary>
        private bool[] _taskIsSleep;
        /// <summary>
        /// 感染目标队列
        /// </summary>
        protected Queue<InfectionTarget> Targets { get; set; }

        public SinglePathogen(IProcessor processor)
        {
            _processor = processor;
            //初始化队列
            Targets = new Queue<InfectionTarget>();
            //开启10个线程
            _task = new Task[10];
            //对应10个状态
            _taskIsSleep = new bool[10];
        }
        /// <summary>
        /// 感染
        /// </summary>
        /// <param name="url"></param>
        public virtual void Infected()
        {
            //初始化线程数
            for (int i = 0; i < _task.Length; i++)
            {
                _task[i] = new Task(Request,i);
            }
            //启动
            for (int j = 0; j < _task.Length; j++)
            {
                _task[j].Start();
                _taskIsSleep[j] = false;
            }
        }

        public void Request(object i)
        {
            //当前线程索引
            int currThreadIndex = (int)i;
            while (true)
            {
                //抓取目标数量为0
                if (Targets.Count == 0)
                {
                    _taskIsSleep[currThreadIndex] = true;
                    //如果全部休眠
                    if (_taskIsSleep.Any(c=>c==true))
                    {
                        Debug.Write("爬取结束！");
                        break;
                    }
                    Thread.Sleep(2000);
                    continue;
                }
                _taskIsSleep[currThreadIndex] = false;
                if (Targets.Count==0)
                {
                    continue;
                }
                //取目标
                var target=Targets.Dequeue();
                //创建请求对象
                var request = InfectionManager.CreateRequest(new InfectionConfig() { Url = target.Url});
                //获取请求响应
                var pagePathogen = InfectionManager.GetResponse(request);
                if (pagePathogen!=null)
                {
                    //页面解析
                    _processor.PageProcess(pagePathogen);
                    //是否传递附加参数
                    if (target.ExtraObj != null)
                    {
                        pagePathogen.AddResult("extraObj", target.ExtraObj);
                    }
                    //数据解析
                    _processor.DataProcess(pagePathogen.ResultList);
                }
            }
        }
    }
}