using System;
using System.Collections.Generic;
using System.Text;

namespace LucidX.ResponseModels
{
    public class CalendarEventResponse
    {
       
        public string DisplayDate { get; set; }
       
        public List<EventResponse> EventListResponse { get; set; }

    }
}
