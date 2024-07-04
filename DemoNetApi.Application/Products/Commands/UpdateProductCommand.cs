using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoNetApi.Application.Products.Commands
{
    public class UpdateProductCommand
    {
        [Required]
        [JsonRequired]
        [StringLength(50)]
        public string ProductName { get; set; }


        [StringLength(300)]
        public string ProductDescription { get; set; }

        [Required]
        [JsonRequired]
        public int ProductPrice { get; set; }
    }
}
