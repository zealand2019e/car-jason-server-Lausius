using System;

namespace ModelLib
{
    public class Car
    {

        public Car(string model, string color, string regNo)
        {
            Model = model;
            Color = color;
            RegNo = regNo;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegNo { get; set; }

        public override string ToString()
        {
            return ($"Model: {Model} - Color: {Color} - Registration: {RegNo}");
        }
    }
}
