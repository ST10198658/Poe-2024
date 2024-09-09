using System.ComponentModel.DataAnnotations;

namespace Poe.Models
{
    public class Lecturer
    {       
        public int Id { get; set; }
        public DateTime Sessions { set; get; }
        public int Groups { set; get; }
        public decimal Rate { set; get; }

        [Required]
        public string? Name { set; get; }
        public string? Programme { set; get; }
        public string? ModuleCode { set; get; }
    }
}
