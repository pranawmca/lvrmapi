using LVRMWebAPI.Models.Datashake;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Infrastructure
{
    public class DealerPlaceidComapereCLS : IEqualityComparer<PlaceIdDetailsModel>
    {
        public bool Equals(PlaceIdDetailsModel lst1, PlaceIdDetailsModel lst2)
        {
            if (lst1.DealerID == lst2.DealerID && lst1.PlaceID == lst2.PlaceID)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(PlaceIdDetailsModel obj)
        {
            return obj.PlaceID.GetHashCode();
        }
    }
}
