using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioManager.DTO
{
    public class PartDTO
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }
        public string Surname { get; set; } //фамилия

        public string Name { get; set; } //имя
        public string Middlename { get; set; } //отчество
        public string Role { get; set; } //роль
        public Guid StageId { get; set; }
    }
}
