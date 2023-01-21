using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Models.Datashake
{
    public class PlaceIdDetailsModel
    {

        public int DealerID { get; set; }
        public string PlaceID { get; set; }
      //  public string JobID { get; set; }

    }

    public class PlaceIdDetailsRequest
    { 
    
        public List<PlaceIdDetailsModel> lstPlaceIDDetails { get; set; }
    }

    public class PlaceIdDetailsModelValidator : AbstractValidator<PlaceIdDetailsModel>
    {
        public PlaceIdDetailsModelValidator()
        {
            RuleFor(x => x.DealerID).NotEmpty().WithMessage("DealerId is required");
            RuleFor(x => x.PlaceID).NotEmpty().NotNull(). WithMessage("Last Name is required");

        }
    }

    public class PlaceIdDetailsRequestValidator : AbstractValidator<PlaceIdDetailsRequest>
    {
        public PlaceIdDetailsRequestValidator()
        {
            RuleForEach(x => x.lstPlaceIDDetails).SetValidator(new PlaceIdDetailsModelValidator());
        }
      
    }

}
