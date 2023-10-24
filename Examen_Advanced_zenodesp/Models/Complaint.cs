using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Advanced_zenodesp.Models
{
    internal class Complaint
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(name:"employees")]
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
        public string Description { get; set; }

        public Complaint()
        {
        }
    }
}
