using System;
using System.Collections.Generic;
using System.Text;

namespace L.Pathogen
{
    /// <summary>
    /// 病原体工厂
    /// </summary>
    public class PathogenFacotry
    {
        /// <summary>
        /// 根据id获取病原体
        /// </summary>
        /// <param name="pathogenKey"></param>
        /// <returns></returns>
        public static IPathogen GetPathogenInstance(string pathogenKey, IList<InfectionTarget> targets=null)
        {
            switch (pathogenKey)
            {
                case "ArticlePathogen":
                    var articlePathogen=new DataPathogen(new ArticleProcessor(),new ArticleDataReaderProcessor());
                    articlePathogen.SetInfectionTargets();
                    return articlePathogen;
                default:

                    break;
            }
            return null;
        }

    }
}
