# XFPINView (Xamarin.Forms UI Control)
XFPINView is Xamarin.Forms cross platform UI control to facilitate UI for mobile MPIN entry.
This control can be used for Crete New PIN, Change PIN screen in your mobile application.

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

## Properties
### 1. BoxShape
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

### 2. Color
Defines a color of Borders and Dots of each PIN Box
```
<xfpinview:PINView 
    Color="Red" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-Color.png" width="200">
</kbd>

### 3. PINLength
Defines the Length of PIN your app supports
```
<xfpinview:PINView 
    PINLength="5" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-PINLength.png" width="250">
</kbd>

### 4. PINValue
The Bindable PIN value user enters as an input
```
<xfpinview:PINView 
    PINLength="5" 
    PINValue="{Binding PIN}" />
```

### 5. BoxSize
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

### 6. BoxSpacing
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
