using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class People
    {
        [Key] 
        public int idCusmtomer { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set;}
        public int Cell { get; set;}
        public string Email { get; set;}
        public string Country { get; set;}
        public DateTime CreationDate { get; set;}

    }
}
