# EasyRichTextManager
Utility for text modification in RichTextBoxEx.

namespace: _chkam05.Tools.ControlsEx.Utilities_

### Attributes:

| Type      | Name         | Description |
|:----------|:-------------|:------------|
| TextRange | SelectedText | Selected text as TextRange. |

### Constructors:

| Type        | Parameter Name | Description |
|:------------|:---------------|:------------|
| RichTextBox | richTextBox    | RichTextBox component. |

### Additional Events:

| Type                                                | Name             | Description |
|:----------------------------------------------------|:-----------------|:------------|
| EventHandler<EasyRichTextSelectionChangedEventArgs> | SelectionChanged | Event invoked after changing text selection. |


### Methods:

- **GetSelectedParagraphProperties**  
Get [EasyRichParagraphProperties](EasyRichParagraphProperties.md) from selected text paragraph.

| Type                                                          | Parameter Name | Description |
|:--------------------------------------------------------------|:---------------|:------------|
| [EasyRichParagraphProperties](EasyRichParagraphProperties.md) | RETURN         | Selected text paragraph properties. |

- **GetSelectedParagraphBackground**  
Get background brush property from selected text paragraph.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | RETURN         | Selected text paragraph background brush property. |

- **GetSelectedParagraphBorderBrush**  
Get border brush property from selected text paragraph.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | RETURN         | Selected text paragraph border brush property. |

- **GetSelectedParagraphBorderThickness**  
Get border thickness property from selected text paragraph.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| Thickness | RETURN         | Selected text paragraph border thickness property. |

- **GetSelectedParagraphBreakColumnBefore**  
Get BreakColumnBefore property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph BreakColumnBefore property. |

- **GetSelectedParagraphBreakPageBefore**  
Get BreakPageBefore property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph BreakPageBefore property. |

- **GetSelectedParagraphFlowDirection**  
Get FlowDirection property from selected text paragraph.

| Type          | Parameter Name | Description |
|:--------------|:---------------|:------------|
| FlowDirection | RETURN         | Selected text paragraph FlowDirection property. |

- **GetSelectedParagraphForeground**  
Get foreground text brush property from selected text paragraph.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | RETURN         | Selected text paragraph foreground text brush property. |

- **GetSelectedParagraphIsHyphenationEnabled**  
Get IsHyphenationEnabled property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph IsHyphenationEnabled property. |

- **GetSelectedParagraphKeepTogether**  
Get KeepTogether property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph KeepTogether property. |

- **GetSelectedParagraphKeepWithNext**  
Get KeepWithNext property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph KeepWithNext property. |

- **GetSelectedParagraphLineHeight**  
Get line height property from selected text paragraph.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| double | RETURN         | Selected text paragraph line height property. |

- **GetSelectedParagraphLineStackingStrategy**  
Get LineStackingStrategy property from selected text paragraph.

| Type                 | Parameter Name | Description |
|:---------------------|:---------------|:------------|
| LineStackingStrategy | RETURN         | Selected text paragraph LineStackingStrategy property. |

- **GetSelectedParagraphMargin**  
Get margin property from selected text paragraph.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| Thickness | RETURN         | Selected text paragraph margin property. |

- **GetSelectedParagraphPadding**  
Get padding property from selected text paragraph.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| Thickness | RETURN         | Selected text paragraph padding property. |

- **GetSelectedParagraphTextIndent**  
Get TextIndent property from selected text paragraph.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| double | RETURN         | Selected text paragraph TextIndent property. |

- **GetSelectedParagraphFontFamily**  
Get text font family property from selected text paragraph.

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| FontFamily | RETURN         | Selected text paragraph font family property. |

- **GetSelectedParagraphFontSize**  
Get text font size property from selected text paragraph.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| double | RETURN         | Selected text paragraph font size property. |

- **GetSelectedParagraphFontStyle**  
Get text font style property from selected text paragraph.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| FontStyle | RETURN         | Selected text paragraph font style property. |

- **GetSelectedParagraphFontWeight**  
Get text font weight property from selected text paragraph.

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| FontWeight | RETURN         | Selected text paragraph font weight property. |

- **GetSelectedParagraphTextAlignment**  
Get text alignment property from selected text paragraph.

| Type          | Parameter Name | Description |
|:--------------|:---------------|:------------|
| TextAlignment | RETURN         | Selected text alignment for paragraph property. |

- **GetSelectedParagraphBaseline**  
Get text baseline decoration property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph baseline text decoration property. |

- **GetSelectedParagraphTextOverLine**  
Get text overline decoration property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph overline text decoration property. |

- **GetSelectedParagraphTextStrikethrough**  
Get text strikethrough decoration property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph strikethrough text decoration property. |

- **GetSelectedParagraphTextUnderline**  
Get text underline decoration property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph underline text decoration property. |

- **GetSelectedParagraphTypographyAnnotationAlternates**  
Get AnnotationAlternates property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| int  | RETURN         | Selected text paragraph AnnotationAlternates property. |

- **GetSelectedParagraphTypographyCapitals**  
Get Capitals property from selected text paragraph.

| Type         | Parameter Name | Description |
|:-------------|:---------------|:------------|
| FontCapitals | RETURN         | Selected text paragraph Capitals property. |

- **GetSelectedParagraphTypographyCapitalSpacing**  
Get CapitalSpacing property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph CapitalSpacing property. |

- **GetSelectedParagraphTypographyCaseSensitiveForms**  
Get CaseSensitiveForms property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph CaseSensitiveForms property. |

- **GetSelectedParagraphTypographyContextualAlternates**  
Get ContextualAlternates property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph ContextualAlternates property. |

- **GetSelectedParagraphTypographyContextualLigatures**  
Get ContextualLigatures property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph ContextualLigatures property. |

- **GetSelectedParagraphTypographyContextualSwashes**  
Get ContextualSwashes property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| int  | RETURN         | Selected text paragraph ContextualSwashes property. |

- **GetSelectedParagraphTypographyDiscretionaryLigatures**  
Get DiscretionaryLigatures property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph DiscretionaryLigatures property. |

- **GetSelectedParagraphTypographyEastAsianExpertForms**  
Get EastAsianExpertForms property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph EastAsianExpertForms property. |

- **GetSelectedParagraphTypographyEastAsianLanguage**  
Get EastAsianLanguage property from selected text paragraph.

| Type                  | Parameter Name | Description |
|:----------------------|:---------------|:------------|
| FontEastAsianLanguage | RETURN         | Selected text paragraph EastAsianLanguage property. |

- **GetSelectedParagraphTypographyEastAsianWidths**  
Get EastAsianWidths property from selected text paragraph.

| Type                | Parameter Name | Description |
|:--------------------|:---------------|:------------|
| FontEastAsianWidths | RETURN         | Selected text paragraph EastAsianWidths property. |

- **GetSelectedParagraphTypographyFraction**  
Get Fraction property from selected text paragraph.

| Type         | Parameter Name | Description |
|:-------------|:---------------|:------------|
| FontFraction | RETURN         | Selected text paragraph Fraction property. |

- **GetSelectedParagraphTypographyHistoricalForms**  
Get HistoricalForms property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph HistoricalForms property. |

- **GetSelectedParagraphTypographyHistoricalLigatures**  
Get HistoricalLigatures property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph HistoricalLigatures property. |

- **GetSelectedParagraphTypographyKerning**  
Get Kerning property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph Kerning property. |

- **GetSelectedParagraphTypographyMathematicalGreek**  
Get MathematicalGreek property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph MathematicalGreek property. |

- **GetSelectedParagraphTypographyNumeralAlignment**  
Get NumeralAlignment property from selected text paragraph.

| Type                 | Parameter Name | Description |
|:---------------------|:---------------|:------------|
| FontNumeralAlignment | RETURN         | Selected text paragraph NumeralAlignment property. |

- **GetSelectedParagraphTypographyNumeralStyle**  
Get NumeralStyle property from selected text paragraph.

| Type             | Parameter Name | Description |
|:-----------------|:---------------|:------------|
| FontNumeralStyle | RETURN         | Selected text paragraph NumeralStyle property. |

- **GetSelectedParagraphTypographySlashedZero**  
Get SlashedZero property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph SlashedZero property. |

- **GetSelectedParagraphTypographyStandardLigatures**  
Get StandardLigatures property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph StandardLigatures property. |

- **GetSelectedParagraphTypographyStandardSwashes**  
Get StandardSwashes property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| int  | RETURN         | Selected text paragraph StandardSwashes property. |

- **GetSelectedParagraphTypographyStylisticAlternates**  
Get StylisticAlternates property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| int  | RETURN         | Selected text paragraph StylisticAlternates property. |

- **GetSelectedParagraphTypographyStylisticSet**  
Get StylisticSet(n) property from selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text paragraph StylisticSet1(n) property. |
| int  | setIndex       | Stylistic set index from 1 to 20. |

- **GetSelectedParagraphTypographyVariants**  
Get Variants property from selected text paragraph.

| Type         | Parameter Name | Description |
|:-------------|:---------------|:------------|
| FontVariants | RETURN         | Selected text paragraph Variants property. |

- **SetSelectedParagraphProperties**  
Set paragraph properties on selected text paragraph.

| Type                                                          | Parameter Name      | Description |
|:--------------------------------------------------------------|:--------------------|:------------|
| [EasyRichParagraphProperties](EasyRichParagraphProperties.md) | paragraphProperties | Paragraph properties. |

- **SetSelectedParagraphBackground**  
Set paragraph background brush property on selected text paragraph.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | colorBrush     | Paragraph background brush property. |

- **SettSelectedParagraphBorderBrush**  
Set paragraph border brush property on selected text paragraph.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | colorBrush     | Paragraph border brush property. |

- **SetSelectedParagraphBorderThickness**  
Set paragraph border thickness property on selected text paragraph.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| Thickness | thickness      | Paragraph border thickness property. |

- **SetSelectedParagraphBreakColumnBefore**  
Set paragraph BreakColumnBefore property on selected text paragraph.

| Type | Parameter Name    | Description |
|:-----|:------------------|:------------|
| bool | breakColumnBefore | Paragraph BreakColumnBefore property. |

- **SetSelectedParagraphBreakPageBefore**  
Set paragraph BreakColumnBefore property on selected text paragraph.

| Type | Parameter Name  | Description |
|:-----|:----------------|:------------|
| bool | breakPageBefore | Paragraph BreakColumnBefore property. |

- **SetSelectedParagraphFlowDirection**  
Set paragraph FlowDirection property on selected text paragraph.

| Type          | Parameter Name | Description |
|:--------------|:---------------|:------------|
| FlowDirection | flowDirection  | Paragraph FlowDirection property. |

- **SetSelectedParagraphForeground**  
Set paragraph foreground text brush property on selected text paragraph.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | colorBrush     | Paragraph foreground text brush property. |

- **SetSelectedParagraphIsHyphenationEnabled**  
Set paragraph IsHyphenationEnabled property on selected text paragraph.

| Type | Parameter Name       | Description |
|:-----|:---------------------|:------------|
| bool | isHyphenationEnabled | Paragraph IsHyphenationEnabled property. |

- **SetSelectedParagraphKeepTogether**  
Set paragraph KeepTogether property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | keepTogether   | Paragraph KeepTogether property. |

- **SetSelectedParagraphKeepWithNext**  
Set paragraph KeepWithNext property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | keepWithNext   | Paragraph KeepWithNext property. |

- **SetSelectedParagraphLineHeight**  
Set paragraph line height property on selected text paragraph.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| double | lineHeight     | Paragraph line height property. |

- **SetSelectedParagraphLineStackingStrategy**  
Set paragraph LineStackingStrategy property on selected text paragraph.

| Type                 | Parameter Name       | Description |
|:---------------------|:---------------------|:------------|
| LineStackingStrategy | lineStackingStrategy | Paragraph LineStackingStrategy property. |

- **SetSelectedParagraphMargin**  
Set paragraph margin property on selected text paragraph.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| Thickness | margin         | Paragraph margin property. |

- **SetSelectedParagraphPadding**  
Set paragraph padding property on selected text paragraph.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| Thickness | padding        | Paragraph padding property. |

- **SetSelectedParagraphTextIndent**  
Set paragraph text indent property on selected text paragraph.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| double | textIndent     | Paragraph text indent property. |

- **SetSelectedParagraphFontFamily**  
Set paragraph text font family property on selected text paragraph.

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| FontFamily | fontFamily     | Paragraph text font family property. |

- **SetSelectedParagraphFontSize**  
Set paragraph text font size property on selected text paragraph.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| double | fontSize       | Paragraph text font size property. |

- **SetSelectedParagraphFontStyle**  
Set paragraph text font style property on selected text paragraph.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| FontStyle | fontStyle      | Paragraph text font style property. |

- **SetSelectedParagraphFontWeight**  
Set paragraph text font weight property on selected text paragraph.

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| FontWeight | fontWeight     | Paragraph text font weight property. |

- **SetSelectedParagraphTextAlignment**  
Set paragraph text alignment property on selected text paragraph.

| Type          | Parameter Name | Description |
|:--------------|:---------------|:------------|
| TextAlignment | textAlignment  | Paragraph text alignment property. |

- **SetSelectedParagraphBaseline**  
Set paragraph text baseline decoration property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | baseline       | Paragraph text baseline decoration property. |

- **SetSelectedParagraphTextOverLine**  
Set paragraph text overline decoration property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | overLine       | Paragraph text overline decoration property. |

- **SetSelectedParagraphTextStrikethrough**  
Set paragraph text strikethrough decoration property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | strikethrough  | Paragraph text strikethrough decoration property. |

- **SetSelectedParagraphTextUnderline**  
Set paragraph text underline decoration property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | underline      | Paragraph text underline decoration property. |

- **SetSelectedParagraphTypographyAnnotationAlternates**  
Set paragraph AnnotationAlternates property on selected text paragraph.

| Type | Parameter Name       | Description |
|:-----|:---------------------|:------------|
| int  | annotationAlternates | Paragraph AnnotationAlternates property. |

- **SetSelectedParagraphTypographyCapitals**  
Set paragraph Capitals property on selected text paragraph.

| Type         | Parameter Name | Description |
|:-------------|:---------------|:------------|
| FontCapitals | fontCapitals   | Paragraph Capitals property. |

- **SetSelectedParagraphTypographyCapitalSpacing**  
Set paragraph CapitalSpacing property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | capitalSpacing | Paragraph CapitalSpacing property. |

- **SetSelectedParagraphTypographyCaseSensitiveForms**  
Set paragraph CaseSensitiveForms property on selected text paragraph.

| Type | Parameter Name     | Description |
|:-----|:-------------------|:------------|
| bool | caseSensitiveForms | Paragraph CaseSensitiveForms property. |

- **SetSelectedParagraphTypographyContextualAlternates**  
Set paragraph ContextualAlternates property on selected text paragraph.

| Type | Parameter Name       | Description |
|:-----|:---------------------|:------------|
| bool | contextualAlternates | Paragraph ContextualAlternates property. |

- **SetSelectedParagraphTypographyContextualLigatures**  
Set paragraph ContextualLigatures property on selected text paragraph.

| Type | Parameter Name      | Description |
|:-----|:--------------------|:------------|
| bool | contextualLigatures | Paragraph ContextualLigatures property. |

- **SetSelectedParagraphTypographyContextualSwashes**  
Set paragraph ContextualSwashes property on selected text paragraph.

| Type | Parameter Name    | Description |
|:-----|:------------------|:------------|
| int  | contextualSwashes | Paragraph ContextualSwashes property. |

- **SetSelectedParagraphTypographyDiscretionaryLigatures**  
Set paragraph DiscretionaryLigatures property on selected text paragraph.

| Type | Parameter Name         | Description |
|:-----|:-----------------------|:------------|
| bool | discretionaryLigatures | Paragraph DiscretionaryLigatures property. |

- **SetSelectedParagraphTypographyEastAsianExpertForms**  
Set paragraph EastAsianExpertForms property on selected text paragraph.

| Type | Parameter Name       | Description |
|:-----|:---------------------|:------------|
| bool | eastAsianExpertForms | Paragraph EastAsianExpertForms property. |

- **SetSelectedParagraphTypographyEastAsianLanguage**  
Set paragraph EastAsianLanguage property on selected text paragraph.

| Type                  | Parameter Name        | Description |
|:----------------------|:----------------------|:------------|
| FontEastAsianLanguage | fontEastAsianLanguage | Paragraph EastAsianLanguage property. |

- **SetSelectedParagraphTypographyEastAsianWidths**  
Set paragraph EastAsianWidths property on selected text paragraph.

| Type                | Parameter Name      | Description |
|:--------------------|:--------------------|:------------|
| FontEastAsianWidths | fontEastAsianWidths | Paragraph EastAsianWidths property. |

- **SetSelectedParagraphTypographyFraction**  
Set paragraph Fraction property on selected text paragraph.

| Type         | Parameter Name | Description |
|:-------------|:---------------|:------------|
| FontFraction | fontFraction   | Paragraph Fraction property. |

- **SetSelectedParagraphTypographyHistoricalForms**  
Set paragraph HistoricalForms property on selected text paragraph.

| Type | Parameter Name  | Description |
|:-----|:----------------|:------------|
| bool | historicalForms | Paragraph HistoricalForms property. |

- **SetSelectedParagraphTypographyHistoricalLigatures**  
Set paragraph HistoricalLigatures property on selected text paragraph.

| Type | Parameter Name      | Description |
|:-----|:--------------------|:------------|
| bool | historicalLigatures | Paragraph HistoricalLigatures property. |

- **SetSelectedParagraphTypographyKerning**  
Set paragraph Kerning property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | kerning        | Paragraph Kerning property. |

- **SetSelectedParagraphTypographyMathematicalGreek**  
Set paragraph MathematicalGreek property on selected text paragraph.

| Type | Parameter Name    | Description |
|:-----|:------------------|:------------|
| bool | mathematicalGreek | Paragraph MathematicalGreek property. |

- **SetSelectedParagraphTypographyNumeralAlignment**  
Set paragraph NumeralAlignment property on selected text paragraph.

| Type                 | Parameter Name       | Description |
|:---------------------|:---------------------|:------------|
| FontNumeralAlignment | fontNumeralAlignment | Paragraph NumeralAlignment property. |

- **SetSelectedParagraphTypographyNumeralStyle**  
Set paragraph NumeralStyle property on selected text paragraph.

| Type             | Parameter Name   | Description |
|:-----------------|:-----------------|:------------|
| FontNumeralStyle | fontNumeralStyle | Paragraph NumeralStyle property. |

- **SetSelectedParagraphTypographySlashedZero**  
Set paragraph SlashedZero property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | slashedZero    | Paragraph SlashedZero property. |

- **SetSelectedParagraphTypographyStandardLigatures**  
Set paragraph StandardLigatures property on selected text paragraph.

| Type | Parameter Name    | Description |
|:-----|:------------------|:------------|
| bool | standardLigatures | Paragraph StandardLigatures property. |

- **SetSelectedParagraphTypographyStandardSwashes**  
Set paragraph StandardSwashes property on selected text paragraph.

| Type | Parameter Name  | Description |
|:-----|:----------------|:------------|
| int  | standardSwashes | Paragraph StandardSwashes property. |

- **SetSelectedParagraphTypographyStylisticAlternates**  
Set paragraph StylisticAlternates property on selected text paragraph.

| Type | Parameter Name      | Description |
|:-----|:--------------------|:------------|
| int  | stylisticAlternates | Paragraph StylisticAlternates property. |

- **SetSelectedParagraphTypographyStylisticSet**  
Set paragraph StylisticSet(n) property on selected text paragraph.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| int  | setIndex       | Stylistic set index. |
| bool | value          | Paragraph StylisticSet(n) property. |

- **SetSelectedParagraphTypographyVariants**  
Set paragraph Variants property on selected text paragraph.

| Type         | Parameter Name | Description |
|:-------------|:---------------|:------------|
| FontVariants | fontVariants   | Paragraph Variants property. |

- **GetSelectedTextFormatting**  
Get [EasyRichTextFormatting](EasyRichTextFormatting.md) from selected text paragraph.

| Type                                                | Parameter Name | Description |
|:----------------------------------------------------|:---------------|:------------|
| [EasyRichTextFormatting](EasyRichTextFormatting.md) | RETURN         | Selected text formatting properties. |

- **GetSelectedTextFontBackground**  
Get background brush property from selected text.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | RETURN         | Selected text background brush property. |

- **GetSelectedTextFontColor**  
Get foreground text brush property from selected text.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | RETURN         | Selected text foreground brush property. |

- **GetSelectedTextFontFamily**  
Get font family property from selected text.

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| FontFamily | RETURN         | Selected text font family property. |

- **GetSelectedTextFontSize**  
Get font size property from selected text.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| double | RETURN         | Selected text font size property. |

- **GetSelectedTextFontStyle**  
Get font style property from selected text.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| FontStyle | RETURN         | Selected text font style property. |

- **GetSelectedTextFontWeight**  
Get font weight property from selected text.

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| FontWeight | RETURN         | Selected text font weight property. |

- **GetSelectedTextAlignment**  
Get text alignment property from selected text.

| Type          | Parameter Name | Description |
|:--------------|:---------------|:------------|
| TextAlignment | RETURN         | Selected text alignment property. |

- **GetSelectedTextBaseline**  
Get text baseline decoration property from selected text.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text baseline decoration property. |

- **GetSelectedTextOverLine**  
Get text overline decoration property from selected text.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text overline decoration property. |

- **GetSelectedTextStrikethrough**  
Get text strikethrough decoration property from selected text.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text strikethrough decoration property. |

- **GetSelectedTextUnderline**  
Get text underline decoration property from selected text.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | RETURN         | Selected text underline decoration property. |

- **SetSelectedTextFormatting**  
Set font properties on selected text.

| Type                                                | Parameter Name | Description |
|:----------------------------------------------------|:---------------|:------------|
| [EasyRichTextFormatting](EasyRichTextFormatting.md) | formatting     | Font formatting properties. |

- **SetSelectedTextFontBackground**  
Set background brush property on selected text.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | colorBrush     | Background brush property. |

- **SetSelectedTextFontColor**  
Set foreground text brush property on selected text.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Brush | colorBrush     | Foreground text brush property. |

- **SetSelectedTextFontFamily**  
Set font family property on selected text.

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| FontFamily | fontFamily     | Font family property. |

- **SetSelectedTextFontSize**  
Set font size property on selected text.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| double | fontSize       | Font size property. |

- **SetSelectedTextFontStyle**  
Set font style property on selected text.

| Type      | Parameter Name | Description |
|:----------|:---------------|:------------|
| FontStyle | fontStyle      | Font style property. |

- **SetSelectedTextFontWeight**  
Set font weight property on selected text.

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| FontWeight | fontWeight     | Font weight property. |

- **SetSelectedTextAlignment**  
Set text alignment property on selected text.

| Type          | Parameter Name | Description |
|:--------------|:---------------|:------------|
| TextAlignment | textAlignment  | Text alignment property. |

- **SetSelectedTextBaseline**  
Set text baseline decoration property on selected text.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | baseline       | Text baseline decoration property. |

- **SetSelectedTextOverLine**  
Set text overline decoration property on selected text.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | overLine       | Text overline decoration property. |

- **SetSelectedTextStrikethrough**  
Set text strikethrough decoration property on selected text.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | strike         | Text strikethrough decoration property. |

- **SetSelectedTextUnderline**  
Set text underline decoration property on selected text.

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| bool | underline      | Text underline decoration property. |
