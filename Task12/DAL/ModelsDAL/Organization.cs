using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDAL
{
    [Index(nameof(UNP), IsUnique = true)]
    public class Organization
    {
        public int Id { get; set; }
        public int UNP { get; set; }
        [Required(ErrorMessage = "Необходимо указать полное назименоване")]
        public string FullName { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо указать адресс")]
        public string Address { get; set; }
        public string? Smdo { get; set; }
        public string? Email { get; set; }
        public Area Area { get; set; }
        public int AreaId { get; set; }
        public ICollection<Person> People { get; set; }
        public ICollection<Contract> Contracts { get; set; }

    }
}
