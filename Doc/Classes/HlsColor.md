# HlsColor

HLS alternative representation of the RGB color model.  
Generally used for changing color lightness.

### Attributes:

| Type   | Name | Description |
|:------:|:----:|:------------|
| dobule | A | Alpha channel of color (0 - 255). |
| double | H | Color Hue (0 - 360). |
| double | L | Color Lightness (0 - 100). |
| double | S | Color Saturation (0 - 100). |

### Constants:

| Type   | Name          | Description |
|:------:|:-------------:|:------------|
| double | AlphaMax      | Max value of A attribute. |
| double | AlphaMin      | Min value of A attribute. |
| double | HueMax        | Max value of H attribute. |
| double | HueMin        | Min value of H attribute. |
| double | LightnessMax  | Max value of L attribute. |
| double | LightnessMin  | Min value of L attribute. |
| double | SaturationMax | Max value of S attribute. |
| double | SaturationMin | Min value of S attribute. |

### Constructors:

* <ins>public HslColor(double **a**, double **h**, double **l**, double **s**)</ins>
  
  **a** - alpha channel of color,
  **h** - color hue,
  **l** - color lightness,
  **s** - color saturation,

  <br/>

* <ins>public HslColor(double **h**, double **l**, double **s**)</ins>
  
  **h** - color hue,
  **l** - color lightness,
  **s** - color saturation,

