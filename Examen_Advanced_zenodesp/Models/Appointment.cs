﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Advanced_zenodesp.Models
{
    internal class Appointment
    {
        //this class was mostly generated by CoPilot
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }
        [ForeignKey(name:"employees")]
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
        [ForeignKey(name:"complaints")]
        public int ComplaintId { get; set; }
        public Complaint complaint { get; set; }

        public Appointment()
        {
        }


    }
}
