using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FineOffice.Modules.Helper
{
    [DataContract]
    public enum TrackingInfo
    {
        [EnumMember]
        Unchanged,
        [EnumMember]
        Created,
        [EnumMember]
        Updated,
        [EnumMember]
        Deleted
    }
}
