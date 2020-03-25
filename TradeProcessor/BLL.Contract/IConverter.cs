namespace BLL.Contract
{
    public interface IConverter<TResult, TSource>
    {
        TResult Convert(TSource source);
    }
}
