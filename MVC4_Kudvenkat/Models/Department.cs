using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC4_Kudvenkat.Models
{
    [Table("Department")]
    public class Department
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}