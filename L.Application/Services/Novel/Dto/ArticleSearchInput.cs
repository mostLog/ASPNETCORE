﻿using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class ArticleSearchInput
    {
        public long? Seq { get; set; }
        public bool? IsCrawlerContent { get; set; } = false;
        public int RowCount { get; set; } = 5;
    }
}
