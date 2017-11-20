using Core.Domain;

namespace SanatoriumApp.Domain.Rooms
{
    public class Room : TrackableEntity
    {
        public string Name { get; set; }
        public RoomType RoomTypeId { get; set; }
        public int Capacity { get; set; }
    }
}
