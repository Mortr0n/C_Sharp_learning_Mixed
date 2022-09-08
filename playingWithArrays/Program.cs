using System.Collections.Generic;
using System;

List<string> bikes = new List<string>();

bikes.Add("Kawasaki");
bikes.Add("Triumph");
bikes.Add("BMW");
bikes.Add("Moto Guzzi");
bikes.Add("Harley Davidson");
bikes.Add("Suzuki");

Console.WriteLine(bikes[2]);
Console.WriteLine($"We currently know of {bikes.Count} motorcycle manufacturers.");

for (var i = 0; i < bikes.Count; i++) 
{
    Console.WriteLine("-" + bikes[i]);
}

bikes.Insert(2, "Yamaha");
bikes.Remove("Suzuki");
bikes.Remove("Yamaha");
bikes.RemoveAt(0);

Console.WriteLine("List of Non-Japanese Manufacturers:");
foreach(string manu in bikes)
{
    Console.WriteLine("-" + manu);
}

Dictionary<string, string> profile = new Dictionary<string, string>();
profile.Add("Name", "Speros");
profile.Add("Language", "PHP");
profile.Add("Location", "Greece");
Console.WriteLine("Instructor Profile");
Console.WriteLine("Name - " + profile["Name"]);
Console.WriteLine("From - " + profile["Location"]);
Console.WriteLine("Favorite Language - " + profile["Language"]);

Console.WriteLine("Dictionary ForEach");
foreach (KeyValuePair<string, string> entry in profile)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}

foreach (var entry in profile)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}

Console.WriteLine(args);