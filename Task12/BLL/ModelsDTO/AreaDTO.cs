using System.ComponentModel.DataAnnotations;

namespace BLL.ModelsDTO
{
    public class AreaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Полное наименование должно быть заполнено")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Наименование должно быть заполнено")]
        public string SimpleName { get; set; }
    }
}
