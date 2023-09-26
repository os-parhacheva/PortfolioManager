using System;
using System.ComponentModel.DataAnnotations;
using PortfolioManager.Domain;

namespace PortfolioManager.DTO
{
    public class StDTO
    {
        public Guid Id { get; set; }
        public uint Number { get; set; } //номер этапа
        public string Result { get; set; } //результат
        public int Fund { get; set; } //фонд?
        public DateTime Deadline { get; set; } //дата проведения
        public Guid CompetitionId { get; set; }

        public List<PartDTO> Participants { get; set; } = new List<PartDTO>();
    }
}
