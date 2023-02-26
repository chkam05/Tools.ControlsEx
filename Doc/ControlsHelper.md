# ControlsHelper
Static utility for controls management.

namespace: _chkam05.Tools.ControlsEx.Utilities_

### Methods:

- **IsControlVisible**  
Check if control is visible (checking also parent components).

| Type             | Parameter Name   | Description |
|:-----------------|:-----------------|:------------|
| bool             | RETURN           | True - component is visible; False - otherwise. |
| FrameworkElement | element          | Component as FrameworkElement. |

- **GetParentElement**  
Get parent component from current child component.

| Type             | Parameter Name   | Description |
|:-----------------|:-----------------|:------------|
| FrameworkElement | element          | Child component. |
| FrameworkElement | RETURN           | Parent component. |
