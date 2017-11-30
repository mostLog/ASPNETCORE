using System;
using System.Collections.Generic;
using System.Text;

namespace L.Pathogen
{
    /// <summary>
    /// 病原体接口
    /// </summary>
    public interface IPathogen
    {
        /// <summary>
        /// 感染
        /// </summary>
        /// <param name="url">感染地址</param>
        void Infected();
    }
}
