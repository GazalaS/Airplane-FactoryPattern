using Airplane.Models;

namespace Airplane.Services
{
    public interface IReadInputService
    {
        List<KeyValuePair<string,int>> ReadCommandsFromFile(string fileName);
        
    }
    public class ReadInputService: IReadInputService
    {
        private const string Separator = " ";
        public List<KeyValuePair<string, int>> ReadCommandsFromFile(string fileName)
        {
            var commands = new List<KeyValuePair<string, int>>();
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] input = line.Split(Separator);
                    commands.Add(KeyValuePair.Create(input[0], int.Parse(input[1])));
                }
            }
            return commands;
        }


    }
}
