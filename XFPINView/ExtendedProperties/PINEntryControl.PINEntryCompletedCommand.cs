using Xamarin.Forms;

namespace XFPINView
{
    public partial class PINEntryControl
    {
        /// <summary>
        /// A Command to Bind and invoked when PIN Entry is completed
        /// </summary>
        public Command<string> PINEntryCompletedCommand
        {
            get { return (Command<string>)GetValue(PINEntryCompletedCommandProperty); }
            set { SetValue(PINEntryCompletedCommandProperty, value); }
        }

        public static readonly BindableProperty PINEntryCompletedCommandProperty =
           BindableProperty.Create(
              nameof(PINEntryCompletedCommand),
              typeof(Command<string>),
              typeof(PINEntryControl),
              null);
    }
}
