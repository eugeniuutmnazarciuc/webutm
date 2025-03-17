using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVAC.Domain.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Название")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Модель")]
        public string Model { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Серийный номер")]
        public string SerialNumber { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата установки")]
        public DateTime InstallationDate { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата последнего обслуживания")]
        public DateTime? LastServiceDate { get; set; }
        
        [Display(Name = "Статус")]
        public EquipmentStatus Status { get; set; }
        
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        // Внешние ключи
        [Display(Name = "HVAC система")]
        public int HvacSystemId { get; set; }
        
        // Навигационные свойства
        [ForeignKey("HvacSystemId")]
        public virtual HvacSystem HvacSystem { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
    
    public enum EquipmentStatus
    {
        [Display(Name = "Рабочее")]
        Operational = 0,
        
        [Display(Name = "Требует обслуживания")]
        NeedsMaintenance = 1,
        
        [Display(Name = "На ремонте")]
        UnderRepair = 2,
        
        [Display(Name = "Неисправное")]
        Faulty = 3,
        
        [Display(Name = "Выведено из эксплуатации")]
        Decommissioned = 4
    }
} 