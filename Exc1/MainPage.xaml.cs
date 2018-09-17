using Exc1.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Exc1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<User> users { get => Model.UserModel.GetUsers(); set => users = value; }

        public MainPage()
        {
            this.InitializeComponent();
            UserList.ItemsSource = users;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Entity.User User = new Entity.User();
            User.Username = Username.Text;
            User.Email = Email.Text;
            User.Phone = Phone.Text;
            User.Address = Address.Text;
            User.Avatar = "Avatar";
            users.Add(User);
            string Json = JsonConvert.SerializeObject(User);

            
            
            Debug.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond + ">> "+Json);
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel TapPanel = (StackPanel)sender;
            User currentUser = (User) TapPanel.Tag;
            Debug.WriteLine(currentUser.ToString() + " => TAPPED.");
            LoadDetail(currentUser);
        }

        private void LoadDetail(User currentUser)
        {
            xUsername.Text = currentUser.Username;
            xEmail.Text = currentUser.Email;
            xPhone.Text = currentUser.Phone;
            xAddress.Text = currentUser.Address;
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            Windows.Storage.StorageFile writeFile = await storageFolder.GetFileAsync("sample.txt");
            await Windows.Storage.FileIO.WriteTextAsync(writeFile, "Hello");
            Windows.Storage.StorageFile readFile = await storageFolder.GetFileAsync("sample.txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(readFile);
            Debug.WriteLine(text);
            IReadOnlyList< Windows.Storage.StorageFile> listAllFile = await storageFolder.GetFilesAsync();

            foreach (Windows.Storage.StorageFile file in listAllFile)
            {
                Debug.WriteLine(file.Name);
            }


        }
    }
}
