using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GymControl2.Domain.Domain;
using GymControl2.Models;

namespace GymControl2.Aplication.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //private readonly IDataUsers _dataUsers;
        private readonly DataUsersDB _dataUsers;

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                if (user == value)
                    return;
                user = value;
                RaisePropertyChanged("User");
            }
        }

        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                if (value != _isAuthenticated)
                {
                    _isAuthenticated = value;
                    RaisePropertyChanged("IsAuthenticated");
                }
            }
        }


        private string username;
        public string UserName
        {
            get { return username; }
            set
            {
                if (username == value)
                    return;
                username = value;
                RaisePropertyChanged("UserName");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password == value)
                    return;
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public RelayCommand LoginCommand { get; private set; }

        public LoginViewModel(DataUsersDB dataUsers)
        {
            _dataUsers = dataUsers;
            LoginCommand = new RelayCommand(Login);
        }

        public void Login()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                return;

            var users = _dataUsers.GetAll();// as List<User>;

            var userID = users.Where(m => m.UserName == UserName)
                .Where(x => x.Password == password)
                .Select(x => x.Id)
                .SingleOrDefault();

            IsAuthenticated = true;
        }
    }
}
