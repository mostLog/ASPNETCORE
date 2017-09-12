namespace L.LCore.Infrastructure.Extension
{
    public static class CommonExtension
    {
        /// <summary>
        /// 扩展IsNullOrEmpty方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}