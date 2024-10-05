#region Starter_Menu

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

Console.WriteLine("Welcome To Api Consume");
Console.WriteLine();
Console.WriteLine("Select one what do you want!");
Console.WriteLine("1 - Get Cities List");
Console.WriteLine("2 - Get City and Temp List");
Console.WriteLine("3 - Add New City");
Console.WriteLine("4 - Delete City");
Console.WriteLine("5 - Update City");
Console.WriteLine("6 - Get City By ID");
Console.WriteLine();

#endregion

string number;

Console.Write("Your choose:");
number = Console.ReadLine();

if (number == "1")
{
    string url = "https://localhost:7281/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);
        foreach (var item in jArray)
        {
            Console.WriteLine("City ID: " + item["cityId"].ToString());
            Console.WriteLine("City Name: " + item["cityName"].ToString());
            Console.WriteLine();
        }
    }
}

else if (number == "2")
{
    string url = "https://localhost:7281/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);
        foreach (var item in jArray)
        {

            Console.WriteLine("City Name: " + item["cityName"].ToString());
            Console.WriteLine("City Name: " + item["temp"].ToString());
            Console.WriteLine();
        }
    }
}

else if (number == "3")
{
    Console.WriteLine("Add New City");
    Console.WriteLine();
    string cityName, country, detail;
    decimal temp;
    Console.Write("City Name:");
    cityName = Console.ReadLine();
    Console.Write("Country:");
    country = Console.ReadLine();
    Console.Write("Temp:");
    temp = decimal.Parse(Console.ReadLine());
    Console.Write("Detail:");
    detail = Console.ReadLine();

    string url = "https://localhost:7281/api/Weathers";
    var newWeather = new
    {
        CityName = cityName,
        Country = country,
        Temp = temp,
        Detail = detail
    };
    using (HttpClient client = new HttpClient())
    {
        string json = JsonConvert.SerializeObject(newWeather);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

    }
}

else if (number == "4")
{
    Console.WriteLine("Delete City");
    string url = "https://localhost:7281/api/Weathers";
    Console.Write("Choose the ID that you would like to delete.");
    int id = int.Parse(Console.ReadLine());
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.DeleteAsync(url + id);
        response.EnsureSuccessStatusCode();
    }
}

else if (number == "5")
{
    Console.WriteLine("Update City");
    Console.WriteLine();
    string cityName, country, detail;
    decimal temp;
    int cityId;
    Console.Write("City Name:");
    cityName = Console.ReadLine();
    Console.Write("Country:");
    country = Console.ReadLine();
    Console.Write("Temp:");
    temp = decimal.Parse(Console.ReadLine());
    Console.Write("Detail:");
    detail = Console.ReadLine();

    Console.Write("City ID:");
    cityId = int.Parse(Console.ReadLine());
    var newWeather = new
    {
        CityId = cityId,
        CityName = cityName,
        Country = country,
        Temp = temp,
        Detail = detail
    };

    string url = "https://localhost:7281/api/Weathers";

    using (HttpClient client = new HttpClient())
    {

        string json = JsonConvert.SerializeObject(newWeather);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, content);
        response.EnsureSuccessStatusCode();
    }
}
else if (number == "6")
{
    string url = "https://localhost:7281/api/Weathers";
    Console.Write("Choose the ID that you would like to get.");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url +id);
        string responseBody = await response.Content.ReadAsStringAsync();
        JObject jObject = JObject.Parse(responseBody);
        string cityName = jObject["CityName"].ToString();
        string country = jObject["Country"].ToString();
        decimal temp = decimal.Parse(jObject["Temp"].ToString());
        string detail = jObject["Detail"].ToString();
        Console.WriteLine("City Name: " + cityName);
        Console.WriteLine("Country: " + country);
        Console.WriteLine("Temp: " + temp);
        Console.WriteLine("Detail: " + detail);
        response.EnsureSuccessStatusCode();

    }

}
else
{
    Console.WriteLine("Invalid Choose");
}

Console.Read();
