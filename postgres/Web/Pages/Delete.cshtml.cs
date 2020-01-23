using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postgres.Web.Services;
using Postgres.Web.ViewModels;

namespace Postgres.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly PacketFeaturesService _packetFeaturesService;
        private readonly PacketService _packetService;         
        public DeleteModel(PacketFeaturesService packetFeaturesService,
                        PacketService packetService)
        {
            _packetFeaturesService = packetFeaturesService;
            _packetService = packetService;
        }    

        public PacketFeatureViewModel packetWithFeatures {set; get;}

        public async Task<IActionResult> OnGet(int id)
        {
            packetWithFeatures = await _packetFeaturesService.GetPacketWithFeaturesAsync(id); 
        
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            
            await _packetService.DeleteAsync(id);

            return Redirect("/"); 
        }


    }
}