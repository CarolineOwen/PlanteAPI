using System.ComponentModel.DataAnnotations.Schema;

namespace PlanteAPI.Models
{
    public class Plante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        //[NotMapped]
        //public IFormFile Fichier { get; set; }
        public DateTime date { get; set; }
    }
}
