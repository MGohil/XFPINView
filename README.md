# XFPINView (Xamarin.Forms UI Control)
XFPINView is Xamarin.Forms cross platform UI control to facilitate UI for mobile MPIN entry.
This control can be used for Crete New PIN, Change PIN screen in your mobile application.

### Platforms Supported
- [X] iOS
- [X] Android
- [ ] UWP (To be Checked)

## iOS : Screenshots
<img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-iOS.png" width="600">

## Android : Screenshots
<img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-Android.png" width="600">

## Properties
### 1. BoxShape (Defines a shape of PIN Boxes)
- Squere
- RoundCorner
- Circle
```
<xfpinview:PINView 
    BoxShape="Circle" 
    PINValue="{Binding PIN}" />
```
<img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-BoxShapes.png" width="400">

### 2. Color (Defines a color of Border and Dots of PIN Boxes)
```
<xfpinview:PINView 
    Color="Red" 
    PINValue="{Binding PIN}" />
```
<img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-Color.png" width="200">

### 3. PINLength (Defines the Length of PIN your app supports)
```
<xfpinview:PINView 
    PINLength="5" 
    PINValue="{Binding PIN}" />
```
<img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-PINLength.png" width="250">
