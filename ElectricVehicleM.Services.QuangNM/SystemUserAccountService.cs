using ElectricVehicleM.Repositories.QuangNM;
using ElectricVehicleM.Repositories.QuangNM.Models;

namespace ElectricVehicleM.Services.QuangNM
{
    public class SystemUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemUserAccountService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<SystemUserAccount> GetUserAccount(string email, string password)
        {
            try
            {
                return await _unitOfWork.SystemUserAccountRepository.GetUserAccountAsync(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the user account: {ex.Message}");
                return null;
            }
        }
    }
}
