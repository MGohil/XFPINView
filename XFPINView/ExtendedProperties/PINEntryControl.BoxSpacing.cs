using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINView
{
    public partial class PINEntryControl
    {
        /// <summary>
        /// Gets or Sets the Space among the PIN Boxes
        /// </summary>
        public double BoxSpacing
        {
            get => (double)GetValue(BoxSpacingProperty);
            set => SetValue(BoxSpacingProperty, value);
        }

        public static readonly BindableProperty BoxSpacingProperty =
          BindableProperty.Create(
              nameof(BoxSpacing),
              typeof(double),
              typeof(PINEntryControl),
              Constants.DefaultBoxSpacing,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BoxSpacingPropertyChanged);

        private static void BoxSpacingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((double)newValue < 0)
            {
                return;
            }

            var control = ((PINEntryControl)bindable);

            control.PINBoxContainer.Spacing = (double)newValue;
        }
    }
}
