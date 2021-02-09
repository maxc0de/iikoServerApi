using System;

namespace IikoApi
{
    public class IikoRMS
    {
        private const string defaultLogin = "admin";

        public string Address { get; private set; }

        public int Port { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public Uri ServerUri
        {
            get
            {
                if (Port == 443)
                {
                    return new Uri($"https://{Address}");
                }
                else
                {
                    return new Uri($"http://{Address}:{Port}");
                }
            }
        }


        public IikoRMS(string address, int port, string password)
        {
            Address = address;
            Port = port;
            Login = defaultLogin;
            Password = password;
        }

        public IikoRMS(string address, int port, string login, string password) : this(address, port, password)
        {
            Login = login;
        }
    }
}
