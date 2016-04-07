using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableApp
{
    class HashTable<TKey, TValue>
    {
        public const string ERROR_KEY = "Couldn't find key";
        private const int BUCKETS = 10;
        private Dictionary<TKey, TValue>[] data_;
        private int count_ = 0;

        public HashTable()
        {
            data_ = new Dictionary<TKey, TValue>[BUCKETS];
            // by default create all the buckets
            for (int b = 0; b < BUCKETS; ++b)
            {
                data_[b] = new Dictionary<TKey, TValue>();
            }
        }

        public void Add(Tuple<TKey, TValue> entry)
        {
            int bucket = entry.Item1.GetHashCode() % BUCKETS;
            // update value if already exists
            if (data_[bucket].ContainsKey(entry.Item1))
            {
                data_[bucket][entry.Item1] = entry.Item2;
            }
            else
            {
                data_[bucket].Add(entry.Item1, entry.Item2);
                ++count_;
            }
        }

        public Tuple<TKey, TValue> Get(TKey key)
        {
            int bucket = key.GetHashCode() % BUCKETS;
            if (data_[bucket].ContainsKey(key))
            {
                return new Tuple<TKey, TValue>(key, data_[bucket][key]);
            }
            else
            {
                throw new Exception(ERROR_KEY);
            }
        }

        public void Remove(TKey key)
        {
            int bucket = key.GetHashCode() % BUCKETS;
            if (data_[bucket].Remove(key))
            {
                --count_;
            }
        }

        public void Clear()
        {
            // keeps array for performance optimization?
            for (int b = 0; b < BUCKETS; ++b)
            {
                data_[b].Clear();
            }
            count_ = 0;
        }

        public override string ToString()
        {
            StringBuilder ouString = new StringBuilder();
            ouString.Append("HashTable content:");
            for (int b = 0; b < BUCKETS; ++b)
            {
                ouString.Append("\n-bucket " + b.ToString() + ": ");
                foreach (var pair in data_[b])
                {
                    ouString.Append("(" + pair.Key.ToString() + ", " + pair.Value.ToString() + "), ");
                }
            }
            return ouString.ToString();
        }

        public int Size
        {
            get { return count_; }
        }
    }
}
