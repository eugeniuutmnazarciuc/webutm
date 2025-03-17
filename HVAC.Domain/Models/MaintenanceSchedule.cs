using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVAC.Domain.Models
{
    public class MaintenanceSchedule
    {
        [Key]
        public int MaintenanceScheduleId { get; set; }
        
        [Required]
        [Display(Name = "Тип обслуживания")]
        public MaintenanceType Type { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата запланированного обслуживания")]
        public DateTime ScheduledDate { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата фактического выполнения")]
        public DateTime? CompletionDate { get; set; }
        
        [Display(Name = "Статус")]
        public MaintenanceStatus Status { get; set; }
        
        [Display(Name = "Приоритет")]
        public Priority Priority { get; set; }
        
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание работ")]
        public string Description { get; set; }
        
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Результаты обслуживания")]
        public string Results { get; set; }
        
        [Display(Name = "Периодичность (дней)")]
        public int FrequencyDays { get; set; }
        
        // Внешние ключи
        [Display(Name = "HVAC система")]
        public int HvacSystemId { get; set; }
        
        [Display(Name = "Оборудование")]
        public int? EquipmentId { get; set; }
        
        [Display(Name = "Техник")]
        public int? TechnicianId { get; set; }
        
        // Навигационные свойства
        [ForeignKey("HvacSystemId")]
        public virtual HvacSystem HvacSystem { get; set; }
        
        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
        
        [ForeignKey("TechnicianId")]
        public virtual Technician Technician { get; set; }
    }
    
    public enum MaintenanceType
    {
        [Display(Name = "Плановое")]
        Regular = 0,
        
        [Display(Name = "Сезонное")]
        Seasonal = 1,
        
        [Display(Name = "Профилактическое")]
        Preventive = 2,
        
        [Display(Name = "Аварийное")]
        Emergency = 3
    }
    
    public enum MaintenanceStatus
    {
        [Display(Name = "Запланировано")]
        Scheduled = 0,
        
        [Display(Name = "В процессе")]
        InProgress = 1,
        
        [Display(Name = "Выполнено")]
        Completed = 2,
        
        [Display(Name = "Отменено")]
        Cancelled = 3,
        
        [Display(Name = "Отложено")]
        Postponed = 4
    }
    
    public enum Priority
    {
        [Display(Name = "Низкий")]
        Low = 0,
        
        [Display(Name = "Средний")]
        Medium = 1,
        
        [Display(Name = "Высокий")]
        High = 2,
        
        [Display(Name = "Критический")]
        Critical = 3
    }
} 