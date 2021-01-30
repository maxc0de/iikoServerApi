using System;

namespace iikoAPIServer
{
    public class IikoServer
    {
        public string Login { get; private set; }

        public string Password { get; private set; }

        public string Address { get; private set; }

        public string Port { get; private set; }

        public string Url
        {
            get
            {
                if (Port == "443")
                {
                    return $"https://{Address}/resto";
                }
                else
                {
                    return $"http://{Address}:{Port}/resto";
                }
            }
        }

        public IikoServer(string login, string password, string address, string port)
        {
            Login = login;
            Password = password;
            Address = address;
            Port = port;
        }
    }
}
