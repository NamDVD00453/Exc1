using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc1.Entity
{
    class User
    {
        private String _username;
        private String _email;
        private String _phone;
        private String _address;
        private String _avatar;

        public User()
        {
        }

        public User(string username, string email, string phone, string address, string avatar)
        {
            _username = username;
            _email = email;
            _phone = phone;
            _address = address;
            _avatar = avatar;
        }

        public string Username { get => _username; set => _username = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Address { get => _address; set => _address = value; }
        public string Avatar { get => _avatar; set => _avatar = value; }

        public override string ToString()
        {
            return "User: " 
                + _username.ToString() + " - "
                + _email.ToString() + " - "
                + _phone.ToString() + " - "
                + _address.ToString() + " - "
                + _avatar.ToString();
        }
    }
}
