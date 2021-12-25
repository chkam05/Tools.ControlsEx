# NumericTextValidator

Utility that check if entered text is numeric and makes correction to be numeric text.

### Attributes: 

| Type   | Name               | Description |
|:------:|:------------------:|:------------|
| string | CorrectText        | Corrected text after inputing invalid numeric text. <br/> (Backup of previous text). |
| bool   | FloatingPointValue | Setting option for allow floating point numeric values. |

### Constructors: 

* <ins>public NumericTextValidator()</ins>

### Methods: 

* <ins>public bool Validate(string **value**)</ins>
  
  *Method for validate if entered string value is numeric value or not.*  
  *It returns true/false if entered value is numeric or not, and sets internal attribute **CorrectText** to that text if text is numeric.*

  * **value** - string value containing number.

<br/>

* <ins>public bool ValidateOnTextBox(TextBox **textBox**)</ins>

  *Method for validate if entered text to textbox is numeric value or not.*  
  *It returns true/false if entered value is numeric or not, and sets internal attribute **CorrectText** to that text if text is numeric.*  
  *If text is not numeric, it revert text in textbox to previous value from intenal attribute **CorrectText**.*

  * **textBox** - textbox control that contains text to check.
