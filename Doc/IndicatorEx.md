# BaseIndicatorEx
Inherited from _Control_ and _INotifyPropertyChanged_.  

namespace: _chkam05.Tools.ControlsEx.Indicators.BaseIndicatorEx_  

### Attributes:

| Type                | Name              | Description |
|:-------------------:|:-----------------:|:------------|
| Brush               | Fill              | BaseIndicatorEx geometry fill color. |
| Brush               | Pen               | BaseIndicatorEx geometry border color. |
|||
| double              | AnimationSpeed    | BaseIndicatorEx animation speed (time between frames). |
| CornerRadius        | CornerRadius      | BaseIndicatorEx corner radius. |
| Geometry            | PathData          | BaseIndicatorEx **virtual** indicator drawing. |
| Thickness           | PenThickness      | BaseIndicatorEx geometry border thickness. |
|||
| DispatcherInvokerEx | DispatcherInvoker | Dispatcher invoker for invoke animation methods running on separate thread. |
|||
| **Get only**        ||
| bool                | IsPathEditable    | BaseIndicatorEx **virtual readonly** parameter that defines if geomatry path is editable. |

### Constructors: 

- **default**  

### Events: 

| Type                          | Name                  | Description |
|:-----------------------------:|:---------------------:|:------------|
| PropertyChangedEventHandler   | PropertyChanged       | Event invoked after property changed. |
| IndicatorAnimationEnd         | AnimationEnded        | Event invoked when animation process stops. |
| IndicatorAnimationFrameUpdate | AnimationFrameUpdated | Event invoked when animation process start next frame (basicly event for animation calculations in sub classes). |

### Methods: 

| Type  | Name           | Description |
|:-----:|:--------------:|:------------|
| void  | StartAnimation | Method for start animation (animation is active by default). |
| void  | StopAnimation  | Method for stop animation. |


# CircleSmoothIndicatorEx
Inherited from _BaseIndicatorEx_ and _INotifyPropertyChanged_.  

namespace: _chkam05.Tools.ControlsEx.Indicators.CircleSmoothIndicatorEx_  

![IndicatorEx Examples (../Images/IndicatorEx.jpg)](../Images/IndicatorEx.jpg)  

### Additional Attributes:

| Type           | Name                   | Description |
|:--------------:|:----------------------:|:------------|
| double         | IndicatorThickness     | CircleSmoothIndicatorEx thickness. |
|||
|||
| **Get only**:  ||
| bool           | IsPathEditable         | BaseIndicatorEx **virtual readonly** parameter that defines if geomatry path is editable = (**false**). |
| Point          | InnerArcEndPoint       | CircleSmoothIndicatorEx inner arc end point. |
| bool           | InnerArcLarge          | CircleSmoothIndicatorEx inner arc flip side. |
| double         | InnerArcRotationAngle  | CircleSmoothIndicatorEx inner arc rotation angle. |
| Size           | InnerArcSize           | CircleSmoothIndicatorEx inner arc size. |
| Point          | InnerArcStartPoin      | CircleSmoothIndicatorEx inner arc start point. |
| SweepDirection | InnerArcSweepDirection | CircleSmoothIndicatorEx inner arc sweep direction. |
| Point          | OuterArcEndPoint       | CircleSmoothIndicatorEx outer arc end point. |
| bool           | OuterArcLarge          | CircleSmoothIndicatorEx outer arc flip side. |
| double         | OuterArcRotationAngle  | CircleSmoothIndicatorEx outer arc rotation angle. |
| Size           | OuterArcSize           | CircleSmoothIndicatorEx outer arc size. |
| Point          | OuterArcStartPoin      | CircleSmoothIndicatorEx outer arc start point. |
| SweepDirection | OuterArcSweepDirection | CircleSmoothIndicatorEx outer arc sweep direction. |
| Geometry       | PathData               | BaseIndicatorEx **virtual** indicator drawing. |

### Additional Constructors: 

- _None_  

### Additional Events: 

- _None_  

### Additional Methods: 

- _None_  
