using Lib.Emailing.Extensions;
using Nano.App.Api;
using Nano.Data.Extensions;
using Nano.Data.MySql;
using Nano.Eventing.Extensions;
using Nano.Eventing.RabbitMq;
using Nano.Logging.Extensions;
using Nano.Logging.Serilog;
using Svc.Emailing.Data;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoLogging<SerilogProvider>();
        x.AddNanoData<MySqlProvider, EmailingDbContext>();
        x.AddNanoEventing<RabbitMqProvider>();

        x.AddEmailing();
    })
    .Build()
    .Run();
