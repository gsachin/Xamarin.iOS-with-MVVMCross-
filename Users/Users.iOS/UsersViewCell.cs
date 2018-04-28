using Foundation;
using System;
using System.CodeDom.Compiler;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using Users.Core.Model;
using UIKit;

namespace Users.iOS
{
	partial class UserCell : MvxTableViewCell
    {
		public UserCell (IntPtr handle) : base (handle)
		{
		}

	    internal static NSString Identifier = new NSString("UserCell");

        private void CreateBindings()
        {
            var set = this.CreateBindingSet<UserCell, User>();

            set.Bind(UserName)
               .To(vm => vm.UserName);

            set.Bind(Password)
               .To(vm => vm.Password);
            

            set.Apply();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CreateBindings();
        }
    }
}
