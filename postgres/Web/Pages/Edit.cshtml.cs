using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postgres.Web.Services;
using Postgres.Web.ViewModels;

namespace Postgres.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly PacketService _packetService;
        private readonly PacketFeaturesService _packetFeatureService;
        public EditModel(PacketFeaturesService packetFeatureService,
                    PacketService packetService)
        {
            _packetFeatureService = packetFeatureService;
            _packetService = packetService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            packetFeaturesViewMode = await _packetFeatureService.GetPacketWithFeaturesAsync(id);

            packetViewModel = new PacketViewModel {
                Id = packetFeaturesViewMode.Id,
                Name = packetFeaturesViewMode.Name,
                ImgUri = packetFeaturesViewMode.ImgUri
            };

            return Page();
        }

        [BindProperty]
        public PacketViewModel packetViewModel {set; get;}
        [BindProperty]
        public PacketFeatureViewModel packetFeaturesViewMode {set; get;}
        public async Task<IActionResult> OnPostPut()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var createdEntity = await _packetService.UpdateAsync(packetViewModel);
            
            if(createdEntity == null)
            {
                // put exception filter or something
                return NotFound();
            }

            return Redirect($"/Detials/{createdEntity.Id}");
        }
    }
}