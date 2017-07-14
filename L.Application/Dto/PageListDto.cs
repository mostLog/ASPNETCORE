using System.Collections.Generic;

namespace L.Application.Dto
{
    /// <summary>
    /// 带分页数据集合Dto
    /// 
    /// 小白-2017-6-12
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageListDto<T>:List<T>
    {
        public PageListDto(IEnumerable<T> items, int totalCount)
        {
            AddRange(items);
            TotalCount = totalCount;
        }
        public PageListDto(IEnumerable<T> items,int pageIndex,int pageSize,int totalCount,params KeyValueDto<string, object>[] datas)
        {
            AddRange(items);
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = PageSize;
            Datas = datas;
        }
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 页面索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 显示数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 键值对附加数据
        /// </summary>
        public KeyValueDto<string,object>[] Datas { get; set; }

    }
}
