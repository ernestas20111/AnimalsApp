namespace AnimalsAppBackend.Abstractions
{
    public class GenericTypesUtilities<T>
    {
        public static bool Exists(T variable)
        {
            return Equals(variable, default);
        }

        public static bool Equals(T left, T right)
        {
            return (left is null && right is object)
                || (left is object && right is null)
                || (left is object && right is object && !left.Equals(right));
        }
    }
}
