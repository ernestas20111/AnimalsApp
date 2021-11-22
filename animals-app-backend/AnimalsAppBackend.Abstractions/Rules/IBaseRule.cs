namespace AnimalsAppBackend.Abstractions.Rules
{
    public interface IValidationRule<T, TResult>
    {
        bool IsValid(T input);

        TResult Validate(T input);
    }
}
