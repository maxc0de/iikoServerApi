using System;

namespace IikoServerApi
{
    public class IikoRMS
    {
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
            Login = "admin";
            Password = password;
        }

        public IikoRMS(string login, string password, string address, int port) : this(address, port, password)
        {
            Login = login;
        }
    }
}
