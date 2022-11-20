// See https://aka.ms/new-console-template for more information
using RedisStudies;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Text;

Console.WriteLine("Hello, World!");

/*
var connString = $"redis://{Host}?ssl=true&sslprotocols=Tls12&password={Password.UrlEncode()}";
var redisManager = new RedisManagerPool(connString);
using var client = redisManager.GetClient();
 */



// Get Set Example
using (IRedisNativeClient client = new RedisClient())
{
    //client.Del("redis");

    if (client.Exists("redis") == 0)
        client.Set("redis", Encoding.UTF8.GetBytes("Hello c# world"));


    var result = client.Get("redis");

    Console.WriteLine(Encoding.UTF8.GetString(result));
}

using (IRedisClient client = new RedisClient())
{

    var exampleList = client.Lists["ex:custom_list"];
    if (exampleList.Count() > 0)
        exampleList.RemoveAll();

    exampleList.Add("Sinan");
    exampleList.Add("Ali");
    exampleList.Add("Mehmet");

    var redisExampleList = client.Lists["ex:custom_list"];

    foreach (var name in redisExampleList)
    {
        Console.WriteLine(name);
    }


    IRedisTypedClient<dtoUser> userClient = client.As<dtoUser>();

    dtoUser customer = new dtoUser()
    {
        Id = userClient.GetNextSequence(),
        Name = "Sinan Bayraktutan",
        Addresses = new List<dtoAddres>
            {
                new dtoAddres {Info = "Ankara/Çankaya"},
                new dtoAddres {Info = "Sinop/Merkez"},

            }
    };

    var storedCustomer = userClient.Store(customer);
    Console.WriteLine("User Dto Eklendi. Id: " + storedCustomer.Id);

    var getUserClient = client.As<dtoAddres>();
    var getUser = userClient.GetById(storedCustomer.Id);

    Console.WriteLine("resdis Id: {0}, Name: {1}", getUser.Id, getUser.Name);


}


Console.ReadKey();