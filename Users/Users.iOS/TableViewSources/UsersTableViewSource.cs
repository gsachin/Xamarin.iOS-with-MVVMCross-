using System;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Users.iOS.TableViewSources
{
    public class UsersTableViewSource: MvxTableViewSource
    {
        public UsersTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        public UsersTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ItemsSource.Count();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (UserCell)tableView.DequeueReusableCell(UserCell.Identifier);
            return cell;
        }
    }
}