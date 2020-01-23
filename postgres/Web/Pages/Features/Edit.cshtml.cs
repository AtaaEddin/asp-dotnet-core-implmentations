using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postgres.Web.Services;
using Postgres.Web.ViewModels;

namespace Postgres.Web.Pages.Features
{
    public class EditModel : PageModel
    {
        private readonly PacketFeaturesService _packetFeaturesService;
        private readonly FeatureService _featureService;

        public EditModel(PacketFeaturesService packetFeaturesService,
                        FeatureService featureService)
        {
            _packetFeaturesService = packetFeaturesService;
            _featureService = featureService;
        }

        [BindProperty]
        public PacketFeatureViewModel packetFeaturesViewModel {set; get;}
        
        [BindProperty]
        public FeatureViewModel featureViewModel {set; get;}

        public async Task<IActionResult> OnGet(int Pid, int id)
        {
            packetFeaturesViewModel = await _packetFeaturesService.GetPacketWithFeaturesAsync(Pid);

            featureViewModel = packetFeaturesViewModel.Features.Aggregate(new FeatureViewModel(),(nm,f) => {
                if(f.id == id)
                {
                    nm.id = f.id;
                    nm.Description = f.Description;   
                }
                return nm;
            });

            return Page();
        }

        public async Task<IActionResult> OnPost(int Pid, int id)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            featureViewModel.id = id;
            await _featureService.UpdateAsync(Pid, featureViewModel);

            return Redirect($"/Detials/{Pid}");
        }
    }
}