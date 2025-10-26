using ElectricVehicleM.Repositories.QuangNM;

namespace ElectricVehicleM.Services.QuangNM
{
    public class ServiceProviders : IServiceProviders
    {
        PromotionsQuangNmService _promotionsQuangNmService;
        PromotionUsageQuangNmService _promotionUsageQuangNmService;
        SystemUserAccountService _systemUserAccountService;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceProviders(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IPromotionsQuangNmService PromotionsQuangNmService
        {
            get { return _promotionsQuangNmService ??= new PromotionsQuangNmService(_unitOfWork); }
        }

        public PromotionUsageQuangNmService PromotionUsageQuangNmService
        {
            get { return _promotionUsageQuangNmService ??= new PromotionUsageQuangNmService(_unitOfWork); }
        }

        public SystemUserAccountService SystemUserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(_unitOfWork); }
        }
    }
}
