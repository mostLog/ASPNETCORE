using HtmlAgilityPack;
using System.Linq;

namespace L.SpiderCore.Tools
{
    /// <summary>
    /// XPath方式选择器
    /// </summary>
    public class XPathSelector
    {
        public HtmlDocument htmlDoc = new HtmlDocument();

        public XPathSelector(string html)
        {
            //加载html
            htmlDoc.LoadHtml(html);
        }
        /// <summary>
        /// 获取匹配xpath规则的第一个元素
        /// </summary>
        public HtmlNode SelectSingleNode(string xpath)
        {
            return SelectNodes(xpath).First();
        }
        /// <summary>
        /// 选择匹配xpath的所有元素集合
        /// </summary>
        /// <param name="xpath"></param>
        public HtmlNodeCollection SelectNodes(string xpath)
        {
            return htmlDoc.DocumentNode
                .SelectSingleNode("//body")
                .SelectNodes(xpath);
        }
        /// <summary>
        /// 获取html元素属性值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetAttribute(HtmlNode node,string name)
        {
            return node.Attributes[name].Value;
        }
        /// <summary>
        /// javascript  innerText
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string GetInnerText(HtmlNode node)
        {
            if (node.ChildNodes.Count>0)
            {
                return string.Empty;
            }
            return node.InnerText;
        }
    }
}
