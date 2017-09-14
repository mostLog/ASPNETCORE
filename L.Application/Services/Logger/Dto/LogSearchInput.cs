using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class LogSearchInput : PagedInputDto
    {
        public int LogLevel { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
