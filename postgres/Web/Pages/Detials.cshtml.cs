using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postgres.Web.Services;
using Postgres.Web.ViewModels;

namespace Postgres.Web.Pages
{
    public class DetialModel : PageModel
    {
        private readonly PacketFeaturesService _packetFeaturesService;
        public DetialModel(PacketFeaturesService packetFeaturesService)
        {
            _packetFeaturesService = packetFeaturesService;
        }    

        public PacketFeatureViewModel packetWithFeatures {set; get;}

        public async Task<IActionResult> OnGet(int id)
        {
            packetWithFeatures = await _packetFeaturesService.GetPacketWithFeaturesAsync(id); 
        
            return Page();
        }

    }
}