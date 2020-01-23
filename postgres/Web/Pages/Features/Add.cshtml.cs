using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postgres.Web.Services;
using Postgres.Web.ViewModels;

namespace Postgres.Web.Pages.Features
{
    public class AddModel : PageModel
    {
        private readonly PacketFeaturesService _packetFeaturesService;
        private readonly FeatureService _featureService;

        public AddModel(PacketFeaturesService packetFeaturesService,
                        FeatureService featureService)
        {
            _packetFeaturesService = packetFeaturesService;
            _featureService = featureService;
        }

        [BindProperty]
        public PacketFeatureViewModel packetFeaturesViewModel {set; get;}
        [BindProperty]
        public FeatureViewModel featureViewModel {set; get;}

        public async Task<IActionResult> OnGet(int Pid)
        {
            packetFeaturesViewModel = await _packetFeaturesService.GetPacketWithFeaturesAsync(Pid);

            return Page();
        }

        public async Task<IActionResult> OnPost(int Pid)
        {
            await _featureService.AddAsync(Pid,featureViewModel.Description);
        
            return Redirect($"/Detials/{Pid}");
        }
    }
}