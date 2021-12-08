using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using SkillSearchAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSearchAPI.Services
{
    public class SQSService : ISQSService
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly IConfiguration _configuration;

        public SQSService(IAmazonSQS sqsClient, IConfiguration configuration)
        {
            var awsCreds = new BasicAWSCredentials(configuration.GetValue<string>("AWS:APIKey"), configuration.GetValue<string>("AWS:APIPASS"));

            var amazonSQSConfig = new AmazonSQSConfig();
            amazonSQSConfig.ServiceURL = "https://sqs.us-east-1.amazonaws.com";

            var amazonSQSClient = new AmazonSQSClient(awsCreds, amazonSQSConfig);

            _sqsClient = amazonSQSClient;
            _configuration = configuration;
        }

        public async Task<SendMessageResponse> SendMessageToSQSQueue(MessageRequest request)
        {
            var sendMessageRequest = new SendMessageRequest 
            {
                QueueUrl = _configuration.GetValue<string>("AWS:SQSQueryURL"), 
                MessageBody = request.Serialize(request)
            };

            return await _sqsClient.SendMessageAsync(sendMessageRequest);

        }
    }
}
