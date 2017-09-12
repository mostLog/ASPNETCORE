namespace L.Application.Dto
{
    public class KeyValueDto<K, V>
    {
        public KeyValueDto()
        {
        }

        public K Key { get; set; }
        public V Value { get; set; }
    }
}