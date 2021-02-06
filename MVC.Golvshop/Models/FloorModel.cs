using System;
namespace MVC.Golvshop.Models
{
    public class FloorModel
    {
        //Properties
        public string Color { get; set; }
        public string Img { get; set; }

        //Constructor
        public FloorModel(string color, string img)
        {
            this.Color = color;
            this.Img = img;
        }
    }

    //Viewmodel
    public class ViewModel
    {
        public System.Collections.Generic.IEnumerable<FloorModel> FloorList { get; set; }
    }
}