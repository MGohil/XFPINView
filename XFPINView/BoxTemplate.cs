using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINView
{
    internal class BoxTemplate : Frame
    {
        private string _inputChar;
        private Color _color;
        public FocusAnimationType FocusAnimationType;
        public Color BoxFocusColor { get; set; }

        public Frame Box { get { return this; } }

        public Frame Dot { get; } = null;

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

            Dot = new Frame()
            {
                BackgroundColor = Constants.DefaultColor,
                CornerRadius = (float)Constants.DefaultDotSize / 2,
                HeightRequest = Constants.DefaultDotSize,
                WidthRequest = Constants.DefaultDotSize,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Scale = 0,
                Padding = 0,
                HasShadow = false,
            };

            CharLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Constants.DefaultColor,
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Center,
                Scale = 0,
            };

            // In UWP, Label doesn't show vertically center properly. So, Lifted it bit up from bottom
            if (Device.RuntimePlatform == Device.UWP)
            {
                CharLabel.Margin = new Thickness(0, 0, 0, 2);
            }

            Content = Dot;
        }

        private void GrowAnimation()
        {
            Content.ScaleTo(1.0, 100);
        }

        private void ShrinkAnimation()
        {
            Content.ScaleTo(0, 100);
        }

        /// <summary>
        /// Sets the Color of Border, Dot, Input CharLabel
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(Color color)
        {
            _color = color;

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
            if (isPassword)
            {
                Content = Dot;
            }
            else
            {
                Content = CharLabel;
            }

            if (!string.IsNullOrEmpty(_inputChar))
            {
                GrowAnimation();
            }
            else
            {
                ShrinkAnimation();
            }
        }

        /// <summary>
        /// Clears the input value along with showing the Clear value Animation
        /// </summary>
        /// <returns></returns>
        public void ClearValueWithAnimation()
        {
            _inputChar = null;
            ShrinkAnimation();
        }

        /// <summary>
        /// Sets the input value along with showing the Set value animation
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        public void SetValueWithAnimation(char inputChar)
        {
            UnFocusAnimation();

            CharLabel.Text = inputChar.ToString();
            _inputChar = inputChar.ToString();
            GrowAnimation();
        }

        // Sets the focus indication color
        public async void FocusAnimation()
        {
            BorderColor = BoxFocusColor;

            if (FocusAnimationType == FocusAnimationType.ZoomInOut)
            {
                await this.ScaleTo(1.2, 100);
                this.ScaleTo(1, 100);
            }
            else if (FocusAnimationType == FocusAnimationType.ScaleUp)
            {
                this.ScaleTo(1.2, 100);
            }
        }

        // Removes the focusindication color and set back to original
        public void UnFocusAnimation()
        {
            BorderColor = _color;
            this.ScaleTo(1, 100);
        }
    }
}
