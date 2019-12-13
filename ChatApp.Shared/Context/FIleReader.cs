using System.IO;

namespace ChatApp.Shared.Context
{
    public class FileReader
    {
        private string filePath;
        private string data;
        public FileReader(string path)
        {
            filePath = path;
        }

        public string ReadData()
        {
            if (File.Exists(filePath))
            {
                data = File.ReadAllText(filePath);
            }
            else
            {
                data = "";
            }
            return data;
        }

        public void WriteData(string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}