using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085213_ICE_Task_4
{
    class Metrics : Update
    {
        private string category;
        private int sold, quantityBigBoxSold = 0, quantityGrocerySold = 0;
        private double priceGrocery = 0.0, priceBigBox = 0.0;
        

        public void update(string category, int sold, double price)
        {
            this.category = category;
            this.sold = sold;

            if (this.category.Equals("bigbox"))
            {
                this.quantityBigBoxSold += this.sold;
                this.priceBigBox += price;
            }
            else 
            {
                this.quantityGrocerySold += this.sold;
                this.priceGrocery += price;
            }
        }
        public void Display() 
        {
            Console.WriteLine("The quantity of BigBox items sold is: " + this.quantityBigBoxSold + " and the total price of BigBox items sold is: " + this.priceBigBox + "\n" +
                "The quantity of Grocery items sold is: " + this.quantityGrocerySold + " and the total price of Grocery items sold is: " + this.priceGrocery);

        }
    }
}
