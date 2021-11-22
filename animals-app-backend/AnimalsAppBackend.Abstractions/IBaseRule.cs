namespace AnimalsAppBackend.Abstractions
{
    public interface IBaseRule<T, R>
    {
        bool IsValid(R input);

        T Validate(R input);
    }
}
