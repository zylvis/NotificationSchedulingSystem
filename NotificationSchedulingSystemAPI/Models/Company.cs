using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSchedulingSystemAPI.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Range(1000000000, 9999999999, ErrorMessage = "The number must be of 10 digits")]
        public long Number { get; set; }
        public string Type { get; set; }
        public string Market { get; set; }
        public string _Notifications { get; set; } = "";

        [NotMapped]
        public string[] Notifications {
            get { return _Notifications.Split(","); }
            set
            {
                _Notifications = string.Join($"{","}", value);
            }
        }
    }
}
