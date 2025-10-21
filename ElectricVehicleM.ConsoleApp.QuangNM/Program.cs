using ElectricVehicleM.GrpcService.QuangNM.Protos;
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");

// Create a gRPC channel, using link from postman
var channel = GrpcChannel.ForAddress("https://localhost:7132");
// Create gRPC client
var grpcClient = new PromotionsQuangNmGRPC.PromotionsQuangNmGRPCClient(channel);

Console.WriteLine("----- Call GetAllAsync -----");
var promotions = grpcClient.GetAllAsync(new EmptyRequest());
if (promotions != null && promotions.Items.Count > 0)
{
    foreach (var item in promotions.Items)
    {
        Console.WriteLine(string.Format($"Id: {item.PromotionQuangNmid} - Title: {item.Title} - UsageId: {item.UsageQuangNmid}"));
    }
}

Console.WriteLine("----- Call GetByIdAsync -----");
Console.Write("Input PromotionQuangNmid to get detail: ");
var input = Console.ReadLine();
var promotionById = grpcClient.GetByIdAsync(new PromotionQuangNmIdRequest() { PromotionQuangNmid = int.Parse(input) });
if (promotionById != null)
{
    Console.WriteLine(string.Format($"Result= Id: {promotionById.PromotionQuangNmid} - Title: {promotionById.Title} - UsageId: {promotionById.UsageQuangNmid}"));
}

Console.WriteLine("----- Call CreateAsync -----");
Console.Write("Input PromotionQuangNmid: ");
var promoId = int.Parse(Console.ReadLine());
Console.Write("Input Title: ");
var title = Console.ReadLine();
Console.Write("Input Description: ");
var description = Console.ReadLine();
Console.Write("Input DiscountRate: ");
var discountRate = decimal.Parse(Console.ReadLine() ?? "0");
Console.Write("Input StartDate (yyyy-MM-dd): ");
var startDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
Console.Write("Input EndDate (yyyy-MM-dd): ");
var endDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
Console.Write("Is Active? (true/false): ");
var isActive = bool.Parse(Console.ReadLine() ?? "true");
Console.Write("Input ApplicableModel: ");
var applicableModel = Console.ReadLine();
Console.Write("Input MaxUsage: ");
var maxUsage = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Input UsageQuangNmid: ");
var usageQuangNmid = int.Parse(Console.ReadLine() ?? "0");

var createRequest = new PromotionsQuangNm
{
    PromotionQuangNmid = promoId,
    Title = title,
    Description = description,
    DiscountRate = (double)discountRate,
    StartDate = startDate.ToString("o"),
    EndDate = endDate.ToString("o"),
    IsActive = isActive,
    ApplicableModel = applicableModel,
    MaxUsage = maxUsage,
    CreatedAt = DateTime.UtcNow.ToString("o"),
    UsageQuangNmid = usageQuangNmid
};

var createResponse = grpcClient.CreateAsync(createRequest);
Console.WriteLine($"CreateAsync result: {createResponse}");

Console.WriteLine("----- Call UpdateAsync -----");
Console.Write("Input PromotionQuangNmid to update: ");
var updateId = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Input new Title: ");
var newTitle = Console.ReadLine();
Console.Write("Input new Description: ");
var newDescription = Console.ReadLine();
Console.Write("Input new DiscountRate: ");
var newDiscountRate = decimal.Parse(Console.ReadLine() ?? "0");
Console.Write("Input new StartDate (yyyy-MM-dd): ");
var newStartDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
Console.Write("Input new EndDate (yyyy-MM-dd): ");
var newEndDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
Console.Write("Is Active? (true/false): ");
var newIsActive = bool.Parse(Console.ReadLine() ?? "true");
Console.Write("Input new ApplicableModel: ");
var newApplicableModel = Console.ReadLine();
Console.Write("Input new MaxUsage: ");
var newMaxUsage = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Input new UsageQuangNmid: ");
var newUsageQuangNmid = int.Parse(Console.ReadLine() ?? "0");

var updateRequest = new PromotionsQuangNm
{
    PromotionQuangNmid = updateId,
    Title = newTitle,
    Description = newDescription,
    DiscountRate = (double)newDiscountRate,
    StartDate = newStartDate.ToString("o"),
    EndDate = newEndDate.ToString("o"),
    IsActive = newIsActive,
    ApplicableModel = newApplicableModel,
    MaxUsage = newMaxUsage,
    CreatedAt = DateTime.UtcNow.ToString("o"),
    UsageQuangNmid = newUsageQuangNmid
};

var updateResponse = grpcClient.UpdateAsync(updateRequest);
Console.WriteLine($"UpdateAsync result: {updateResponse}");

Console.WriteLine("----- Call DeleteAsync -----");
Console.Write("Input PromotionQuangNmid to delete: ");
var deleteId = int.Parse(Console.ReadLine() ?? "0");
var deleteRequest = new PromotionQuangNmIdRequest { PromotionQuangNmid = deleteId };
var deleteResponse = grpcClient.DeleteAsync(deleteRequest);
Console.WriteLine($"DeleteAsync result: {deleteResponse}");