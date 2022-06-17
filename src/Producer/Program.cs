

using System.Text.Json;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Messages;

var sqs = new AmazonSQSClient(RegionEndpoint.USEast1);

var myQueue = await sqs.GetQueueUrlAsync("my-queue");

while (true)
{

    var msg = Console.ReadLine();
    await sqs.SendMessageAsync(new SendMessageRequest
    {
        QueueUrl = myQueue.QueueUrl,
        MessageBody = JsonSerializer.Serialize(new Message1 { Name = msg })
    });
}