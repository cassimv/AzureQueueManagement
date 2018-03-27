using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureQueuesModel;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AzureQueuesBusiness
{
    public class AzureQueuesBusiness
    {
        //Get the next message in the queue
        public CloudQueueMessage PeekMessageInQueue(string queueName)
        {
            var queue = GetQueuesReference(queueName);

            // Peek at the next message
            CloudQueueMessage peekedMessage = queue.PeekMessage();

            return peekedMessage;
        }

        //Get length of queue
        public int GetLengthofQueue(string queueName)
        {
            var queue = GetQueuesReference(queueName);

            // Fetch the queue attributes.
            queue.FetchAttributes();

            // Retrieve the cached approximate message count.
            return queue.ApproximateMessageCount ?? 0;
        }

        //Get the next message in the Queue
        public CloudQueueMessage GetNextMessage(string queueName)
        {
            var queue = GetQueuesReference(queueName);

            // Get the next message
            CloudQueueMessage retrievedMessage = queue.GetMessage();

            //You have 30 seconds to work with the message
            return retrievedMessage;
        }

        //Send an email to the admin with the message
        public void SendAnEmailWithAMessage(string queueName)
        {
            throw new Exception("This method needs to be implmented");
        }

        //Delete a messge in the Queue
        public void DeleteMesageInQueue(string queueName, CloudQueueMessage retrievedMessage)
        {
            var queue = GetQueuesReference(queueName);

            queue.DeleteMessage(retrievedMessage);
        }

        public void InsertMessage(string queueName, string queueMessage)
        {
            var queue = GetQueuesReference(queueName);

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage(queueMessage);

            //Add the message to the queue
            queue.AddMessage(message);
        }

        private static CloudQueue GetQueuesReference(string queueName)
        {
            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudQueueClient cloudQueue = storageAccount.CreateCloudQueueClient();

            // Retrieve reference to a previously created container.
            var queue = cloudQueue.GetQueueReference(queueName);

            // Create the table if it doesn't exist.
            queue.CreateIfNotExists();

            return queue;
        }
    }


}
