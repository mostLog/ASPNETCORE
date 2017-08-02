using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace L.SpiderCore.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class XPathSelector
    {
        private HtmlDocument HtmlDoc { get; set; }

        public XPathSelector()
        {
            HtmlDoc.DocumentNode.SelectNodes("");
        }

    }
}
