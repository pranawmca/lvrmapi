using LVRMWebAPI.Models.Datashake;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Infrastructure
{
    public class ComapereCLS : IEqualityComparer<PlaceIdDetailsModel>
    {
        public bool Equals(PlaceIdDetailsModel lst1, PlaceIdDetailsModel lst2)
        {
            if (lst2.DealerID == lst2.DealerID && lst2.DealerID == lst2.DealerID == lst2.DealerID == lst2.DealerID)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] PlaceIdDetailsModel obj)
        {
            
        }
    }
}
