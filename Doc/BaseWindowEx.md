# ButtonEx
Extended BaseWindow inherited from _Window_ and _INotifyPropertyChanged_.

namespace: _chkam05.Tools.WindowsEx_

### Additional Attributes:

- _None_

### Additional Constructors:

- _None_

### Additional Events:

| Type                        | Name             | Description |
|:----------------------------|:-----------------|:------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after changing property. |

### Additional Methods:

- **Maximize**  
Maximize window.  

- **Minimize**  
Minimize window.  

- **ResizeStart**  
Starts window resize procedure.

| Type   | Parameter Name   | Description |
|:-------|:-----------------|:------------|
| Border | resizeBorder     | Border at window corner that allows to resize window in particular direction. |
| double | cursorXPos       | Current cursor position in X axis. |
| double | cursorYPos       | Current cursor position in Y axis. |

- **ResizeMove**  
Continuing resize procedure.

| Type   | Parameter Name   | Description |
|:-------|:-----------------|:------------|
| Border | resizeBorder     | Border at window corner that allows to resize window in particular direction. |
| double | cursorXPos       | Current cursor position in X axis. |
| double | cursorYPos       | Current cursor position in Y axis. |

- **ResizeEnd**  
End window resize procedure.

| Type   | Parameter Name   | Description |
|:-------|:-----------------|:------------|
| Border | resizeBorder     | Border at window corner that allows to resize window in particular direction. |

# Related repositories

- _None_
