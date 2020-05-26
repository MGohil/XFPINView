﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFPINView.Helpers;

namespace XFPINView
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Shape of the PIN Box from BoxShapeType enum:
        /// 
        ///     Circle,
        ///     RoundCorner
        ///     Squere
        ///     
        /// </summary>
        public BoxShapeType BoxShape
        {
            get => (BoxShapeType)GetValue(BoxShapeProperty);
            set => SetValue(BoxShapeProperty, value);
        }

        public static readonly BindableProperty BoxShapeProperty =
           BindableProperty.Create(
               nameof(BoxShape),
               typeof(BoxShapeType),
               typeof(PINView),
                BoxShapeType.RoundCorner,
               defaultBindingMode: BindingMode.OneWay,
               propertyChanged: BoxShapePropertyChanged);

        private static void BoxShapePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;

                control.SetRadius(boxTemplate, (BoxShapeType)newValue);
            });
        }
    }
}
