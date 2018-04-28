
using System;
using System.Drawing;

using Foundation;
using MvvmCross.Binding.BindingContext;
using Users.Core.ViewModel;
using Users.iOS.TableViewSources;
using UIKit;

namespace Users.iOS.Views
{
    public partial class UsersView : BaseView
    {
        private UsersTableViewSource _UsersTableViewSource;

        protected UsersViewModel UsersViewModel => ViewModel as UsersViewModel;

        public UsersView(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();
            var set = this.CreateBindingSet<UsersView, UsersViewModel>();
            set.Bind(AddUser).To(vm => vm.MoveToAddUser);
            set.Bind(_UsersTableViewSource).To(vm => vm.Users);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            _UsersTableViewSource = new UsersTableViewSource(UserTableView);

            base.ViewDidLoad();

            UserTableView.Source = _UsersTableViewSource;
            //UserTableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            //UserTableView.SeparatorColor = UIColor.FromRGB(0, 215, 203);
            UserTableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            UsersViewModel.ReloadDataCommand.Execute();

            //UserTableView.DeselectRow(UserTableView.IndexPathForSelectedRow, true);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}