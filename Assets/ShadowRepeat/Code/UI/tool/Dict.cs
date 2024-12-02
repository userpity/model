using System;
using System.Collections.Generic;

namespace tool
{
    //自定义字典类型
    [Serializable]
    public class Dict<K, V>
    {
        public K key;
        public V value;

        public Dict(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }

    [Serializable]
    public class DictTitle<K, V>
    {
        public string title;
        public List<Dict<K,V>> Dicts = new List<Dict<K,V>>();
    }
}
