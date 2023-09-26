using System;
using System.ComponentModel.DataAnnotations;
using PortfolioManager.Domain;

namespace PortfolioManager.DTO
{
    public class ComDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } //название конкурса
        public string Organizer { get; set; } //организатор
        public string Type { get; set; } //тип конкурса
        public string View { get; set; }  //вид проведения
        public DateTime Date { get; set; } //год проведения
        public string Result { get; set; } //результат(победитель,призер,участник)
        public string Certificate { get; set; } //сертификат
        public string URL { get; set; } //ссылка на конкурс

        public List<StDTO> Stages { get; set; } = new List<StDTO>();
    }
}
