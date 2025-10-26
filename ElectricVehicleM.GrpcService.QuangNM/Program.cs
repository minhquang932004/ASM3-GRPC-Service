using ElectricVehicleM.GrpcService.QuangNM.Services;
using ElectricVehicleM.Repositories.QuangNM;
using ElectricVehicleM.Repositories.QuangNM.DBContext;
using ElectricVehicleM.Services.QuangNM;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<FA25_PRN232_SE1717_G1_ElectricVehicleManagementContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<PromotionsQuangNmGRPCService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
