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
    public class MessageGetJob : IJob
    {
        private readonly ILogger<MessageGetJob> _logger;
        private readonly IQueueReader _queueReader;

        public MessageGetJob(ILogger<MessageGetJob> logger, IQueueReader queueReader)
        {
            _logger = logger;
            _queueReader = queueReader;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _queueReader.Dequque();
            return Task.CompletedTask;
        }
    }
}
