using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Entities.Concrete
{
    public class Music : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
    }
}
