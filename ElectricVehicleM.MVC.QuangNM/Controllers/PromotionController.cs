using ElectricVehicleM.GrpcService.QuangNM.Protos;
using Microsoft.AspNetCore.Mvc;

namespace ElectricVehicleM.MVC.QuangNM.Controllers
{
    public class PromotionController : Controller
    {
        private readonly PromotionsQuangNmGRPC.PromotionsQuangNmGRPCClient _grpcClient;

        public PromotionController(PromotionsQuangNmGRPC.PromotionsQuangNmGRPCClient grpcClient)
        {
            _grpcClient = grpcClient;
        }

        // List
        public IActionResult Index()
        {
            var result = _grpcClient.GetAllAsync(new EmptyRequest());
            return View(result.Items);
        }

        // Details
        public IActionResult Details(int id)
        {
            var result = _grpcClient.GetByIdAsync(new PromotionQuangNmIdRequest { PromotionQuangNmid = id });
            return View(result);
        }

        // Create (GET)
        public IActionResult Create() => View();

        // Create (POST)
        [HttpPost]
        public IActionResult Create(PromotionsQuangNm model)
        {
            // Convert dates to ISO 8601 string for gRPC
            model.CreatedAt = DateTime.UtcNow.ToString("o");

            var response = _grpcClient.CreateAsync(model);
            if (response.Result > 0)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Create failed");
            return View(model);
        }

        // Edit (GET)
        public IActionResult Edit(int id)
        {
            var result = _grpcClient.GetByIdAsync(new PromotionQuangNmIdRequest { PromotionQuangNmid = id });
            return View(result);
        }

        // Edit (POST)
        [HttpPost]
        public IActionResult Edit(PromotionsQuangNm model)
        {
            // Convert dates to ISO 8601 string for gRPC
            model.CreatedAt = DateTime.UtcNow.ToString("o");
            var response = _grpcClient.UpdateAsync(model);
            if (response.Result > 0)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Update failed");
            return View(model);
        }

        // Delete (GET)
        public IActionResult Delete(int id)
        {
            var result = _grpcClient.GetByIdAsync(new PromotionQuangNmIdRequest { PromotionQuangNmid = id });
            return View(result);
        }

        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var response = _grpcClient.DeleteAsync(new PromotionQuangNmIdRequest { PromotionQuangNmid = id });
            if (response.Result > 0)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Delete failed");
            return RedirectToAction("Delete", new { id });
        }
    }
}
