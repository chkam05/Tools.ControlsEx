# FontUtilities
Static utility for managing fonts.

namespace: _chkam05.Tools.ControlsEx.Utilities_

### Attributes:

| Type                 | Name        | Description |
|:---------------------|:------------|:------------|
| FontFamilyInfo       | DefaultFont | Default font family. |
| List<FontFamilyInfo> | SystemFonts | System font families. |

### Methods:

- **FindFontByName**  
Find font family in list by it's name.

| Type                        | Parameter Name   | Description |
|:----------------------------|:-----------------|:------------|
| FontFamilyInfo              | RETURN           | Found font family or default font. |
| IEnumerable<FontFamilyInfo> | fonts            | Font families list. |
| string                      | familyName       | Font name. |

- **FindFontByNameAndSubName**  
Find font family in list by it's name and subname.

| Type                        | Parameter Name   | Description |
|:----------------------------|:-----------------|:------------|
| FontFamilyInfo              | RETURN           | Found font family or default font. |
| IEnumerable<FontFamilyInfo> | fonts            | Font families list. |
| string                      | familyName       | Font name. |
| string                      | familySubName    | Font subname. |

- **GetTextAlignments**  
Get list of all available text alignments.

| Type                | Parameter Name | Description |
|:--------------------|:---------------|:------------|
| List<TextAlignment> | RETURN         | List of all available text alignments. |

- **GetStretches**  
Get list of all available font stretch values.

| Type              | Parameter Name | Description |
|:------------------|:---------------|:------------|
| List<FontStretch> | RETURN         | List of all available font stretch values. |

- **GetStyles**  
Get list of all available font style values.

| Type            | Parameter Name | Description |
|:----------------|:---------------|:------------|
| List<FontStyle> | RETURN         | List of all available font style values. |

- **GetWeights**  
Get list of all available font weight values.

| Type             | Parameter Name | Description |
|:-----------------|:---------------|:------------|
| List<FontWeight> | RETURN         | List of all available font weight values. |
