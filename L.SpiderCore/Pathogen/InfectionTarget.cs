using System;
using System.Collections.Generic;
using System.Text;

namespace L.Pathogen
{
    /// <summary>
    /// 感染目标
    /// </summary>
    public class InfectionTarget
    {
        /// <summary>
        /// 感染目标地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 附加对象
        /// </summary>
        public object ExtraObj { get; set; }
    }
}
