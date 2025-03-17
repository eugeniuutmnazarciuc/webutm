using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVAC.Domain.Models
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Название")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Номер детали")]
        public string PartNumber { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }
        
        [Range(0, 10000)]
        [Display(Name = "Количество на складе")]
        public int StockQuantity { get; set; }
        
        [Display(Name = "Цена за единицу")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата последнего обновления")]
        public DateTime LastUpdated { get; set; }
        
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        [Display(Name = "Тип запчасти")]
        public PartType Type { get; set; }
        
        [Display(Name = "Минимальный порог запаса")]
        public int ReorderThreshold { get; set; }
        
        // Навигационные свойства
        public virtual ICollection<ServiceRequestPart> ServiceRequestParts { get; set; }
    }
    
    /// <summary>
    /// Таблица многие-ко-многим между заявками на обслуживание и запчастями
    /// </summary>
    public class ServiceRequestPart
    {
        [Key]
        public int ServiceRequestPartId { get; set; }
        
        [Required]
        public int ServiceRequestId { get; set; }
        
        [Required]
        public int PartId { get; set; }
        
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        
        [ForeignKey("ServiceRequestId")]
        public virtual ServiceRequest ServiceRequest { get; set; }
        
        [ForeignKey("PartId")]
        public virtual Part Part { get; set; }
    }
    
    public enum PartType
    {
        [Display(Name = "Фильтр")]
        Filter = 0,
        
        [Display(Name = "Мотор")]
        Motor = 1,
        
        [Display(Name = "Компрессор")]
        Compressor = 2,
        
        [Display(Name = "Теплообменник")]
        HeatExchanger = 3,
        
        [Display(Name = "Вентилятор")]
        Fan = 4,
        
        [Display(Name = "Контроллер")]
        Controller = 5,
        
        [Display(Name = "Клапан")]
        Valve = 6,
        
        [Display(Name = "Хладагент")]
        Refrigerant = 7,
        
        [Display(Name = "Другое")]
        Other = 8
    }
} 