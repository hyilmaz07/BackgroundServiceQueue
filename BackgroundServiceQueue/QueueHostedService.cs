using BackgroundServiceQueue.Services;
using System.Xml.Linq;

namespace BackgroundServiceQueue
{
    public class QueueHostedService : BackgroundService
    {
        private readonly ILogger<QueueHostedService> logger;
        private readonly INameQueueService nameQueueService;


        public QueueHostedService(ILogger<QueueHostedService> logger, INameQueueService nameQueueService)
        {
            this.logger = logger;
            this.nameQueueService = nameQueueService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                while (nameQueueService.HasNext())
                {
                    var name = nameQueueService.DeQueue();

                    await Task.Delay(1000);//db işlemini simüle etmek için 1 saniye beklettik

                    logger.LogInformation($"ExecuteAsync worked for {name}");
                }
                logger.LogInformation($"ExecuteAsync worked for Anything");

            }
        }
    }
}
