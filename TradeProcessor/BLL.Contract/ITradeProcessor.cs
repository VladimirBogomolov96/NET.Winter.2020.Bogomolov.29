namespace BLL.Contract
{
    /// <summary>
    /// Trade processor contract.
    /// </summary>
    public interface ITradeProcessor
    {
        /// <summary>
        /// Runs processor.
        /// </summary>
        /// <returns>Result of execution.</returns>
        int Run();
    }
}
