# Json-Schema-Generator-ScriptCs


Creates a Json Schema of all Models implementing JsonObjectAttibute from Newtonsoft.Json package.

**Example: **
*In MyTest.dll a file MyTest.cs contains the following*:

```C#
  [JsonObject]
  public class MyModel {
     public int Id { get; set; }
  }
```

**Execute**
  scriptcs Generate.csx -- "MyTest/bin/MyTest.dll" "SchemaFolder"
  
  
##SetUp

Install and setup up scriptcs [SciptCs][http://scriptcs.net/]

Install Newtonsoft.Json 
 *scriptcs -install Newtonsoft.Json*
 
##Executing

scriptcs Generate.csx -- "{**path of dll**}" "{**destination folder**}"

##Copyright and License

Licensed under the Apache License