# redisNotes
It is a c# project created while learning redis. I installed the redis with docker. I ran generic codes via redis-cli. I've attached my notes here.


-- let's make Redis over Docker
https://redis.io/docs/stack/get-started/install/docker/
docker run -d --name myRedis -p 6379:6379 redis/redis-stack-server:latest

-- connect redis cli
docker exec -it myRedis redis-cli

-- useful notes
https://redis.io/docs/data-types/tutorial/
KEYS *
//all delete
FLUSHALL 
SET name Sinan
SET lnname Bayraktutan
GET name
GET lnname
EXISTS lnname
DEL lnname
APPEND lnname Bayrak
APPEND lnname tutan
HSET user name Sinan
HSET user lnname Bayraktutan
HSET user email sinanbayraktutan67@gmail.com
hget user email
hgetall user
set deleteData "delete me" EX 5

SUBSCRIBE listeningChannel

PUBLISH listeningChannel "Wellcome"

//create list and add data
lpush customList 1 2 3 4
//list add item from the bottom
//Adding an element from the bottom to the list
rpush customList 5
//Deleting the top element of the list.
lpop customList
//Deleting the bottom element of the list.
rpop customList
//Extracting certain ranges of the list with index
lrange key startindex stopindex
lrange customList 0 2
//Find out the length of the list
llen key
llen customList
//Extracting a certain index from the list
lindex key index
lindex customList 3
//Override to a specific index of the list
lset key index overnumber
lset customList 0 9
//If we don't know the number of elements of the list, get the whole
lrange key 0 -1
lrange customList 0 -1
//Do not check if there is a list and do not push it. Returns 0 if incorrect
lpushx key insertnum
lpush customList 1



--Resources I used for C# project
https://docs.redis.com/latest/rs/references/client_references/client_csharp/
https://docs.servicestack.net/redis/

I included the ServiceStack.Redis package in the project. As an example, I created project codes.
