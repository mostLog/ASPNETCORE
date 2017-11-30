using System;
using System.Collections.Generic;
using System.Text;

namespace L.Pathogen
{
    public class UrlPathogen : SinglePathogen
    {
        
        public UrlPathogen(IProcessor processor) : 
            base(processor)
        {

        }
        /// <summary>
        /// 设置感染目标
        /// </summary>
        public void SetInfectionTargets(IList<InfectionTarget> targets)
        {
            foreach (var target in targets)
            {
                Targets.Enqueue(target);
            }
        }
    }
}
