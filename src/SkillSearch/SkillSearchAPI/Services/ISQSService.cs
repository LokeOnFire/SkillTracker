using Amazon.SQS.Model;
using SkillSearchAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSearchAPI.Services
{
    public interface ISQSService
    {
        Task<SendMessageResponse> SendMessageToSQSQueue(MessageRequest result);
    }
}
