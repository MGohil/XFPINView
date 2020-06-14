# XFPINView (Xamarin.Forms UI Control)
XFPINView is Xamarin.Forms cross platform UI control to facilitate UI for mobile PIN (MPIN), OTP, Verification Code entry.
This control can be used for Login using PIN, Creting New PIN, Change PIN, Entering secure OTP screens in your mobile application.

![](https://github.com/MGohil/XFPINView/blob/master/Arts/xfpinview-showcase.gif)

<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Preview-Graphic.png" width="800">
</kbd>

## Nuget Package
https://www.nuget.org/packages/XFPINView/

### Platforms Supported
- [X] iOS
- [X] Android
- [X] UWP

## iOS : Screenshots
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-iOS.png" width="550">
</kbd>

## Android : Screenshots
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-Android.png" width="550">
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
## Properties Definitions
| Property | Type | Default | Description |
| ----------| --- | --- | --- |
| AutoDismissKeyboard | Boolean | False | Decides whether to dismiss the keyboard automatically when all charecters entered |
| BoxBackgroundColor | Color | Transparent | Defines the BackgroundColor of each PIN Box |
| BoxBorderColor | Color | Color Property Value | Defines the Border Color of each PIN Box |
| BoxFocusColor | Color | Black | Defines the Focus Indicator Border Color when PIN Box is Focused |
| BoxFocusAnimation | Enum | None | Animates the Box when it receives the Focus. Enum values [ None, ZoomInOut, ScaleUp ]|
| BoxShape | Enum | Circle | Defines the shape of PIN Box from Enum values [ Squere, RoundCorner, Circle ] |
| BoxSize | Double | 50 | Defines the Width and Height of each PIN Box |
| BoxSpacing | Double | 5 | Defines the space among each PIN Box |
| Color | Color | Accent | Defines the Color of PIN Box (Border and Dot) |
| IsPassword | Boolean | True | Defines whether to show actual input character or hide / secure via Dot |
| PINInputType | Enum | Numeric | Defines the Input Type from Enum [ Numeric, AlphaNumeric ] |
| PINLength | Integer | 4 | Defines the Length (No. of Characters) of the PIN |
| PINValue | String | Empty | Bind this to string Property in your ViewModel, to get value of the Entered PIN |


## Commands / Events Definitions
| Command / Event | Type | Description |
| ----------| --- | --- |
| PINEntryCompletedCommand | Command | A Bindable Command, which gets invoked on completion of the PIN entry (All charecters are entered) You can execute your code through this command |
| PINEntryCompleted | Event | Invokes on completion of the PIN entry (when all charecters are entered). |


## Snippets / Screenshots
### BoxShape
```
<xfpinview:PINView 
    BoxShape="Circle" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-BoxShapes.png" width="400">
</kbd>

### Color
```
<xfpinview:PINView 
    Color="Red" 
    PINValue="{Binding PIN}" />
```
<kbd>
    <img src="https://github.com/MGohil/XFPINView/blob/master/Arts/Sample-Color.png" width="200">
</kbd>

### BoxBackgroundColor
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
- [X] Provide option to show entry as Password or normal text input.
- [X] Show Focus indicator
- [ ] Add invalid input / error animation
