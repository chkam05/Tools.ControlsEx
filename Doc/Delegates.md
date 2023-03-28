# Delegates
Class with defined Delegates for extended components events.

namespace: _chkam05.Tools.ControlsEx.Events_

### Delegates

- **ColorsPalleteSelectionChanged**  
Delegate for [ColorsPaletteEx](ColorsPaletteEx.md) component.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| object | sender         | Object that invoked event. |
| [ColorsPaletteSelectionChangedEventArgs](ColorsPaletteSelectionChangedEventArgs.md)  | e | Event arguments. |

- **IndicatorAnimationEnd**  
Delegate for [BaseIndicatorEx](BaseIndicatorEx.md) component.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| object | sender         | Object that invoked event. |

- **IndicatorAnimationFrameUpdate**  
Delegate for [BaseIndicatorEx](BaseIndicatorEx.md) component.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| object | sender         | Object that invoked event. |

- **InternalMessageClose<T>**  
Delegate for [BaseInternalMessageEx](BaseInternalMessageEx.md) component.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| object | sender         | Object that invoked event. |
| T      | e              | Event arguments based on [InternalMessageCloseEventArgs](InternalMessageCloseEventArgs.md). |

- **InternalMessageHide**  
Delegate for [BaseInternalMessageEx](BaseInternalMessageEx.md) component.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| object | sender         | Object that invoked event. |
| [InternalMessageHideEventArgs](InternalMessageHideEventArgs.md)  | e | Event arguments. |

- **UpDownDoubleModifiedEventHandler**  
Delegate for [UpDownDoubleTextBoxEx](UpDownDoubleTextBoxEx.md) component.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| object | sender         | Object that invoked event. |
| [UpDownDoubleModifiedEventArgs](UpDownDoubleModifiedEventArgs.md) | e | Event arguments. |

- **UpDownLongModifiedEventHandler**  
Delegate for [UpDownLongTextBoxEx](UpDownLongTextBoxEx.md) component.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| object | sender         | Object that invoked event. |
| [UpDownLongModifiedEventArgs](UpDownLongModifiedEventArgs.md) | e | Event arguments. |
