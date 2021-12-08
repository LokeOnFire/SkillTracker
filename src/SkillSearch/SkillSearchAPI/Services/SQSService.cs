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
            _sqsClient = sqsClient;
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
