# TabControlEx
Extended TabControl Control inherited from _TabControl_ and _INotifyPropertyChanged_.  

namespace: _chkam05.Tools.ControlsEx.TabControlEx_  

![TabControlEx Examples (Images/TabControlEx.png)](../Images/TabControlEx.png)  

### Additional Attributes:

| Type   | Name                 | Description |
|:------:|:--------------------:|:------------|
| Brush  | HeaderBackground     | TabControlEx header background color. |
| Brush  | HeaderBorderBrush    | TabControlEx header border color when cursor is over. |
|||
| CornerRadius | CornerRadius          | TabControlEx corner radius. |
| Thickness    | HeaderBorderThickness | TabControlEx header border thickness. |
| Thickness    | HeaderPadding         | TabControlEx header padding. |

### Additional Constructors: 

- _None_  

### Additional Events: 

| Type                        | Name             | Description                            |
|:---------------------------:|:----------------:|:---------------------------------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after property changed. |

### Additional Methods: 

- _None_  


# TabItemEx
Extended TabItem Control inherited from _TabItem_ and _INotifyPropertyChanged_.  

namespace: _chkam05.Tools.ControlsEx.TabItemEx_  

### Additional Attributes:

| Type   | Name                 | Description |
|:------:|:--------------------:|:------------|
| Brush  | MouseOverBackground  | TabItemEx background color when cursor is over. |
| Brush  | MouseOverBorderBrush | TabItemEx border color when cursor is over. |
| Brush  | MouseOverForeground  | TabItemEx foreground color when cursor is over. |
| Brush  | SelectedBackground   | TabItemEx background color when is selected. |
| Brush  | SelectedBorderBrush  | TabItemEx border color when is selected. |
| Brush  | SelectedForeground   | TabItemEx foreground color when is selected. |
|||
| double       | IconHeight     | TabItemEx icon height. |
| PackIconKind | IconKind       | TabItemEx icon (see related repositories). |
| Thickness    | IconMargin     | TabItemEx icon margin. |
| double       | IconMaxHeight  | TabItemEx icon max height. |
| double       | IconMaxWidth   | TabItemEx icon max width. |
| double       | IconMinHeight  | TabItemEx icon min height. |
| double       | IconMinWidth   | TabItemEx icon min width. |
| double       | IconWidth      | TabItemEx icon width. |
|||
| CornerRadius | CornerRadius   | TabItemEx corner radius. |

### Additional Constructors: 

- _None_  

### Additional Events: 

| Type                        | Name             | Description                            |
|:---------------------------:|:----------------:|:---------------------------------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after property changed. |

### Additional Methods: 

- _None_  


# Related repositories 

materialdesigninxaml (PackIconKind): https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit  
_Used as TabItemEx icon_  
