namespace L.Pathogen
{
    public class DataPathogen:SinglePathogen
    {
        /// <summary>
        /// 解析器
        /// </summary>
        private IProcessor _processor;
        /// <summary>
        /// 数据读取接口
        /// </summary>
        private IDataReaderProcessor _dataReaderProcessor;

        public DataPathogen(IProcessor processor,IDataReaderProcessor dataReaderProcessor):
            base(processor)
        {
            _processor = processor;
            _dataReaderProcessor = dataReaderProcessor;

        }
        /// <summary>
        /// 设置感染目标
        /// </summary>
        public void SetInfectionTargets()
        {
            foreach (var target in _dataReaderProcessor.Reader())
            {
                //入栈
                Targets.Enqueue(target);
            }
        }
    }
}