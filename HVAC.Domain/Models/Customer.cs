using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVAC.Domain.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(200)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Город")]
        public string City { get; set; }
        
        [StringLength(20)]
        [Display(Name = "Почтовый индекс")]
        public string ZipCode { get; set; }
        
        [Required]
        [StringLength(20)]
        [Phone]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        
        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        
        // Навигационные свойства
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual ICollection<HvacSystem> HvacSystems { get; set; }
    }
} 