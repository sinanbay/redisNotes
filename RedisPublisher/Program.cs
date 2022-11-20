// See https://aka.ms/new-console-template for more information
using ServiceStack.Redis;

Console.WriteLine("Hello, World!");
using (IRedisClient client = new RedisClient())
{
    long sendCount = client.PublishMessage("sinanChannel", "Hello C#");
    Console.WriteLine("Number of subscribers sent : " + sendCount);
    string msg = Console.ReadLine();
    sendCount = client.PublishMessage("sinanChannel", msg);
    Console.WriteLine("Number of subscribers sent : " + sendCount);
}
