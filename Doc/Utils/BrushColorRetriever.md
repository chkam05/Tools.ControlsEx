# BrushColorRetriever

Utility static class that provides one method that allows to get a color from Brush types, that is:

- SolidColorBrush
- LinearGradientBrush
- RadialGradientBrush

### Methods:

* <ins>public static Color GetColorFromBrush(Brush **brush**, Color? **defaultColor** = null)</ins>

  *Get color from brush (SolidColorBrush, LinearGradientBrush, RadialGradientBrush).*
  
  * **brush** - Brush the color will be taken from. 
  * **defaultColor** - Default return color, if the brush will not be recognised, will hasn't any color, or will be null.

