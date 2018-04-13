using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaBOT.Models
{
    public enum OrderStatus
    {
        InTheKitchen,
        OnTheWay,
        Done,
        Canceled
    }

    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Data of create a product")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Status of order")]
        public OrderStatus Status { get; set; }

        //[Required]
        //[Display(Name = "Идентификатор пользователя")]
        //public string UserId { get; set; }

        [Required]
        [Display(Name = "Total cost")]
        public decimal TotalCost { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Display(Name = "List of products")]
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}