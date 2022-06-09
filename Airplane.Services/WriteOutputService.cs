
namespace Airplane.Services
{
    /// <summary>
    /// An interface to show outputs to user
    /// </summary>
    public interface IWriteOutputService
    {
        /// <summary>
        /// Show output to user
        /// </summary>
        /// <param name="output">output</param>
        void WriteLine(string output);
    }
    public class WriteOutputService : IWriteOutputService
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
