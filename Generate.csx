using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

Console.WriteLine(@"    
     ____.                       _________      .__                           
    |    | __________   ____    /   _____/ ____ |  |__   ____   _____ _____   
    |    |/  ___/  _ \ /    \   \_____  \_/ ___\|  |  \_/ __ \ /     \\__  \  
/\__|    |\___ (  <_> )   |  \  /        \  \___|   Y  \  ___/|  Y Y  \/ __ \_
\________/____  >____/|___|  / /_______  /\___  >___|  /\___  >__|_|  (____  /
              \/           \/          \/     \/     \/     \/      \/     \/ 
  ________                                   __                
 /  _____/  ____   ____   ________________ _/  |_  ___________ 
/   \  ____/ __ \ /    \_/ __ \_  __ \__  \\   __\/  _ \_  __ \
\    \_\  \  ___/|   |  \  ___/|  | \// __ \|  | (  <_> )  | \/
 \______  /\___  >___|  /\___  >__|  (____  /__|  \____/|__|   
        \/     \/     \/     \/           \/                   
  _________            .__        __   _________         
 /   _____/ ___________|__|______/  |_ \_   ___ \  ______
 \_____  \_/ ___\_  __ \  \____ \   __\/    \  \/ /  ___/
 /        \  \___|  | \/  |  |_> >  |  \     \____\___ \ 
/_______  /\___  >__|  |__|   __/|__|   \______  /____  >
        \/     \/         |__|                 \/     \/ ");

var jsonSchemaGenerator = new JsonSchemaGenerator();
Assembly assembly = Assembly.LoadFrom(Env.ScriptArgs[0]);

var folder = (Env.ScriptArgs.Count > 1) ? Env.ScriptArgs[1] : "";

foreach (Type type in assembly.GetTypes()) {
	foreach (var jsonObjectType in type.GetCustomAttributes()) {
		if (jsonObjectType.ToString().Equals("Newtonsoft.Json.JsonObjectAttribute")) {
			Console.WriteLine("Creating file for " + type.Name);
			var schema = jsonSchemaGenerator.Generate(type);
			schema.Title = type.Name; 
			var writer = new StringWriter();
			var jsonTextWriter = new JsonTextWriter(writer);
			schema.WriteTo(jsonTextWriter);
			var parsedJson = JsonConvert.DeserializeObject(writer.ToString());
			var prettyString = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
			var fileWriter = new StreamWriter(Path.Combine(folder,String.Format("{0}.json",schema.Title)));
			fileWriter.WriteLine(prettyString);
			fileWriter.Close();
		}
	}
}

Console.WriteLine("Completed!");
