namespace BLL.Contract
{
    /// <summary>
    /// Validator contract.
    /// </summary>
    /// <typeparam name="T">Type of value to validate.</typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Validates value.
        /// </summary>
        /// <param name="value">Value to validate.</param>
        void Validate(T value);
    }
}
