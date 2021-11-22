namespace AnimalsAppBackend.Abstractions.Rules
{
    public interface IValidationRule<T, TResult> : IBaseRule<T>
    {
        TResult Validate(T input);
    }
}
