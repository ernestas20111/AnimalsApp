namespace AnimalsAppBackend.Abstractions.Rules
{
    public interface IBaseRule<T, TResult>
    {
        bool IsValid(T input);

        TResult Validate(T input);
    }
}
