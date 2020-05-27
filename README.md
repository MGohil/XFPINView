# XFPINView (Xamarin.Forms UI Control)
XFPINView is Xamarin.Forms cross platform UI control to facilitate UI for mobile PIN (MPIN) entry.
This control can be used for Login using PIN, Creting New PIN, Change PIN, Entering secure OTP screens in your mobile application.

## Nuget Package
https://www.nuget.org/packages/XFPINView/

### Platforms Supported
- [X] iOS
- [X] Android
- [ ] UWP (To be Checked)

## iOS : Screenshots
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-iOS.png" width="600">
</kbd>

## Android : Screenshots
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-Android.png" width="600">
</kbd>

## Steps
1. Search for XFPINView [nuget](https://www.nuget.org/packages/XFPINView/) package and install it in your Xamarin.Forms core project. 
2. In your Page, add reference to this package:
```xmlns:xfpinview="clr-namespace:XFPINView;assembly=XFPINView"```
3. Use the control like below:
```
<xfpinview:PINView
    BoxBackgroundColor="#FEDBD0"
    BoxShape="Circle"
    PINLength="5"
    PINValue="{Binding PIN}"
    Color="#442C2E" />
```                

## Properties
### BoxShape
Defines a shape of PIN Boxes. There are 3 pre-defined shapes available:
- Squere
- RoundCorner
- Circle
```
<xfpinview:PINView 
    BoxShape="Circle" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-BoxShapes.png" width="400">
</kbd>

### Color
Defines a color of Borders and Dots of each PIN Box
```
<xfpinview:PINView 
    Color="Red" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-Color.png" width="200">
</kbd>

### BoxBackgroundColor
Defines a color of each PIN Box Background. This is area outside of the dot but inside of the Border of the box. 
```
 <xfpinview:PINView
    BoxBackgroundColor="#DCEDC8"
    PINValue="{Binding PIN}"
    Color="#33691E" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-BoxBackgroundColor.png" width="400">
</kbd>

### PINLength
Defines the Length of PIN your app supports
```
<xfpinview:PINView 
    PINLength="5" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-PINLength.png" width="250">
</kbd>

### PINValue
The Bindable PIN value user enters as an input
```
<xfpinview:PINView 
    PINLength="5" 
    PINValue="{Binding PIN}" />
```

### BoxSize
Defines the Width and Height of each PIN Box
```
<xfpinview:PINView
    BoxSize="50"
    PINLength="5" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-BoxSize.png" width="400">
</kbd>

### BoxSpacing
Defines the space among each PIN Box.
```
<xfpinview:PINView
    BoxSpacing="10"
    PINLength="5" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-BoxSpacing.png" width="400">
</kbd>


## Future Roadmap:
- [ ] Provide option to show entry as Password or normal text input.
- [ ] Show Focus indicator
- [ ] Add invalid input / error animation
