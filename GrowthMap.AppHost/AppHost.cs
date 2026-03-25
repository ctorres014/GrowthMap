using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<GrowthMap_Api>("apiservice");

builder.Build().Run();
