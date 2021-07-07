using IBMMQResilientClient;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Jobs
{
    [DisallowConcurrentExecution]
    public class MessageSendJob : IJob
    {
        private readonly ILogger<MessageSendJob> _logger;
        private readonly IQueueWriter _queueWriter;

        public MessageSendJob(ILogger<MessageSendJob> logger, IQueueWriter queueWriter)
        {
            _logger = logger;
            _queueWriter = queueWriter;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _queueWriter.Enqueue(new QueueMessage { CorrelationId = "1", Data = "json", QueueName = "Name" });
            _logger.LogInformation("Hello world!");
            return Task.CompletedTask;
        }
    }
}
