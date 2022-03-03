using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDAL
{
    public class Area
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Полное наименование должно быть заполнено")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Наименование должно быть заполнено")]
        public string SimpleName { get; set; }
        public ICollection<Organization> Organizations { get; set; }

    }
}
