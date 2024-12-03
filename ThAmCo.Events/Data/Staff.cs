using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Data
{
    public class Staff
    {
        public Staff()
        {
        }
        public Staff(int staffId, string name)
        {
            StaffId = staffId;
            Name = name;
        }
        public int StaffId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public string Role { get; set; }

        [ValidateNever]
        public List<Staffing> Staffing { get; set; }

    }
}
