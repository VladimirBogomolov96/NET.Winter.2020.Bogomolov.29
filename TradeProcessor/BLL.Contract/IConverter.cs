namespace BLL.Contract
{
    /// <summary>
    /// Converter contract.
    /// </summary>
    /// <typeparam name="TResult">Type of result of conversion.</typeparam>
    /// <typeparam name="TSource">Type of source of conversion.</typeparam>
    public interface IConverter<TResult, TSource>
    {
        /// <summary>
        /// Converts value of one type to another.
        /// </summary>
        /// <param name="source">Value to convert.</param>
        /// <returns>Converted value.</returns>
        TResult Convert(TSource source);
    }
}
