# TextDecorationsHelper
Static utility for managing text decorations.

namespace: _chkam05.Tools.ControlsEx.Utilities_

### Methods:

- **AddDecoration**  
Add text decoration to text decoration collection.

| Type                     | Parameter Name | Description |
|:-------------------------|:---------------|:------------|
| TextDecorationCollection | RETURN         | Updated text decoration collection. |
| TextDecorationCollection | collection     | Text decoration collection to update. |
| TextDecorationLocation   | textDecoration | Text decoration to add. |

- **ClearDecorations**  
Clear text decoration collection.

| Type                     | Parameter Name | Description |
|:-------------------------|:---------------|:------------|
| TextDecorationCollection | RETURN         | Updated text decoration collection. |
| TextDecorationCollection | collection     | Text decoration collection to clear. |

- **GetTextDecorations**  
Get all applied text decorations from text decoration collection.

| Type                         | Parameter Name | Description |
|:-----------------------------|:---------------|:------------|
| List<TextDecorationLocation> | RETURN         | List of applied text decorations. |
| TextDecorationCollection     | collection     | Text decoration collection. |

- **HasDecroation**  
Check if text decoration is applied in text decoration collection.

| Type                     | Parameter Name | Description |
|:-------------------------|:---------------|:------------|
| bool                     | RETURN         | True - text decoration is applied; False - otherwise. |
| TextDecorationCollection | collection     | Text decoration collection. |
| TextDecorationLocation   | textDecoration | Text decoration to check. |

- **RemoveDecoration**  
Remove text decoration from text decoration collection.

| Type                     | Parameter Name | Description |
|:-------------------------|:---------------|:------------|
| TextDecorationCollection | RETURN         | Updated text decoration collection. |
| TextDecorationCollection | collection     | Text decoration collection to update. |
| TextDecorationLocation   | textDecoration | Text decoration to remove. |

- **AddDecoration**  
Add text decoration to selected text.

| Type                   | Parameter Name | Description |
|:-----------------------|:---------------|:------------|
| bool                   | RETURN         | True - decoration added; False - otherwise. |
| TextRange              | textRange      | Selected text as TextRange. |
| TextDecorationLocation | textDecoration | Text decoration to add. |

- **ClearDecorations**  
Clear text decoration from selected text.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| bool      | RETURN         | True - decorations cleared; False - otherwise. |
| TextRange | textRange      | Selected text as TextRange. |

- **GetTextDecorations**  
Get all applied text decorations from selected text.

| Type                         | Parameter Name | Description |
|:-----------------------------|:---------------|:------------|
| List<TextDecorationLocation> | RETURN         | List of applied text decorations. |
| TextRange                    | textRange      | Selected text as TextRange. |

- **HasDecroation**  
Check if text decoration is applied in selected text.

| Type                   | Parameter Name | Description |
|:-----------------------|:---------------|:------------|
| bool                   | RETURN         | True - text decoration is applied; False - otherwise. |
| TextRange              | textRange      | Selected text as TextRange. |
| TextDecorationLocation | textDecoration | Text decoration to check. |

- **RemoveDecoration**  
Remove text decoration from selected text.

| Type                   | Parameter Name | Description |
|:-----------------------|:---------------|:------------|
| bool                   | RETURN         | True - decoration removed; False - otherwise. |
| TextRange              | textRange      | Selected text as TextRange. |
| TextDecorationLocation | textDecoration | Text decoration to remove. |

- **GetTextDecorationsCollection**  
Get text decorations collection from selected text.

| Type                     | Parameter Name | Description |
|:-------------------------|:---------------|:------------|
| TextDecorationCollection | RETURN         | Text decorations collection. |
| TextRange                | textRange      | Selected text as TextRange. |

- **UpdateTextDecorationsCollection**  
Update text decorations collection in selected text.

| Type                     | Parameter Name | Description |
|:-------------------------|:---------------|:------------|
| TextRange                | textRange      | Selected text to update. |
| TextDecorationCollection | collection     | Text decorations collection. |
