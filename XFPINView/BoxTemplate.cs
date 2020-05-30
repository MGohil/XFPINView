using System.Threading.Tasks;
using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINView
{
    internal class BoxTemplate : Frame
    {
        private bool _isPassword;

        public Frame Box { get { return this; } }

        public BoxView Dot { get; } = null;

        public Label CharLabel { get; } = null;

        public BoxTemplate()
        {
            Padding = 0;
            BackgroundColor = Constants.DefaultBoxBackgroundColor;
            BorderColor = Constants.DefaultColor;
            CornerRadius = (float)Constants.DefaultBoxSize / 2;
            HasShadow = false;
            HeightRequest = WidthRequest = Constants.DefaultBoxSize;
            VerticalOptions = LayoutOptions.Center;

            Dot = new BoxView()
            {
                BackgroundColor = Constants.DefaultColor,
                CornerRadius = Constants.DefaultDotSize / 2,
                HeightRequest = Constants.DefaultDotSize,
                WidthRequest = Constants.DefaultDotSize,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                IsVisible = false,
                Scale = 0,
            };

            CharLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Constants.DefaultColor,
                FontAttributes = FontAttributes.Bold,
                Scale = 0,
                IsVisible = false,
            };

            Content = Dot;
        }

        private async Task GrowAnimation(View view)
        {
            await view.ScaleTo(1.0, 100);
        }

        private async Task ShrinkAnimation(View view)
        {
            await view.ScaleTo(0, 100);
        }

        /// <summary>
        /// Sets the Color of Border, Dot, Input CharLabel
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(Color color)
        {
            BorderColor = color;
            Dot.BackgroundColor = color;
            CharLabel.TextColor = color;
        }

        /// <summary>
        /// Applies the Corner Radius to the PIN Box based on the ShapeType
        /// </summary>
        /// <param name="boxTemplate"></param>
        /// <param name="shapeType"></param>
        public void SetRadius(BoxShapeType shapeType)
        {
            if (shapeType == BoxShapeType.Circle)
            {
                CornerRadius = (float)HeightRequest / 2;
            }
            else if (shapeType == BoxShapeType.Squere)
            {
                CornerRadius = 0;
            }
            else if (shapeType == BoxShapeType.RoundCorner)
            {
                CornerRadius = 10;
            }
        }

        /// <summary>
        /// Method sets the visibility of Input Characters or Dots.
        /// IsPassword = True  : Displays Dots
        /// IsPassword = False : Displays Chars
        /// </summary>
        /// <param name="isPassword"></param>
        public void SecureMode(bool isPassword)
        {
            _isPassword = isPassword;

            if (isPassword)
            {
                Content = Dot;
            }
            else
            {
                Content = CharLabel;
            }
        }

        /// <summary>
        /// Clears the input value along with showing the Clear value Animation
        /// </summary>
        /// <returns></returns>
        public async Task ClearValueWithAnimation()
        {
            if (_isPassword)
            {
                await ShrinkAnimation(Dot);
                Dot.IsVisible = false;
            }
            else
            {
                await ShrinkAnimation(CharLabel);
                CharLabel.IsVisible = false;
                CharLabel.Text = string.Empty;
            }
        }

        /// <summary>
        /// Sets the input value along with showing the Set value animation
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        public async Task SetValueWithAnimation(char inputChar)
        {
            if (_isPassword)
            {
                Dot.IsVisible = true;
                await GrowAnimation(Dot);
            }
            else
            {
                CharLabel.IsVisible = true;
                CharLabel.Text = inputChar.ToString();
                await GrowAnimation(CharLabel);
            }
        }
    }
}
