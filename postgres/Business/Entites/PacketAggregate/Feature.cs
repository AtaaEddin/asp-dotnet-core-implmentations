using Postgres.Business.Interfaces;

namespace Postgres.Business.Entites.PacketAggregate
{
    public class Feature : BaseEntity, IAggregateRoot
    {
        public string Description {set; get;}

        public int PacketId {set; get;}

    }
}