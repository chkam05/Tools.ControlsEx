# EasyRichParagraphProperties
Class for handling and presenting paragraph properties inherited from _INotifyPropertyChanged_.

namespace: _chkam05.Tools.ControlsEx.Colors_

### Attributes:

| Type                  | Name                             | Description |
|:----------------------|:---------------------------------|:------------|
| Brush                 | Background                       | Paragraph background color. |
| Brush                 | BorderBrush                      | Paragraph border color. |
| Thickness             | BorderThickness                  | Paragraph border thickness. |
| bool                  | BreakColumnBefore                | Automatically insert a column break before. |
| bool                  | BreakPageBefore                  | Automatically insert a page break before. |
| FlowDirection         | FlowDirection                    | Paragraph text flow direction. |
| Brush                 | Foreground                       | Paragraph foreground text color. |
| bool                  | IsHyphenationEnabled             | Automatic word splitting. |
| bool                  | KeepTogether                     | Prevent text breaks by page break or column break. |
| bool                  | KeepWithNext                     | Block the break between this paragraph and the next. |
| double                | LineHeight                       | Paragraph line height. |
| LineStackingStrategy  | LineStackingStrategy             | Paragraph line stacking strategy. |
| Thickness             | Margin                           | Paragraph margin. |
| Thickness             | Padding                          | Paragraph padding. |
| | | |
| FontFamily            | FontFamily                       | Paragraph font family. |
| double                | FontSize                         | Paragraph font size. |
| FontStyle             | FontStyle                        | Paragraph font style (normal/italic). |
| FontWeight            | FontWeight                       | Paragraph font weight (normal/bold). |
| TextAlignment         | TextAlignment                    | Paragraph text alignment. |
| | | |
| bool                  | TextDecorationBaseline           | Paragraph text decoration line under text. |
| bool                  | TextDecorationOverLine           | Paragraph text decoration line over text. |
| bool                  | TextDecorationStrikethrough      | Paragraph text decoration line strikethrough text. |
| bool                  | TextDecorationUnderline          | Paragraph text decoration line under text. |
| | | |
| int                   | TypographyAnnotationAlternates   | Alternative annotation form index. |
| FontCapitals          | TypographyCapitals               | Capitals. |
| bool                  | TypographyCapitalSpacing         | Adjusting text spacing to improve readability. |
| bool                  | TypographyCaseSensitiveForms     | Adjusting glyph positions vertically to better fit capital letters. |
| bool                  | TypographyContextualAlternates   | Allows the use of custom glyph forms based on the text rendering context. |
| bool                  | TypographyContextualLigatures    | Enable contextual ligatures. |
| int                   | TypographyContextualSwashes      | Context swing form index. |
| bool                  | TypographyDiscretionaryLigatures | Enable discretionary ligatures. |
| bool                  | TypographyEastAsianExpertForms   | Replacing the standard Japanese font forms with the corresponding preferred typographic forms. |
| FontEastAsianLanguage | TypographyEastAsianExpertForms   | Version of the east asian glyphs to use for the specified writing system or language. |
| FontEastAsianWidths   | TypographyEastAsianWidths        | The proportional width to use for Latin characters in an East Asian font. |
| FontFraction          | TypographyFraction               | Fraction style. |
| bool                  | TypographyHistoricalForms        | Enable historical forms. |
| bool                  | TypographyHistoricalLigatures    | Enable historical ligatures. |
| bool                  | TypographyKerning                | Enable kerning. |
| bool                  | TypographyMathematicalGreek      | Replacing the standard typographic font form of the Greek glyphs with the corresponding font forms commonly used in mathematical notation. |
| FontNumeralAlignment  | TypographyNumeralAlignment       | Width alignment when using numbers. |
| FontNumeralStyle      | TypographyNumeralStyle           | Set of glyphs used to render alternate forms of numeric fonts. |
| bool                  | TypographySlashedZero            | Replace zero with slashed zero. |
| bool                  | TypographyStandardLigatures      | Enable standard ligatures. |
| int                   | TypographyStandardSwashes        | Index of the standard swashes form. |
| int                   | TypographyStylisticAlternates    | Index of an alternative stylistic form. |
| bool                  | TypographyStylisticSet1          | Font form stylistic set 1. |
| bool                  | TypographyStylisticSet2          | Font form stylistic set 2. |
| bool                  | TypographyStylisticSet3          | Font form stylistic set 3. |
| bool                  | TypographyStylisticSet4          | Font form stylistic set 4. |
| bool                  | TypographyStylisticSet5          | Font form stylistic set 5. |
| bool                  | TypographyStylisticSet6          | Font form stylistic set 6. |
| bool                  | TypographyStylisticSet7          | Font form stylistic set 7. |
| bool                  | TypographyStylisticSet8          | Font form stylistic set 8. |
| bool                  | TypographyStylisticSet9          | Font form stylistic set 9. |
| bool                  | TypographyStylisticSet10         | Font form stylistic set 10. |
| bool                  | TypographyStylisticSet11         | Font form stylistic set 11. |
| bool                  | TypographyStylisticSet12         | Font form stylistic set 12. |
| bool                  | TypographyStylisticSet13         | Font form stylistic set 13. |
| bool                  | TypographyStylisticSet14         | Font form stylistic set 14. |
| bool                  | TypographyStylisticSet15         | Font form stylistic set 15. |
| bool                  | TypographyStylisticSet16         | Font form stylistic set 16. |
| bool                  | TypographyStylisticSet17         | Font form stylistic set 17. |
| bool                  | TypographyStylisticSet18         | Font form stylistic set 18. |
| bool                  | TypographyStylisticSet19         | Font form stylistic set 19. |
| bool                  | TypographyStylisticSet20         | Font form stylistic set 20. |
| FontVariants          | TypographyVariants               | A variation of the standard typographic form. |

### Constructors:

- _None_

### Events:

| Type                          | Name             | Description |
|:------------------------------|:-----------------|:------------|
| PropertyChangedEventHandler   | PropertyChanged  | Event invoked after changing property. |

### Methods:

- **Clone**  
Create color object from hexadecimal color code representation.

| Type                        | Parameter Name | Description |
|:----------------------------|:---------------|:------------|
| EasyRichParagraphProperties | RETURN         | Object clone. |
