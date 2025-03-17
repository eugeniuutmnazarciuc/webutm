using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVAC.Domain.Models
{
    public class Technician
    {
        [Key]
        public int TechnicianId { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(20)]
        [Phone]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        
        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Специализация")]
        public TechnicianSpecialty Specialty { get; set; }
        
        [Display(Name = "Уровень")]
        public TechnicianLevel Level { get; set; }
        
        [Display(Name = "Сертифицирован")]
        public bool IsCertified { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата найма")]
        public DateTime HireDate { get; set; }
        
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Примечания")]
        public string Notes { get; set; }
        
        [Display(Name = "Статус")]
        public TechnicianStatus Status { get; set; }
        
        // Навигационные свойства
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
    }
    
    public enum TechnicianSpecialty
    {
        [Display(Name = "Кондиционирование")]
        AirConditioning = 0,
        
        [Display(Name = "Отопление")]
        Heating = 1,
        
        [Display(Name = "Вентиляция")]
        Ventilation = 2,
        
        [Display(Name = "Установка")]
        Installation = 3,
        
        [Display(Name = "Ремонт")]
        Repair = 4,
        
        [Display(Name = "Универсал")]
        General = 5
    }
    
    public enum TechnicianLevel
    {
        [Display(Name = "Стажёр")]
        Trainee = 0,
        
        [Display(Name = "Помощник")]
        Assistant = 1,
        
        [Display(Name = "Техник")]
        Technician = 2,
        
        [Display(Name = "Старший техник")]
        SeniorTechnician = 3,
        
        [Display(Name = "Мастер")]
        Master = 4
    }
    
    public enum TechnicianStatus
    {
        [Display(Name = "Активен")]
        Active = 0,
        
        [Display(Name = "В отпуске")]
        OnLeave = 1,
        
        [Display(Name = "Недоступен")]
        Unavailable = 2,
        
        [Display(Name = "Уволен")]
        Terminated = 3
    }
} 