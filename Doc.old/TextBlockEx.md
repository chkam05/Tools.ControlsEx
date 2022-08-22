# TextBlockEx
Extended TextBlock Control inherited from _Control_ and _INotifyPropertyChanged_.  

namespace: _chkam05.Tools.ControlsEx.TextBlock_  

![TextBlockEx Examples (Images/TextBlockEx.png)](../Images/TextBlockEx.png)  

### Additional Attributes:

| Type         | Name           | Description |
|:------------:|:--------------:|:------------|
| CornerRadius | CornerRadius   | TextBlockEx corner radius. |
| string       | Text           | TextBlockEx text. | 

### Additional Constructors: 

- _None_  

### Additional Events: 

| Type                        | Name             | Description                            |
|:---------------------------:|:----------------:|:---------------------------------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after property changed. |

### Additional Methods: 

- _None_  


# MarqueeTextBlockEx
MarqueeTextBlockEx Control inherited from _TextBlockEx_ and _INotifyPropertyChanged_.  

namespace: _chkam05.Tools.ControlsEx.MarqueeTextBlockEx_  

### Additional Attributes:

| Type                      | Name                 | Description |
|:-------------------------:|:--------------------:|:------------|
| bool                      | MarqueeBouncing      | Enables moving text in two directions. |
| Duration                  | MarqueeDuration      | MarqueeTextBlockEx text moving speed. | 
| MarqueeTextAnimationPlace | MarqueeStartPosition | MarqueeTextBlockEx text moving start position. | 
| MarqueeTextAnimationPlace | MarqueeEndPosition   | MarqueeTextBlockEx text moving destination position. | 
| bool                      | WaitForText          | Wait for all text to be scrolled. | 
|||
| **Get only**              ||
| double                    | TextPosition         | MarqueeTextBlockEx text current position. |

### Additional Constructors: 

- _None_  

### Additional Events: 

- _None_  

### Additional Methods: 

- _None_  
