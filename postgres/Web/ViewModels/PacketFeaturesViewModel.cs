using System.Collections.Generic;

namespace Postgres.Web.ViewModels
{
    public class PacketFeatureViewModel
    {
        public int Id {set; get;}
        public string Name {get; set;}
        public string ImgUri {get; set;}
        public List<FeatureViewModel> Features {get; set;} = new List<FeatureViewModel>();
    }
}