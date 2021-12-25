# TextChangeEventArgs

Event arguments passed by the triggered OnTextChange event in controls:

- ExtendedPasswordBox 
- ExtendedTextBox 

### Attributes:

| Type   | Name                    | Description |
|:------:|:-----------------------:|:------------|
| bool   | ProgrammaticallyChanged | Determines if OnTextChange event was triggered by code or user input. |
| String | Text                    | Entered/Changed text. |

### Constructors:

* <ins>public TextChangeEventArgs(string **text**, bool **programmaticallyChanged**)</ins>
  
  **text** - entered/changed text,
  **programmaticallyChanged** - invoked by the code or user input,
