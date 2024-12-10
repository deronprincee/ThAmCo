using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Data
{
    public class Staffing
    {
        public Staffing()
        {
        }
        public Staffing(int staffingId, int staffId, int eventId)
        {
            StaffingId = staffingId;
            StaffId = staffId;
            EventId = eventId;
        }
        public int StaffingId { get; set; }

        public int StaffId { get; set; }
        [ValidateNever]
        public Staff Staff { get; set; }

        public int EventId { get; set; }
        [ValidateNever]
        public Event Event { get; set; }

        public string Role { get; set; }



    }
}
