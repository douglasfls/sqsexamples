

using System.Text.Json;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Messages;

var sqs = new AmazonSQSClient(RegionEndpoint.USEast1);

var myQueue = await sqs.GetQueueUrlAsync("my-queue");

while (true)
{
    var messageReceived = await sqs.ReceiveMessageAsync(new ReceiveMessageRequest
    {
        QueueUrl = myQueue.QueueUrl,
        MaxNumberOfMessages = 1,
        VisibilityTimeout = 20,
        WaitTimeSeconds = 5
    });

    foreach (var message in messageReceived.Messages)
    {
        var msg = JsonSerializer.Deserialize<Message1>(message.Body);
        Console.WriteLine(msg);
        await sqs.DeleteMessageAsync(new DeleteMessageRequest
        {
            QueueUrl = myQueue.QueueUrl,
            ReceiptHandle = message.ReceiptHandle
        });
    }
}