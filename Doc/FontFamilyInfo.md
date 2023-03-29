# FontFamilyInfo
Class for handling and presenting font family inherited from _INotifyPropertyChanged_.

namespace: _chkam05.Tools.ControlsEx.Colors_

### Attributes:

| Type       | Name         | Description |
|:-----------|:-------------|:------------|
| FontFamily | FontFamily   | Font family. |
| string     | Name         | Font family name. |
| string     | SubName      | Font family sub name. |
| bool       | IsCustomFont | Specifies whether the font is loaded from an external file. |

### Constructors:

- Empty constructor.  

| Type       | Name         | Description |
|:-----------|:-------------|:------------|
| FontFamily | fontFamily   | Font family. |
| bool       | isAppFont    | Is font loade from an external file (font used only in app not system-wide). |

### Events:

| Type                          | Name             | Description |
|:------------------------------|:-----------------|:------------|
| PropertyChangedEventHandler   | PropertyChanged  | Event invoked after changing property. |

### Overrided methods and operators:

| Name     | Description |
|:---------|:------------|
| ToString | Returns font name and subname for view in list or dropdown. |

### Methods:

- _None_
