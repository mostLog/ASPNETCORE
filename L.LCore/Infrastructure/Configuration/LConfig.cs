using System;
using System.Collections.Generic;
using System.Text;

namespace L.LCore.Infrastructure.Configuration
{
    public class LConfig : ILConfig
    {
        public string SqlServerConnection { get; set; }
    }
}
