using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postgres.Business.Entites.PacketAggregate;
using Postgres.Data;
using Postgres.Web.ViewModels;
using Postgres.Web.Services;

namespace Postgres.Web.Pages
{
    public class IndexModel : PageModel
    {
        public readonly PacketFeaturesService _packetFeatureService;
        public IndexModel(PacketFeaturesService packetFeatureService)
        {
            _packetFeatureService = packetFeatureService;
        }
        [BindProperty]
        public List<PacketFeatureViewModel> packetFeatureViewModel {set; get;} = new List<PacketFeatureViewModel>();

        public async Task OnGet()
        {
            packetFeatureViewModel = await _packetFeatureService.GetAllPacketsWithFeaturesAsync();            
        }        
    }

}