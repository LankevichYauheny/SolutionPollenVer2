using System;

namespace Pollen.BusinessLayer.ViewModels
{
    public class EquatorialImageViewModel
    {
        public Guid FileID { get; set; }

        public byte[] FileContents { get; set; }

        public string Caption { get; set; }
    }
}
