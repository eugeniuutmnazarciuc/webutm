using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVAC.Domain.Models
{
    public class HvacSystem
    {
        [Key]
        public int HvacSystemId { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Название системы")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Тип системы")]
        public SystemType Type { get; set; }
        
        [StringLength(200)]
        [Display(Name = "Местоположение")]
        public string Location { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата установки")]
        public DateTime InstallationDate { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата истечения гарантии")]
        public DateTime? WarrantyExpiration { get; set; }
        
        [Range(0, 50)]
        [Display(Name = "Возраст системы (лет)")]
        public int SystemAge { get; set; }
        
        [Display(Name = "Площадь обслуживания (м²)")]
        public double CoverageArea { get; set; }
        
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        // Внешние ключи
        [Display(Name = "Клиент")]
        public int CustomerId { get; set; }
        
        // Навигационные свойства
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
    
    public enum SystemType
    {
        [Display(Name = "Сплит-система")]
        SplitSystem = 0,
        
        [Display(Name = "Центральная система")]
        CentralSystem = 1,
        
        [Display(Name = "Тепловой насос")]
        HeatPump = 2,
        
        [Display(Name = "Геотермальная система")]
        GeothermalSystem = 3,
        
        [Display(Name = "Радиатор")]
        Radiator = 4,
        
        [Display(Name = "Теплый пол")]
        FloorHeating = 5,
        
        [Display(Name = "VRF/VRV система")]
        VRFSystem = 6,
        
        [Display(Name = "Другое")]
        Other = 7
    }
} 