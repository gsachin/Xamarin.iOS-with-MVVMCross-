﻿using System;
using MvvmCross.iOS.Views;
using Users.iOS.Utility;
using UIKit;

namespace Users.iOS.Views
{
    public class BaseView: MvxViewController
    {
        public BaseView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var stringAttributes = new UIStringAttributes ();
            stringAttributes.Font = UIFont.SystemFontOfSize (16);
            stringAttributes.ForegroundColor = UIColor.FromRGB (255, 255, 255);
            NavigationController.NavigationBar.BarTintColor = UsersColors.DarkColor;
            NavigationController.NavigationBar.TintColor = UIColor.White;
            NavigationController.NavigationBar.TitleTextAttributes = stringAttributes;

            CreateBindings();
        }

        public override UIStatusBarStyle PreferredStatusBarStyle ()
        {
            return UIStatusBarStyle.LightContent;
        }

        protected virtual void CreateBindings()
        {
        }
    }
}