using System.IO;

namespace TibiaHighscoreApp.Systems.Client
{
    class Logger
    {
        private StreamWriter _logFile;
        
        public Logger()
        {
            _logFile = new StreamWriter("C:\\Users\\TimoD\\source\\repos\\TibiaHighscoreApp\\TibiaHighscoreApp\\Logfile.txt", true);
        }
    }
}
