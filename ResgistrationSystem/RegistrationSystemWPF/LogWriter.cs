using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationSystemWPF
{
    class LogWriter
    {
        private static readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private string _fileName = string.Empty;
        private string _docPath = "C:\\Users\\meruzha\\Desktop\\";
        public LogWriter()
        {
            _fileName = _configuration.GetSection("FileName:usersInfo").Value;
            if (!File.Exists(_fileName))
            {
                File.Create(_fileName);
            }

        }
        public void OnLoggedIn(object source, EventArgs args)
        {
            var text = "You have successfully logged in";
            WriteToLog(text);
        }

        public void OnAutorizationFailed(object source, EventArgs args)
        {
            var text = "The username or password is not correct, try again";
            WriteToLog(text);
        }

        public void OnRegisteredEmployee(object source, EventArgs args)
        {
            var text = "workplace ";
            WriteToLog(text);
        }

        private void WriteToLog(string text)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_docPath, _fileName), true))
            {
                outputFile.WriteLine(text);
            }
        }
    }
}
