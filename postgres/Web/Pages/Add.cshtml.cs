using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postgres.Web.Services;
using Postgres.Web.ViewModels;

namespace Postgres.Web.Pages
{
    public class AddModel : PageModel
    {
        private readonly PacketService _packetService;
        public AddModel(PacketService packetService)
        {
            _packetService = packetService;
        }
        public void OnGet()
        {

        }
        [BindProperty]
        public PacketViewModel packetViewModel {set; get;}
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var createdEntity = await _packetService.AddPacketAsync(
                packetViewModel.Name,
                packetViewModel.ImgUri);
            
            if(createdEntity == null)
            {
                // put exception filter or something
                return NotFound();
            }

            return Redirect("/");
 
            // return RedirectToPage("/Detials",createdEntity.Id);
        }
    }
}