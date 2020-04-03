using GuildCars.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class VehicleAddViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> BodyTypes { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public Vehicle Vehicle { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Vehicle.Description))
            {
                errors.Add(new ValidationResult("Description is required"));
            }

            if (Vehicle.Mileage <= 0)
            {
                errors.Add(new ValidationResult("Mileage has to be greater or equal to zero"));
            }

            if (Vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP has to be greater or equal to zero"));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Image file is required"));
            }

            if (Vehicle.Year <= 2000)
            {
                errors.Add(new ValidationResult("Year Must be greater than 2000"));
            }

            if (string.IsNullOrEmpty(Vehicle.VIN))
            {
                errors.Add(new ValidationResult("VIN is required"));
            }
            if (Vehicle.SalesPrice <= 0)
            {
                errors.Add(new ValidationResult("SalesPrice is required"));
            }

            return errors;
        }
    }
}