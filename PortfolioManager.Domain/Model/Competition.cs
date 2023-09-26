using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PortfolioManager.Domain
{
    public class Competition
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = ""; //название конкурса
        public string Organizer { get; set; } = ""; //организатор
        public string Type { get; set; } = ""; //тип конкурса
        public string View { get; set; } = "";  //вид проведения
        public DateTime Date { get; set; } = DateTime.Today; //год проведения
        public string Result { get; set; } = ""; //результат(победитель,призер,участник)
        public string Certificate { get; set; } = ""; //сертификат
        public string URL { get; set; } = ""; //ссылка на конкурс

        
        public List<Stage> Stages { get; set; } = new List<Stage>();
    }
}
