using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice19.Models
{
    /// <summary>
    /// Класс, описывающий запись в телефонной книге
    /// </summary>
    public class PhoneBookEntry
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия"), StringLength(60, MinimumLength = 2), Required]
        public string? LastName { get; set; }

        [Display(Name = "Имя"), StringLength(60, MinimumLength = 2), Required]
        public string? FirstName { get; set; }

        [Display(Name = "Отчество"), StringLength(60, MinimumLength = 2), Required]
        public string? MiddleName { get; set; }

        [Display(Name = "Номер телефона"), DisplayFormat(DataFormatString = "{0:+0 (000) 000-00-00}")]
        public long PhoneNumber { get; set; }

        [Display(Name = "Адрес"), StringLength(60, MinimumLength = 2), Required]
        public string? Address { get; set; }

        [Display(Name = "Описание"), StringLength(100)]
        public string? Description { get; set; }

    }
}
