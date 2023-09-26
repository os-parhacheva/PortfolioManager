using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PortfolioManager.Domain
{
    public class Participant
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }
        public string Surname { get; set; }=""; //фамилия
       // [Required]
        public string Name { get; set; } = "";//имя
        public string Middlename { get; set; } = ""; //отчество
        public string Role { get; set; } = ""; //роль

        public Guid StageId { get; set; }

        public Stage Stage { get; set; } = new Stage();
    }
}
