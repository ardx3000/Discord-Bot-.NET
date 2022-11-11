using System.IO.Compression;
using System.Text.Json;
using Discord.Net.Queue;

namespace Discord_Bot.Module.Utilities;

//https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview?pivots=dotnet-6-0

public class JSONAdministration
{
    //Method to create a specific user in a JSON file and retrieve informations like: Username, points , activity

    //Method to search for a specific user
    
    //Method to update a specific user 

    public async Task JSONTest(string name) // Does not work , resaults in 16 .....
    {
        //add file handler
        string fileName = "Test.json";
        string Jname = name;

        string jsonString = JsonSerializer.Serialize(Jname);

        using FileStream createStream = File.Create(fileName);
        await JsonSerializer.SerializeAsync(createStream, jsonString);
        await createStream.DisposeAsync();
        Console.WriteLine(File.ReadAllText(fileName));
    }
    


}