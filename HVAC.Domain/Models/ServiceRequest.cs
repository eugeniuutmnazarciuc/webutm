using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVAC.Domain.Models
{
    public class ServiceRequest
    {
        [Key]
        public int ServiceRequestId { get; set; }
        
        [Required]
        [Display(Name = "Номер заявки")]
        public string RequestNumber { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата создания")]
        public DateTime CreationDate { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Запланированная дата")]
        public DateTime ScheduledDate { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата выполнения")]
        public DateTime? CompletionDate { get; set; }
        
        [Required]
        [Display(Name = "Статус")]
        public ServiceRequestStatus Status { get; set; }
        
        [Required]
        [Display(Name = "Приоритет")]
        public Priority Priority { get; set; }
        
        [Required]
        [Display(Name = "Тип заявки")]
        public ServiceRequestType Type { get; set; }
        
        [Required]
        [StringLength(500)]
        [Display(Name = "Описание проблемы")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [StringLength(1000)]
        [Display(Name = "Выполненные работы")]
        [DataType(DataType.MultilineText)]
        public string WorkPerformed { get; set; }
        
        [StringLength(1000)]
        [Display(Name = "Рекомендации")]
        [DataType(DataType.MultilineText)]
        public string Recommendations { get; set; }
        
        [Display(Name = "Время работы (часы)")]
        [Range(0, 100)]
        public decimal? LaborHours { get; set; }
        
        [Display(Name = "Стоимость работ")]
        [DataType(DataType.Currency)]
        public decimal? LaborCost { get; set; }
        
        [Display(Name = "Стоимость запчастей")]
        [DataType(DataType.Currency)]
        public decimal? PartsCost { get; set; }
        
        [Display(Name = "Общая стоимость")]
        [DataType(DataType.Currency)]
        public decimal? TotalCost { get; set; }
        
        // Внешние ключи
        [Required]
        [Display(Name = "Клиент")]
        public int CustomerId { get; set; }
        
        [Display(Name = "HVAC система")]
        public int? HvacSystemId { get; set; }
        
        [Display(Name = "Оборудование")]
        public int? EquipmentId { get; set; }
        
        [Display(Name = "Назначенный техник")]
        public int? TechnicianId { get; set; }
        
        // Навигационные свойства
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        
        [ForeignKey("HvacSystemId")]
        public virtual HvacSystem HvacSystem { get; set; }
        
        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
        
        [ForeignKey("TechnicianId")]
        public virtual Technician Technician { get; set; }
        
        public virtual ICollection<ServiceRequestPart> ServiceRequestParts { get; set; }
    }
    
    public enum ServiceRequestStatus
    {
        [Display(Name = "Новая")]
        New = 0,
        
        [Display(Name = "Назначена")]
        Assigned = 1,
        
        [Display(Name = "В работе")]
        InProgress = 2,
        
        [Display(Name = "На удержании")]
        OnHold = 3,
        
        [Display(Name = "Выполнена")]
        Completed = 4,
        
        [Display(Name = "Отменена")]
        Cancelled = 5
    }
    
    public enum ServiceRequestType
    {
        [Display(Name = "Установка")]
        Installation = 0,
        
        [Display(Name = "Ремонт")]
        Repair = 1,
        
        [Display(Name = "Плановое обслуживание")]
        Maintenance = 2,
        
        [Display(Name = "Инспекция")]
        Inspection = 3,
        
        [Display(Name = "Консультация")]
        Consultation = 4,
        
        [Display(Name = "Экстренный вызов")]
        Emergency = 5
    }
} 