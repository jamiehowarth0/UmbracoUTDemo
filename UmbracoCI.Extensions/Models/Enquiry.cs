using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace UmbracoCI.Extensions.Models
{
    [TableName("Enquiry"), PrimaryKey("ID")]
    public class Enquiry
    {
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Company { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
