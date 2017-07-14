using L.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Services.Dto
{
    public class SearchInput: PagedInputDto
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
    }
}
