using Postgres.Business.Interfaces;
using System.Collections.Generic;

namespace Postgres.Business.Entites.PacketAggregate 
{
    public class Packet : BaseEntity, IAggregateRoot
    {
        public string Name {set; get;}
        public string ImgUrl {set; get;}
        public List<Feature> Features {set; get;} = new List<Feature>();
    
    }
}