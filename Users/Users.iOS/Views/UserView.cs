using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Users.Core.Contracts.ViewModel;
using Users.Core.ViewModel;
using UIKit;

namespace Users.iOS.Views
{
    public partial class UserView : BaseView
    {
        protected UserViewModel adUserViewModel => ViewModel as UserViewModel;
        //public UserView() : base("UserView", null)
        //{
        //}
       
        public UserView(IntPtr handle) : base(handle)
        {
           // adUserViewModel = new AddUserViewModel();
        }
        protected override void CreateBindings()
        {
            base.CreateBindings();
            var set = this.CreateBindingSet<UserView, UserViewModel>();
            set.Bind(Submit).To(vm => vm.AddUserCommand);
            set.Bind(Cancel).To(vm => vm.CloseCommand);
            set.Bind(UserName).To(vm => vm.UserName.Value);
            set.Bind(Password).To(vm => vm.Password.Value);
            set.Apply();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        public void init(){
            
        }
    }
}

