using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Pollen.DataLayer.Entities;


namespace Pollen.BusinessLayer.ViewModels
{
    public class PolarImageViewModel
    {
        public Guid FileID { get; set; }

        public byte[] FileContents { get; set; }

        public string Caption { get; set; }

        public PlantType PlantType { get; set; }
    }
}
