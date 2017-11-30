using System.Collections.Generic;

namespace L.Pathogen
{
    /// <summary>
    /// 数据解析器
    /// </summary>
    public interface IProcessor
    {
        /// <summary>
        /// 页面解析
        /// </summary>
        /// <param name="pagePathogen"></param>
        void PageProcess(PagePathogen pagePathogen);
        /// <summary>
        /// 数据解析
        /// </summary>
        /// <param name="resultDatas"></param>
        void DataProcess(IDictionary<string,object> resultDatas);
        
    }
}
