using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PortfolioManager.Domain
{
    public class Stage
    {
        public Guid Id { get; set; } 
        //[Required]
        public uint Number { get; set; } //номер этапа
        public string Result { get; set; } = ""; //результат (пройден/не пройден)
        public int Fund { get; set; } //фонд?
        public DateTime Deadline { get; set; } = DateTime.Today; //дата проведения

        public Guid CompetitionId { get; set; }

        public Competition Competition { get; set; } = new Competition();
        public List<Participant> Participants { get; set; } = new List<Participant>();
    }
}
