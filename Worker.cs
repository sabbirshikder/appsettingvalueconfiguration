namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly SMSServiceConfiguration _smsServiceConfiguration;
        public Worker(ILogger<Worker> logger, SMSServiceConfiguration smsServiceConfiguration)
        {
            _logger = logger;
            _smsServiceConfiguration = smsServiceConfiguration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", _smsServiceConfiguration.servicenumber);

                String looppath = System.IO.Path.GetFullPath("E:\\GCTL\\appsettingsData");//Path
                                                                                           //Check if directory exist
                if (!System.IO.Directory.Exists(looppath))
                {
                    System.IO.Directory.CreateDirectory(looppath); //Create directory if it doesn't exist
                }
                string loopfilename = DateTime.Now.Ticks + ".txt";
                //set the image path
                string loopimgPath = Path.Combine(looppath, loopfilename);
                if (System.IO.File.Exists(loopimgPath))
                {
                    System.IO.File.Delete(loopimgPath);
                }

                File.WriteAllText(loopimgPath, "port number: "+ _smsServiceConfiguration.portnumber +", service number: "+ _smsServiceConfiguration.servicenumber
                    +"server ip: "+_smsServiceConfiguration.serverip+", port: "+_smsServiceConfiguration.serverport+", database name: "+_smsServiceConfiguration.databasename
                    );

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}