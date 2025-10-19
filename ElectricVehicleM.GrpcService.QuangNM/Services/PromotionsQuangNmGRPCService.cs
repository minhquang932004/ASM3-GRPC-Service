using ElectricVehicleM.GrpcService.QuangNM.Protos;
using ElectricVehicleM.Services.QuangNM;
using Grpc.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ElectricVehicleM.GrpcService.QuangNM.Services
{
    public class PromotionsQuangNmGRPCService : PromotionsQuangNmGRPC.PromotionsQuangNmGRPCBase
    {
        private readonly IServiceProviders _serviceProviders;
        public PromotionsQuangNmGRPCService(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        public override async Task<PromotionsQuangNmList> GetAllAsync(EmptyRequest request, ServerCallContext context)
        {
            // Initialize result
            var result = new PromotionsQuangNmList();

            try
            {
                // Get data from service
                var promotions = await _serviceProviders.PromotionsQuangNmService.GetAllAsync();
                // Serialize with options to handle reference loops and ignore nulls
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Convert to JSON string
                var promotionsJson = JsonSerializer.Serialize(promotions, opt);
                // Deserialize JSON string to list of PromotionsQuangNm
                var items = JsonSerializer.Deserialize<List<PromotionsQuangNm>>(promotionsJson, opt);
                // Add items to result
                result.Items.AddRange(items);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }

            return result;
        }
    }
}
