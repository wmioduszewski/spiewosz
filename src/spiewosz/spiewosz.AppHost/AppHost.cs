var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.spiewosz_WebApp>("spiewosz-webapp");

builder.Build().Run();
