using Exc1.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc1.Model
{
    class UserModel
    {

        private static ObservableCollection<User> ListUser;

        private static void InitUser()
        {
            ListUser.Add(new User
            {
                Username = "TEST 1",
                Email = "Email 1",
                Phone = "Phone 1",
                Address = "Address 1",
                Avatar = "Avatar 1"
            });
            ListUser.Add(new User
            {
                Username = "TEST 2",
                Email = "Email 2",
                Phone = "Phone 2",
                Address = "Address 2",
                Avatar = "Avatar 2"
            });
            ListUser.Add(new User
            {
                Username = "TEST 3",
                Email = "Email 3",
                Phone = "Phone 3",
                Address = "Address 3",
                Avatar = "Avatar 3"
            });
        }

        public static ObservableCollection<User> GetUsers()
        {
            if (ListUser == null)
            {
                ListUser = new ObservableCollection<User>();
                InitUser();
            }
            return ListUser;
        }

    }
}
