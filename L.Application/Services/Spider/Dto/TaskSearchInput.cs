namespace L.Application.Dto
{
    public class TaskSearchInput : PagedInputDto
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
    }
}