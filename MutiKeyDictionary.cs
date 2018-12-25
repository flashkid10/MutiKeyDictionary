using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniLyst_5._0
{
    public class MutiKeyDictionary<T, U, V>
    {
        private Dictionary<T, Dictionary<U, V>> DoubleKeyDict = new Dictionary<T, Dictionary<U, V>>();

        //public void Add(T K1, U K2, V Value)
        //{
        //    DoubleKeyDict.Add(K1, new Dictionary<U, V>());
        //    DoubleKeyDict[K1].Add(K2, Value);
        //}

        public void AddSlot(T K1, U K2, V V)
        {
            if (!Contains(K1, K2))
            {
                if (!DoubleKeyDict.Keys.Contains(K1)) DoubleKeyDict.Add(K1, new Dictionary<U, V>());
                if (!DoubleKeyDict[K1].Keys.Contains(K2)) DoubleKeyDict[K1].Add(K2, V);
                else DoubleKeyDict[K1][K2] = V;
            }
        }

        public V this[T K1, U K2]
        {
            get { return DoubleKeyDict[K1][K2]; }
            set { DoubleKeyDict[K1][K2] = value; }
        }

        public Dictionary<U, V> this[T K1]
        {
            get { return DoubleKeyDict[K1]; }
            set { DoubleKeyDict[K1] = value; }
        }

        public void Remove(T K1) => DoubleKeyDict.Remove(K1);

        public void Remove(T K1, U K2) => DoubleKeyDict[K1].Remove(K2);

        public bool Contains(T K1)
        {
            return DoubleKeyDict.Keys.Contains(K1);
        }

        public bool Contains(T K1, U K2)
        {
            if (Contains(K1)) return DoubleKeyDict[K1].Keys.Contains(K2);
            else return false;
        }
    }
}