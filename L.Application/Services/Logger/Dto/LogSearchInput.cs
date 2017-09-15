using System;

namespace L.Application.Dto
{
    public class LogSearchInput : PagedInputDto
    {
        public int LogLevel { get; set; }
        public DateTime? DateTime { get; set; }
    }
}