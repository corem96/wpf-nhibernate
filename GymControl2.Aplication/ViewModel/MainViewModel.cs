using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GymControl2.Domain.Domain;
using GymControl2.Models;
using System;
using System.Linq;
using System.Windows.Input;

namespace GymControl2.Aplication.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataUsers _dataUsers;

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                if (_user == value)
                    return;
                _user = value;
                RaisePropertyChanged("User");
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

        public RelayCommand LoginCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataUsers dataUsers)
        {
            _dataUsers = dataUsers;

            LoginCommand = new RelayCommand(LoginCommandExecute);
        }

        private void LoginCommandExecute()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                return;

            var users = _dataUsers.GetAll();// as List<User>;

            var userID = users.Where(m => m.UserName == UserName)
                .Where(x => x.Password == password)
                .SingleOrDefault();

            IsAuthenticated = true;
        }
    }
}