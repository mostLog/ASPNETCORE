using System;
using System.Collections.Generic;
using System.Text;

namespace L.LCore.Infrastructure.Configuration
{
    public interface ILConfig
    {
        String SqlServerConnection { get; }
    }
}
