namespace L.Dapper.AspNetCore
{
    /// <summary>
    ///
    /// </summary>
    public class Dapper
    {
        /// <summary>
        /// 初始化数据库配置
        /// </summary>
        public static void InitConfig(DapperConfig config)
        {
        }
    }

    /// <summary>
    /// 配置参数类
    /// </summary>
    public class DapperConfig
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbType DbType { get; set; }
    }
}