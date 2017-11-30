using L.LCore.Logger;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.LCore.Infrastructure.Extension
{
    public static class ApplicationExtension
    {
        public static void UseLogger(this IApplicationBuilder applicationBuilder)
        {
            //LogEnqueManager.Instance.Start();
        }
    }
}
