using System;
using System.Collections.Generic;
using System.Text;

namespace L.SpiderCore.Crawler
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SpiderAttribute:Attribute
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public SpiderAttribute(string id,string description = "")
        {
            Id = id;
            Description = description;
        }
    }
}
