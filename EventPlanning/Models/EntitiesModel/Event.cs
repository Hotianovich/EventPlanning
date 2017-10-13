using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanning.Models.EntitiesModel
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Название события")]
        [Required(ErrorMessage = "Введите название события")]
        public string NameEvent { get; set; }

        [MaxLength(50)]
        [Display(Name = "Название темы")]
        [Required(ErrorMessage = "Введите название темы")]
        public string Topic { get; set; }

        [MaxLength(50)]
        [Display(Name = "Местоположение")]
        [Required(ErrorMessage = "Введите местоположение")]
        public string Locations { get; set; }

        [Required(ErrorMessage = "Введите дату начала")]
        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
        [Remote("ValidateDate", "Tasks")]
        [DisplayFormat(DataFormatString = "{0:yyyy'/'MM'/'dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEvent { get; set; }

        [Required(ErrorMessage = "Введите время начала")]
        [Display(Name = "Время начала")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime TimeEvent { get; set; }

        [Required(ErrorMessage = "Введите количество участников")]
        [Display(Name = "Количество участников")]
        public int NamderOfParticipants { get; set; }

        public ICollection<RegForEvent> RegForEvents { get; set; }

        public Event()
        {
            RegForEvents = new List<RegForEvent>();
        }
    }
}