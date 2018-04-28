using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Users.Core.Contracts.Services;
using Users.Core.Contracts.ViewModel;
using Users.Core.Extensions;
using Users.Core.Model;

namespace Users.Core.ViewModel
{
    public class UsersViewModel : BaseViewModel, IUsersViewModel
    {
       
        private readonly IDataService _dataService;

        private ObservableCollection<User> _Users;

        public MvxCommand ReloadDataCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    _Users.Clear();
                    var users = await _dataService.GetAllItems();
                    foreach (User user in users)
                    {
                        _Users.Add(user);
                    }
                    //Users = (await _userDataService.GetSavedUsers()).ToObservableCollection();
                });
            }
        }

        public MvxCommand MoveToAddUser
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<UserViewModel>();
                    //_Users.Clear();
                    //var users = await _userDataService.GetSavedUsers();
                    //foreach (User user in users)
                    //{
                    //    _Users.Add(user);
                    //}
                    //Users = (await _UserDataService.GetSavedUsers()).ToObservableCollection();
                });
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                return _Users;
            }
            set
            {
                _Users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public UsersViewModel(IMvxMessenger messenger, IDataService dataService) : base(messenger)
        {
            
            _dataService = dataService;
            _Users = new ObservableCollection<User>();
            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            //Messenger.Subscribe<CurrencyChangedMessage>(async message => await ReloadDataAsync());
        }


        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            _Users.Clear();
            var users = await _dataService.GetAllItems();
            foreach (User user in users)
            {
                _Users.Add(user);
            }
        }
    }
}