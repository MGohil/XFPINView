using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINView
{
    internal class BoxTemplate : Frame
    {
        private string _inputChar;
        private Color _color;
        public Color BoxFocusColor { get; set; }

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
                Scale = 0,
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
        public void FocusAnimation()
        {
            BorderColor = BoxFocusColor;
        }

        // Removes the focusindication color and set back to original
        public void UnFocusAnimation()
        {
            BorderColor = _color;
        }
    }
}
