using MvvmCross.Plugins.Messenger;
using Users.Core.Model;

namespace Users.Core.Messages
{
    public class CurrencyChangedMessage: MvxMessage
    {
        public CurrencyChangedMessage(object sender) : base(sender)
        {
        }

        public Currency NewCurrency { get; set; }
    }
}