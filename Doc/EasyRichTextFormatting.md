# EasyRichTextFormatting
Class for handling and presenting text/font properties inherited from _INotifyPropertyChanged_.

namespace: _chkam05.Tools.ControlsEx.Colors_

### Attributes:

| Type          | Name                        | Description |
|:--------------|:----------------------------|:------------|
| Brush         | FontBackground              | Font background color. |
| Brush         | FontColor                   | Font foreground color. |
| FontFamily    | FontFamily                  | Font family. |
| double        | FontSize                    | Font size. |
| FontStyle     | FontStyle                   | Font style (normal/italic). |
| FontWeight    | FontWeight                  | Font weight (normal/bold). |
| TextAlignment | TextAlignment               | Text alignment (left/center/right). |
| | | |
| bool          | TextDecorationBaseline      | Text decoration line under text. |
| bool          | TextDecorationOverLine      | Text decoration line over text. |
| bool          | TextDecorationStrikethrough | Text decoration line strikethrough text. |
| bool          | TextDecorationUnderline     | Text decoration line under text. |

### Constructors:

- _None_

### Events:

| Type                          | Name             | Description |
|:------------------------------|:-----------------|:------------|
| PropertyChangedEventHandler   | PropertyChanged  | Event invoked after changing property. |

### Methods:

- **Clone**  
Create color object from hexadecimal color code representation.

| Type                   | Parameter Name | Description |
|:-----------------------|:---------------|:------------|
| EasyRichTextFormatting | RETURN         | Object clone. |
