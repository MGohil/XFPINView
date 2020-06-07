using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINView
{
    public partial class PINView : ContentView
    {
        #region Fields
        /// <summary>
        /// A TapGuesture Recognizer to invoke when user tap on any PIN box.
        /// This will help bring up the soft keyboard
        /// </summary>
        private readonly TapGestureRecognizer boxTapGestureRecognizer;

        /// <summary>
        /// An event which is raised/invoked when PIN entry is completed
        /// This will help user to execute any code when entry completed
        /// </summary>
        public event EventHandler<PINCompletedEventArgs> PINEntryCompleted;
        #endregion

        #region Constructor and Initializations
        public PINView()
        {
            InitializeComponent();

            hiddenTextEntry.TextChanged += PINView_TextChanged;
            hiddenTextEntry.Focused += HiddenTextEntry_Focused;
            hiddenTextEntry.Unfocused += HiddenTextEntry_Unfocused;

            boxTapGestureRecognizer = new TapGestureRecognizer() { Command = new Command(() => { BoxTapCommandExecute(); }) };

            CreateControl();
        }

        private void HiddenTextEntry_Unfocused(object sender, FocusEventArgs e)
        {
            var pinBoxArray = PINBoxContainer.Children.Select(x => x as BoxTemplate).ToArray();

            for (int i = 0; i < PINLength; i++)
            {
                pinBoxArray[i].UnFocusAnimation();
            }
        }

        private void HiddenTextEntry_Focused(object sender, FocusEventArgs e)
        {
            var length = PINValue == null ? 0 : PINValue.Length;
            var pinBoxArray = PINBoxContainer.Children.Select(x => x as BoxTemplate).ToArray();

            if (length == PINLength)
            {
                pinBoxArray[length - 1].FocusAnimation();
            }
            else
            {
                for (int i = 0; i < PINLength; i++)
                {
                    if (i == length)
                    {
                        pinBoxArray[i].FocusAnimation();
                    }
                    else
                    {
                        pinBoxArray[i].UnFocusAnimation();
                    }
                }
            }
        }



        /// <summary>
        /// Calling this, will bring up the soft keyboard, or will help focus the control
        /// </summary>
        public void FocusBox()
        {
            boxTapGestureRecognizer?.Command?.Execute(null);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the UI for the PINView
        /// </summary>
        public void CreateControl()
        {
            hiddenTextEntry.MaxLength = PINLength;

            var count = PINBoxContainer.Children.Count;

            if (count < PINLength)
            {
                int newBoxesToAdd = PINLength - count;
                for (int i = 1; i <= newBoxesToAdd; i++)
                {
                    BoxTemplate boxTemplate = CreateBox();
                    PINBoxContainer.Children.Add(boxTemplate);
                }
            }
            else if (count > PINLength)
            {
                int boxesToRemove = count - PINLength;
                for (int i = 1; i <= boxesToRemove; i++)
                {
                    PINBoxContainer.Children.RemoveAt(PINBoxContainer.Children.Count - 1);
                }
            }
        }

        /// <summary>
        /// Creates the instance of one single PIN box UI
        /// </summary>
        /// <returns></returns>
        private BoxTemplate CreateBox()
        {
            BoxTemplate boxTemplate = new BoxTemplate();
            boxTemplate.HeightRequest = BoxSize;
            boxTemplate.WidthRequest = BoxSize;
            boxTemplate.Box.BackgroundColor = BoxBackgroundColor;
            boxTemplate.CharLabel.FontSize = BoxSize / 2;
            boxTemplate.GestureRecognizers.Add(boxTapGestureRecognizer);
            boxTemplate.BoxFocusColor = BoxFocusColor;
            boxTemplate.SecureMode(IsPassword);
            boxTemplate.SetColor(Color);
            boxTemplate.SetRadius(BoxShape);

            return boxTemplate;
        }

        #endregion

        #region Events
        /// <summary>
        /// Invokes when user type the PIN or text changes in the hidden textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PINView_TextChanged(object sender, TextChangedEventArgs e)
        {
            PINValue = e.NewTextValue;

            if (e.NewTextValue.Length == PINLength)
            {
                // To have some delay, before invoking any Action, otherwise, (if) while navigation, it will be quick and you won't see your last entry.
                await Task.Delay(200);

                PINEntryCompleted?.Invoke(this, new PINCompletedEventArgs(PINValue));
                PINEntryCompletedCommand?.Execute(PINValue);

                // Dismiss the keyboard, once entry is completed up to the defined length and if AutoDismissKeyboard property is true 
                if (AutoDismissKeyboard == true)
                {
                    (sender as Entry).Unfocus();
                }
            }
        }
        #endregion

        #region Commands and Executes
        /// <summary>
        /// Invokes when user tap on the PINView, this will bring up the soft keyboard
        /// </summary>
        private async void BoxTapCommandExecute()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                // https://xamarin.github.io/bugzilla-archives/55/55245/bug.html 
                await Task.Delay(1);
            }

            hiddenTextEntry.Focus();
        }
        #endregion
    }
}
