using System.Data;

namespace L.Dapper.AspNetCore
{
    public class DbFactory
    {
        private readonly Dapper _dapper;

        public DbFactory(Dapper dapper)
        {
            _dapper = dapper;
        }

        public IDbConnection GetDbInstance()
        {
            //获取配置信息
            var config = _dapper.Config;
            IDbConnection db = MSSQLServer.GetDbInstance(config.ConnectionString);
            switch (config.DbType)
            {
                case DbType.MSSQLServer:
                    db = MSSQLServer.GetDbInstance(config.ConnectionString);
                    break;

                default:
                    break;
            }
            return db;
        }
    }
}