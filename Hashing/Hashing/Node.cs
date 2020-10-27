namespace Hashing
{
    public class Node<T1, T2>
    {
        public T1 Key { get; }
        public T2 Value { get; }

        public Node(T1 key, T2 value) {
            Key = key;
            Value = value;
        }

        public override int GetHashCode() {
            return Key.GetHashCode();
        }
    }
}