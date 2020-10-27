using System.Collections.Generic;

namespace Hashing
{
    public class LinearSoundingHashTable<T1, T2>
    {
        private List<Node<T1, T2>> _table;
        private readonly List<T1> _deletedKeys;

        public LinearSoundingHashTable(int size)
        {
            _table = new List<Node<T1, T2>>(size);

            for (int i = 0; i < size; i++)
                _table.Add(null);

            _deletedKeys = new List<T1>();
        }

        public Node<T1, T2> Get(T1 key)
        {
            int hash = key.GetHashCode() % _table.Count;

            for (int i = hash; i < _table.Count; i++)
            {

                if (_table[i] == null)
                    return null;

                if (_table[i].Key.Equals(key))
                    return _table[hash];
            }

            for (int i = 0; i < hash; i++)
            {
                if (_table[i] == null)
                    return null;

                if (_table[i].Key.Equals(key))
                    return _table[hash];
            }

            return null;
        }

        public bool Put(T1 key, T2 value)
        {
            if (GetFillingCoefficient() > 0.8)
            {
                RebuildHashTable();
            }

            if (Get(key) != null)
                return false;

            int hash = key.GetHashCode() % _table.Count;

            for (int i = hash; i < _table.Count; i++)
                if (_table[i] == null)
                {
                    _table[i] = new Node<T1, T2>(key, value);
                    return true;
                }

            for (int i = 0; i < hash; i++)
                if (_table[i].Value == null)
                {
                    _table[i] = new Node<T1, T2>(key, value);
                    return true;
                }

            return false;
        }

        public bool Remove(T1 key)
        {
            if (Get(key) != null)
            {
                _deletedKeys.Add(key);
                return true;
            }

            return false;
        }

        public double GetFillingCoefficient()
        {
            int counter = 0;
            foreach (var t in _table)
                if (t != null)
                    counter++;

            return counter / (double) _table.Count;
        }

        public void RebuildHashTable()
        {
            List<Node<T1, T2>> temporaryTable = _table;
            _table = new List<Node<T1, T2>>(temporaryTable.Count * 2);

            for (int i = 0; i < temporaryTable.Count * 2; i++)
                _table.Add(null);

            foreach (var node in temporaryTable)
                if (node != null)
                    Put(node.Key, node.Value);
        }
    }
}