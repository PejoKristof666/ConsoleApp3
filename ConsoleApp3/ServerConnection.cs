using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp3;

internal class ServerConnection
{
    HttpClient client = new HttpClient();
    string baseUrl = "";
    public ServerConnection(string url)
    {
        if (!url.StartsWith("http://")) throw new ArgumentException("Hibás url (http://)");
        baseUrl = url;
    }

    public async Task<List<Subject>> GetSubjects()
    {
        List<Subject> result = new List<Subject>();
        string url = baseUrl + "/allsubject";
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            result = JsonSerializer.Deserialize<List<Subject>>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }

    public async Task<Message> PostSubject(string name)
    {
        Message message = new Message();
        string url = baseUrl + "/createsubject";

        try
        {
            var jsonData = new
            {
                name = name
            };
            string jsonString = JsonSerializer.Serialize(jsonData);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return message;
    }

    public async Task<Subject> BiggestSubject()
    {
        Subject result = null;
        string url = baseUrl + "/biggestsubject";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            result = JsonSerializer.Deserialize<Subject>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }

    public async Task<Subject> SmallestSubject()
    {
        Subject result = null;
        string url = baseUrl + "/smallestsubject";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            result = JsonSerializer.Deserialize<Subject>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }

    public async Task<Message> DeleteSubject(int id)
    {
        Message message = new Message();
        string url = $"{baseUrl}/deleteSubject/{id}";

        try
        {
            HttpResponseMessage response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }

        return message;
    }

    //hehe















    //public async Task<List<User>> GetUsers()
    //{
    //    List<User> result = new List<User>();
    //    string url = baseUrl + "/user";
    //    try
    //    {
    //        HttpResponseMessage response = await client.GetAsync(url);
    //        response.EnsureSuccessStatusCode();
    //        result = JsonSerializer.Deserialize<List<User>>(await response.Content.ReadAsStringAsync());
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e.Message);
    //    }

    //    return result;
    //}

    //public async Task<Message> PostUser(string username, string password)
    //{
    //    Message message = new Message();
    //    string url = baseUrl + "/create";

    //    try
    //    {
    //        var jsonData = new
    //        {
    //            username = username,
    //            password = password
    //        };
    //        string jsonString = JsonSerializer.Serialize(jsonData);
    //        HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
    //        HttpResponseMessage response = await client.PostAsync(url, content);
    //        response.EnsureSuccessStatusCode();
    //        message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
    //    }
    //    catch (Exception e) 
    //    {
    //        Console.WriteLine(e.Message);
    //    }

    //    return message;
    //}
}
