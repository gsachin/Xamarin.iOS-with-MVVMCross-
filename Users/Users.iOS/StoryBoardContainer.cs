using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace Users.iOS
{
    public class StoryBoardContainer: MvxIosViewsContainer
    {
        protected override IMvxIosView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            var storyboard = UIStoryboard.FromName("Storyboard", null);
            return (IMvxIosView)storyboard
                 .InstantiateViewController(viewType.Name);
        }
    }
}