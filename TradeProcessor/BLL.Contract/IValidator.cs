namespace BLL.Contract
{
    public interface IValidator<T>
    {
        void Validate(T value);
    }
}
