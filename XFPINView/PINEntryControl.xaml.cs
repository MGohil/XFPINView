using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINView
{
    public partial class PINEntryControl : ContentView
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
        public PINEntryControl()
        {
            InitializeComponent();

            hiddenTextEntry.TextChanged += PINEntryControl_TextChanged;
            boxTapGestureRecognizer = new TapGestureRecognizer() { Command = new Command(() => { BoxTapCommandExecute(); }) };

            CreateControl();
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
        /// Initializes the UI for the PINEntryControl
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

            SetRadius(boxTemplate, BoxShape);

            boxTemplate.GestureRecognizers.Add(boxTapGestureRecognizer);
            return boxTemplate;
        }

        /// <summary>
        /// Applies the Corner Radius to the PIN Box based on the ShapeType
        /// </summary>
        /// <param name="boxTemplate"></param>
        /// <param name="shapeType"></param>
        private void SetRadius(BoxTemplate boxTemplate, BoxShapeType shapeType)
        {
            if (shapeType == BoxShapeType.Circle)
            {
                boxTemplate.Box.CornerRadius = (float)boxTemplate.Box.HeightRequest / 2;
            }
            else if (shapeType == BoxShapeType.Squere)
            {
                boxTemplate.Box.CornerRadius = 0;
            }
            else if (shapeType == BoxShapeType.RoundCorner)
            {
                boxTemplate.Box.CornerRadius = 10;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Invokes when user type the PIN or text changes in the hidden textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PINEntryControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            PINValue = e.NewTextValue;

            if (e.NewTextValue.Length == PINLength)
            {
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
        /// Invokes when user tap on the PINEntryControl, this will bring up the soft keyboard
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
