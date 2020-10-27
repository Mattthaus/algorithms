using System.Collections.Generic;

namespace Hashing
{
    public class ChainHashTable<T1, T2>
    {
        private List<List<Node<T1, T2>>> _table;
        
        public ChainHashTable(int amount)
        {
            _table = new List<List<Node<T1, T2>>>();

            for(int i = 0; i < amount; i++)
                _table.Add(new List<Node<T1, T2>>());
        }
        
        public Node<T1, T2> Get(T1 key)
        {
            int hash = key.GetHashCode() % _table.Count;
            if (_table[hash] == null)
                return null;

            for(int i = 0; i < _table[hash].Count; i++)
                if(_table[hash][i].Key.Equals(key))
                    return _table[hash][i];
            
            return null;
        }
        
        public bool Put(T1 key, T2 value)
        {
            if(GetFillingCoefficient() > 0.8)
                RebuildTable();

            if (Get(key) != null)
                return false;

            int hash = key.GetHashCode() % _table.Count;
            _table[hash].Add(new Node<T1, T2>(key, value));
            return true;
        }
        
        public bool Delete(T1 key)
        {
            int hash = key.GetHashCode() % _table.Count;
            if (_table[hash] == null)
                return false;

            for(int i = 0; i < _table[hash].Count; i++)
                if (_table[hash][i].Key.Equals(key))
                    return _table[hash].Remove(_table[hash][i]);

            return false;
        }

        public double GetFillingCoefficient()
        {
            int counter = 0;
            foreach (var sublist in _table)
                foreach (var node in sublist)
                    if(node != null)
                        counter++;
            
            return counter / (double)_table.Count;
        }

        public void RebuildTable()
        {
            List<List<Node<T1, T2>>> temporaryTable = _table;
            _table = new List<List<Node<T1, T2>>>(temporaryTable.Count * 2);

            for(int i = 0; i < temporaryTable.Count * 2; i++)
                _table.Add(null);

            foreach (var sublist in temporaryTable)
                if(sublist != null)
                    foreach (var node in sublist)
                        Put(node.Key, node.Value);
            
        }
    }
}