using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ComireClicker
{
    internal class Multiplier
    {
        private string name;
        private string imageURI;
        private double multiply;
        private double startingCost;
        private double costIncreaseAmount;
        private int totalAmountInGame;
        bool isUnlocked = false;

        // Maple, MapleLeafURI, 0.25, 1000, 100, 25, true

        /*if(Maple.IsUnlocked){
         * }
         * 
         * 
         */

        public string Name { get { return name; } set { } }
        public string ImageURI { get { return imageURI; } set { } }
        public double Multiply { get { return multiply; } set { multiply = value; } }
        public double StartingCost { get { return startingCost; } set { startingCost = value; } }
        public double CostIncreaseAmount { get { return costIncreaseAmount; } set { costIncreaseAmount = value; } }

        
        public Multiplier() { }
        public Multiplier(string name, string imageURI, string multiply, double startCost, double costIncrease, bool isUnlocked)
        {
            Name= name;
            ImageURI= imageURI;
            Multiply = multiply;
            StartingCost = startCost;
            CostIncreaseAmount = costIncrease;
            //isUnlocked = isUnlocked;
        }
       

    }
}
