using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSchedulingSystemAPI.Models.Dtos
{
    public class CompanyDto
    {
        public string Id { get; set; }
        public string[] Notifications { get; set; }
    }
}
