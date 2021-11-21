namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    interface IBaseRule<T, R>
    {
        bool IsValid(R input);

        T Validate(R input);
    }
}
