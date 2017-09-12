namespace L.Application.Dto
{
    public class ExcelDto
    {
        public ExcelDto(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
    }
}