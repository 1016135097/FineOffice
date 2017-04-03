using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Common
{
    public class JsonCalendarData
    {
        public JsonCalendarData(List<object[]> eventList, DateTime startDate, DateTime endDate)
        {
            events = eventList;
            start = startDate;
            end = endDate;
            issort = true;
        }

        public JsonCalendarData(List<object[]> eventList, DateTime startDate, DateTime endDate, bool isSort)
        {
            start = startDate;
            end = endDate;
            events = eventList;
            issort = isSort;
        }
        public JsonCalendarData(JsonError jsonError)
        {
            error = jsonError;
        }
        public List<object[]> events { get; private set; }
        public bool issort
        {
            get;
            private set;
        }

        public DateTime start { get; private set; }
        public DateTime end { get; private set; }
        public JsonError error { get; private set; }
    }
}