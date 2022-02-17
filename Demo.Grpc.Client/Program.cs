using Demo.Grpc.Service;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7052");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
       new Demo.Grpc.Service.HelloRequest { Name = "gRPC Demo" });

Console.WriteLine("from server: " + reply);
