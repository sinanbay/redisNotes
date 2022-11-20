// See https://aka.ms/new-console-template for more information
using ServiceStack.Redis;

Console.WriteLine("Hello, World!");

using (IRedisClient client = new RedisClient())
{
    var sub = client.CreateSubscription();
    sub.OnMessage = (c, m) => Console.WriteLine("Got message: {0}, from channel {1}", c, m);

    sub.SubscribeToChannels("sinanChannel");
}
