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
    // not done
    public class VehicleEditViewModel
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

            if (string.IsNullOrEmpty(Vehicle.Model.Model1))
            {
                errors.Add(new ValidationResult("Nickname is required"));
            }
            if (string.IsNullOrEmpty(Vehicle.Model.Make.MakeType))
            {
                errors.Add(new ValidationResult("Nickname is required"));
            }

            if (string.IsNullOrEmpty(Vehicle.VIN))
            {
                errors.Add(new ValidationResult("City is required"));
            }

            if (string.IsNullOrEmpty(Vehicle.Description))
            {
                errors.Add(new ValidationResult("Description is required"));
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

            if (Vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("Rate must be greater than 0"));
            }

            if (Vehicle.SalesPrice <= 0)
            {
                errors.Add(new ValidationResult("Square footage must be greater than 0"));
            }

            return errors;
        }

    }
}