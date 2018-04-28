// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Users.iOS.Views
{
    [Register ("UsersView")]
    partial class UsersView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddUser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView UserTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddUser != null) {
                AddUser.Dispose ();
                AddUser = null;
            }

            if (UserTableView != null) {
                UserTableView.Dispose ();
                UserTableView = null;
            }
        }
    }
}