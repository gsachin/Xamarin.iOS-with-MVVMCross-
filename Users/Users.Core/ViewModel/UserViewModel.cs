using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Plugins.WebBrowser;
using Users.Core.Contracts.Services;
using Users.Core.Contracts.ViewModel;
using Users.Core.Utility;
using Users.Core.Validations;
using Users.Core.ViewModel;
namespace Users.Core.ViewModel
{
    public class UserViewModel : BaseViewModel, IUserViewModel
    {
        private readonly IDialogService _dialogService;

        private readonly IDataService _dataService;
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;


        public MvxCommand AddUserCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    if (IsValid())
                    {
                        await _dataService.Save(new Model.User(9, _userName.Value, _password.Value));
                        _dialogService.ShowAlertAsync("User added successfully", "Message", "OK");
                    }

                });
            }
        }

        public bool IsValid(){

            if (!UserName.Validate())
            {
                _dialogService.ShowAlertAsync(string.Join(",", UserName.Errors), "Error Message", "OK");
                return false;
            }else if(!Password.Validate())
            {
                _dialogService.ShowAlertAsync(string.Join(",", Password.Errors), "Error Message", "OK");
                return false;
            }

            return true;

        }
        public MvxCommand CloseCommand
        { get { return new MvxCommand(() => Close(this)); } }

        //public String UserName
        //{
        //    get { return _userName; }
        //    set
        //    {
        //        _userName = value;
        //        RaisePropertyChanged(() => UserName);
        //    }
        //}
        public ValidatableObject<string> UserName  
        {  
            get  
            {  
                return _userName;  
            }  
            set  
            {  
                _userName = value;  
                RaisePropertyChanged(() => UserName);  
            }  
}  


        public ValidatableObject<string>  Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        public UserViewModel(IMvxMessenger messenger,IDialogService dialogService,IDataService dataService):base(messenger){
                _dialogService = dialogService;
                _dataService = dataService;
                _userName = new ValidatableObject<string>();
                _password = new ValidatableObject<string>();
        }

        //public UserViewModel(IMvxMessenger messenger,
        //                     IUserDataService userDataService,
        //                     IDialogService dialogService, 
        //                     IDataService dataService
        //                             ) : base(messenger)
        //{

        //    _userDataService = userDataService;
        //    _dialogService = dialogService;
        //    _dataService = dataService;
        //    _userName = new ValidatableObject<string>();
        //    _password = new ValidatableObject<string>();
        //}


        //public UserViewModel(IMvxMessenger messenger,
        //                     IUserDataService UserDataService, 
        //                     IUserDataService userDataService, 
        //                     IDataService dataService) : base(messenger)
        //{
        //    _userDataService = userDataService;
        //    _dataService = dataService;
           
        //}

        public void Init()
        {

        }

        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            await Task.FromResult<int>(0);
            _userName.Value = "";
            _password.Value = "";
            AddValidations();

        }

        public class SavedState
        {
            public int UserId { get; set; }
        }

        public SavedState SaveState()
        {
            // MvxTrace.Trace("SaveState called");
            return new SavedState { UserId = 9 };
        }

        public void ReloadState(SavedState savedState)
        {

        }
        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A username is required."
            });
            _password.Validations.Add(new PasswordCharSequenceRule<string>
            {
                ValidationMessage = "A password length must be between 5 to 15 and mixture of letters and numerical digits only"
            });
            _password.Validations.Add(new PasswardCharRule<string>
            {
                ValidationMessage = "A password must not contain any sequence of characters"
            });
        }
        //public override bool IsValid
        //{
        //    get
        //    {
        //        return !CanModify || (ValidateRegex(CaseLabel, "^[0-9]+$") && ValidateRegex(TaskNumber, "^[0-9]*$"));
        //    }
        //}


    }
}
