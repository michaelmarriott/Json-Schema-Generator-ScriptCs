# Json-Schema-Generator-ScriptCs


Creates a Json Schema of all Models implementing JsonObjectAttibute from Newtonsoft.Json package.

**Example: **
*In MyTest.dll a file MyTest.cs contains the following*

```C#
  [JsonObject]
  public class MyModel {
     public int Id { get; set; }
  }
```

**Execute**
  scriptcs Generate.csx -- "{**path of dll**}"
  
  
##SetUp

Install and setup up scriptcs [SciptCs][http://scriptcs.net/]

Install Newtonsoft.Json 
 *scriptcs -install Newtonsoft.Json*
 
##To Execute

scriptcs Generate.csx -- "{**path of dll**}"

