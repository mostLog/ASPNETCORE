using L.LCore.Infrastructure;

namespace L.LCore
{
    public class LCoreEngineManager
    {
        /// <summary>
        /// 创建引擎
        /// </summary>
        /// <returns></returns>
        public static ILCoreEngine CreateEngine()
        {
            if (Singleton<ILCoreEngine>.Instance == null)
            {
                Singleton<ILCoreEngine>.Instance= new LCoreEngine();
            }
            return Singleton<ILCoreEngine>.Instance;
        }
        /// <summary>
        /// 获取当前引擎对象
        /// </summary>
        /// <returns></returns>
        public static ILCoreEngine CurrentEngine()
        {
            if (Singleton<ILCoreEngine>.Instance==null)
            {
                CreateEngine();
            }
            return Singleton<ILCoreEngine>.Instance;
        }

    }
}
