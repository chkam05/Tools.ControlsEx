# BaseInternalMessageEx
Extended Internal Message inherited from _Page_, _[IInternalMessageEx](IInternalMessageEx.md)_ and _INotifyPropertyChanged_.

namespace: _chkam05.Tools.ControlsEx.InternalMessages_

![BaseInternalMessageEx Example 1 (Images/BaseInternalMessageEx.png)](../Images/BaseInternalMessageEx.png)

![BaseInternalMessageEx Example 2 (Images/BaseInternalMessageExHideable.png)](../Images/BaseInternalMessageExHideable.png)

### Additional Attributes:

| Type                  | Name                       | Description |
|:----------------------|:---------------------------|:------------|
| Brush                 | BorderBrush                | InternalMessageEx border color. |
| Brush                 | BottomBackground           | InternalMessageEx bottom part background color. |
| Brush                 | BottomBorderBrush          | InternalMessageEx bottom part border color. |
| Thickness             | BottomBorderThickness      | InternalMessageEx bottom part border thickness. |
| Thickness             | BottomPadding              | InternalMessageEx bottom part padding. |
| Brush                 | ButtonBackground           | InternalMessageEx buttons background color. |
| Brush                 | ButtonBorderBrush          | InternalMessageEx buttons border color. |
| Brush                 | ButtonForeground           | InternalMessageEx buttons foreground color. |
| Brush                 | ButtonMouseOverBackground  | InternalMessageEx buttons background color when mouse is over. |
| Brush                 | ButtonMouseOverBorderBrush | InternalMessageEx buttons border color when mouse is over. |
| Brush                 | ButtonMouseOverForeground  | InternalMessageEx buttons foreground color when mouse is over. |
| Brush                 | ButtonPressedBackground    | InternalMessageEx buttons background color when is pressed. |
| Brush                 | ButtonPressedBorderBrush   | InternalMessageEx buttons border color when is pressed. |
| Brush                 | ButtonPressedForeground    | InternalMessageEx buttons foreground color when is pressed. |
| Thickness             | ButtonBorderThickness      | InternalMessageEx buttons border thickness. |
| Brush                 | HeaderBackground           | InternalMessageEx header part background color. |
| Brush                 | HeaderBorderBrush          | InternalMessageEx header part border color. |
| Thickness             | HeaderBorderThickness      | InternalMessageEx header part border thickness. |
| Brush                 | HeaderForeground           | InternalMessageEx header part foreground color. |
| Thickness             | HeaderPadding              | InternalMessageEx header part padding. |
||||
| double                | IconHeight                 | InternalMessageEx header icon height. |
| PackIconKind          | IconKind                   | InternalMessageEx header icon kind (see related repositories). |
| Thickness             | IconMargin                 | InternalMessageEx header icon margin. |
| double                | IconMaxHeight              | InternalMessageEx header icon max height. |
| double                | IconMaxWidth               | InternalMessageEx header icon max width. |
| double                | IconMinHeight              | InternalMessageEx header icon min height. |
| double                | IconMinWidth               | InternalMessageEx header icon min width. |
| double                | IconWidth                  | InternalMessageEx header icon width. |
||||
| FontFamily            | TitleFontFamily            | InternalMessageEx title font family. |
| double                | TitleFontSize              | InternalMessageEx title font size. |
| FontStretch           | TitleFontStretch           | InternalMessageEx title font stretch. |
| FontStyle             | TitleFontStyle             | InternalMessageEx title font style. |
| FontWeight            | TitleFontWeight            | InternalMessageEx title font weight. |
| Thickness             | TitleMargin                | InternalMessageEx title margin. |
||||
| Thickness             | BorderThickness            | InternalMessageEx border thickness. |
| CornerRadius          | CornerRadius               | InternalMessageEx corner radius. |
| Thickness             | ContentPadding             | InternalMessageEx content padding. |
| Thickness             | Padding                    | InternalMessageEx padding (all components inside). |
||||
| bool                  | AllowHide                  | Allow to hide internal message (it shows Hide button). |
| **Get Only**          |||
| bool                  | IsHidden                   | Check if internal message has been hidden. |
| bool                  | IsLoadingComplete          | Check if internal message has been fully loaded. |
| [InternalMessageResult](InternalMessageResult.md) | Result | Result value, depends on clicked button. |
| bool                  | UseCustomHeaderForegroundBrush    | Use HeaderForeground for header part foreground color, instead of global Foreground. |
| bool                  | UseCustomSectionBreaksBorderBrush | Use BottomBorderBrush and HeaderBorderBrush for brush color for those parts, instead of global BorderBrush. |

### Constructors:

| Type                  | Parameter Name | Description |
|:----------------------|:---------------|:------------|
| [InternalMessagesExContainer](InternalMessagesExContainer.md) | parentContainer | Internal messages ex container where message will be displayed. |

### Additional Events:

| Type                        | Name             | Description |
|:----------------------------|:-----------------|:------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after changing property. |
| InternalMessageClose<[CloseEventArgs](InternalMessageCloseEventArgs.md)> | OnClose | Event invoked after closing internal message. |
| InternalMessageHide         | OnHide           | Event invoked after hiding internal message. |

### Additional Methods:

- **Close**  
Manually close message.

- **CreateCloseEventArgs** (_protected virtual_)  
Create instance of close event arguments class or inheritet from it.

| Type                          | Parameter Name | Description |
|:------------------------------|:---------------|:------------|
| [CloseEventArgs](InternalMessageCloseEventArgs.md) | RETURN | Instance of close event arguments class or inherited from it. |

- **Hide**  
Manually hide message.

- **CreateHideEventArgs** (_protected virtual_)  
Create instance of internal message hide event arguments.

| Type                          | Parameter Name | Description |
|:------------------------------|:---------------|:------------|
| [InternalMessageHideEventArgs](InternalMessageHideEventArgs.md) | RETURN | Instance of internal message hide event arguments. |

- **Show**  
Manually show message if is hidden.

### Related components:

- [InternalMessagesExContainer](InternalMessagesExContainer.md)  
Is default container component for InternalMessageEx components.

# Related repositories

materialdesigninxaml (PackIconKind): https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit
