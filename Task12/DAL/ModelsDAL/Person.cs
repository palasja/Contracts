using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDAL
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо указать имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Необходимо указать отчество")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Необходимо указать фамилию")]
        public string LastName { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public bool IsMain { get; set; } = false;
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
    }
}
