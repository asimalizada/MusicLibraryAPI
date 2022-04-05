using Core.Entities.Abstract;

namespace MusicLibrary.Entities.Concrete
{
    public class Music : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
    }
}
