using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ModelsDTO
{
    public class OrganizationDTO
    {
        public int Id { get; set; }
        public int UNP { get; set; }
        [Required(ErrorMessage = "Необходимо указать полное название")]
        public string FullName { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо указать адресс")]
        public string  Address { get; set; }
        public string Smdo { get; set; }
        public string Email { get; set; }
        public int AreaId { get; set; }
    }
}
