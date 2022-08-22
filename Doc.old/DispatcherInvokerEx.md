# DispatcherInvokerEx
Utility for safe dispatching an event or method from component.  

namespace: _chkam05.Tools.ControlsEx.Utilities.DispatcherInvokerEx_  

### Attributes:

| Type             | Name       | Description |
|:----------------:|:----------:|:------------|
| Dispatcher       | Dispatcher | Interface component dispatcher that invokes the method. |
| Stack<Exception> | Exceptions | Stack of exceptions that Were thrown during execution of the method. |

### Constructors: 

- **DispatcherInvokerEx**  

| Argument Type | Argument Name | Description |
|:-------------:|:-------------:|:------------|
| Dispatcher    | dispatcher    | Interface component dispatcher. |

### Events: 

- _None_  

### Methods: 

- **TryInvoke**  

| Argument Type | Argument Name  | Description |
|:-------------:|:--------------:|:------------|
| Action        | invokingMethod | Action/method that will be invoked by dispatcher. |
