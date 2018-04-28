using System.Threading.Tasks;
using Users.Core.Contracts.Services;
using UIKit;

namespace Users.iOS.Services
{
    public class DialogService: IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonText)
        {
            return Task.Run(() =>
                UIApplication.SharedApplication.InvokeOnMainThread(() =>
                {
                    new UIAlertView(title, message, null, buttonText).Show();
                }));
        }
        public Task ShowAlertAsync(string message, string title, IUIAlertViewDelegate @delegate, string buttonText)
        {
            return Task.Run(() =>
                UIApplication.SharedApplication.InvokeOnMainThread(() =>
                {
                new UIAlertView(title, message, @delegate, buttonText).Show();
                }));
        }
    }
}
