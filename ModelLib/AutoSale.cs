using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class AutoSale
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public List<Car> CarList { get; set; }

        public override string ToString()
        {
            return ($"Name: {Name} - Address: {Address} - Cars: {CarList.Count}");
        }
    }
}
