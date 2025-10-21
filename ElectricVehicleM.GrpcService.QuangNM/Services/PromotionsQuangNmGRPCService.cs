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

        public override async Task<PromotionsQuangNm> GetByIdAsync(PromotionQuangNmIdRequest request, ServerCallContext context)
        {
            try
            {
                // Get data from service
                var promotion = await _serviceProviders.PromotionsQuangNmService.GetByIdAsync(request.PromotionQuangNmid);
                // Serialize with options to handle reference loops and ignore nulls
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Convert to JSON string
                var promotionJson = JsonSerializer.Serialize(promotion, opt);
                // Deserialize JSON string to PromotionsQuangNm
                var result = JsonSerializer.Deserialize<PromotionsQuangNm>(promotionJson, opt);
                return result;
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public override async Task<MutationRelay> CreateAsync(PromotionsQuangNm request, ServerCallContext context)
        {
            try
            {
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Convert proto request to JSON string
                var promotion = JsonSerializer.Serialize(request, opt);
                var item = JsonSerializer.Deserialize<ElectricVehicleM.Repositories.QuangNM.Models.PromotionsQuangNm>(promotion);
                var result = await _serviceProviders.PromotionsQuangNmService.CreateAsync(item);

                return new MutationRelay() { Result = result };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public override async Task<MutationRelay> UpdateAsync(PromotionsQuangNm request, ServerCallContext context)
        {
            try
            {
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Convert proto request to JSON string
                var promotion = JsonSerializer.Serialize(request, opt);
                var item = JsonSerializer.Deserialize<ElectricVehicleM.Repositories.QuangNM.Models.PromotionsQuangNm>(promotion);
                var result = await _serviceProviders.PromotionsQuangNmService.UpdateAsync(item);

                return new MutationRelay() { Result = result };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public override async Task<MutationRelay> DeleteAsync(PromotionQuangNmIdRequest request, ServerCallContext context)
        {
            try
            {
                // Get data from service
                var result = await _serviceProviders.PromotionsQuangNmService.DeleteAsync(request.PromotionQuangNmid);
                // Return 1 for success, 0 for failure
                return new MutationRelay() { Result = result ? 1 : 0 };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
