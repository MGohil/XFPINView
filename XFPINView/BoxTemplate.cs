using System.Threading.Tasks;
using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINView
{
    internal class BoxTemplate : Frame
    {
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
                FontSize = 20,
                //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            };


            Content = Dot;
        }

        public async Task GrowAnimation()
        {
            await Dot.ScaleTo(1.0, 50);
        }

        public async Task ShrinkAnimation()
        {
            await Dot.ScaleTo(0, 50);
        }

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
        }

        public Frame Box
        {
            get { return this; }
        }

        public BoxView Dot { get; } = null;

        public Label CharLabel { get; } = null;

    }
}
