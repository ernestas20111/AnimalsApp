namespace AnimalsAppBackend.Abstractions.Rules
{
    public interface IBaseRule<T>
    {
        bool IsValid(T input);
    }
}
