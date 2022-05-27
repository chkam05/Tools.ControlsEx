# MenuEx
Extended Menu Control inherited from _Menu_ and _INotifyPropertyChanged_.  

namespace: _chkam05.Tools.ControlsEx.MenuEx_  

![MenuEx Examples 1 (../Images/MenuEx1.jpg)](../Images/MenuEx1.jpg)  

![MenuEx Examples 2 (../Images/MenuEx2.jpg)](../Images/MenuEx2.jpg)  

### Additional Attributes:

| Type         | Name                   | Description |
|:------------:|:----------------------:|:------------|
| Brush        | SubMenuBackground      | MenuEx sub menu background color. |
| Brush        | SubMenuBorderBrush     | MenuEx sub menu border color. |
|||
| Thickness    | SubMenuBorderThickness | MenuEx sub menu border thickness. |
| CornerRadius | SubMenuCornerRadius    | MenuEx sub menu corner radius. |
| Thickness    | SubMenuPadding         | MenuEx sub menu padding. |

### Additional Constructors: 

- _None_  

### Additional Events: 

| Type                        | Name             | Description                            |
|:---------------------------:|:----------------:|:---------------------------------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after property changed. |

### Additional Methods: 

- _None_  


# MenuItemEx
Extended MenuItem Control inherited from _MenuItem_ and _INotifyPropertyChanged_.  

namespace: _chkam05.Tools.ControlsEx.MenuItemEx_  

### Additional Attributes:

| Type          | Name                   | Description |
|:-------------:|:----------------------:|:------------|
| Brush         | CheckMarkColorBrush    | MenuItemEx check mark color. |
| Brush         | IconColorBrush         | MenuItemEx icon color. |
| Brush         | MouseOverBackground    | MenuItemEx background color when cursor is over. |
| Brush         | MouseOverBorderBrush   | MenuItemEx border color when cursor is over. |
| Brush         | MouseOverForeground    | MenuItemEx foreground color when cursor is over. |
|||
| CheckBoxStyle | CheckBoxStyle          | MenuItemEx checkbox style. |
| double        | CheckMarkHeight        | MenuItemEx checkbox height. |
| Thickness     | CheckMarkMargin        | MenuItemEx checkbox margin. |
| double        | CheckMarkMaxHeight     | MenuItemEx checkbox max height. |
| double        | CheckMarkMaxWidth      | MenuItemEx checkbox max width. |
| double        | CheckMarkMinHeight     | MenuItemEx checkbox min height. |
| double        | CheckMarkMinWidth      | MenuItemEx checkbox min width. |
| double        | CheckMarkWidth         | MenuItemEx checkbox width. |
|||
| double        | IconHeight             | MenuItemEx icon height. |
| PackIconKind  | IconKind               | MenuItemEx icon (see related repositories). |
| Thickness     | IconMargin             | MenuItemEx icon margin. |
| double        | IconMaxHeight          | MenuItemEx icon max height. |
| double        | IconMaxWidth           | MenuItemEx icon max width. |
| double        | IconMinHeight          | MenuItemEx icon min height. |
| double        | IconMinWidth           | MenuItemEx icon min width. |
| double        | IconWidth              | MenuItemEx icon width. |
|||
| CornerRadius  | SubMenuCornerRadius    | MenuItemEx corner radius. |

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
_Used as CheckBox Mark and Icon in MenuItemEx_