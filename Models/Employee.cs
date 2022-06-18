using System.ComponentModel.DataAnnotations;

namespace LaboratorioAzure.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Display(Name = "Cargo")]
        public string Designation { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        [Display(Name = "Fecha creación")]
        public DateTime? RecordCreation { get; set; }
        [Display(Name = "Fecha actualización")]
        public DateTime? RecordUpdateOn { get; set; }
        public bool Estate { get; set; } = true;
    }
}
