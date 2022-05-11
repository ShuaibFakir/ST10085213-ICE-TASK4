using System;

namespace ST10085213_ICE_Task_4
{
    class Cart
    {   //Declarations
        private string border = "--------------------";
        private string border1 = "===========================================================";
        private double grandTotal; //Stores grand total
        private double VAT = 1.14; //Stores VAT amount
        private double VATpercentage; //Stores VAT percentage

        public Cart(double total) => Total = total;
        public void Print(string Print) /*The print method contains code that will be presented back to the user
                                        and will contain the results of the user's input*/
        {
            Console.WriteLine(border1);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine(Print);
            Console.WriteLine("--------------");
            Console.WriteLine("Total R" + this.Total + "\n" + "+VAT " + this.VATpercentage.ToString("C"));
            Console.WriteLine(border);
            Console.WriteLine("Grand Total: " + this.GrandTotal.ToString("C"));
            Console.WriteLine(border);
            Console.WriteLine(border1);
        }
        public double Total { get; set; } /*A get property accessor returns the property value,
                                         whereas a set property accessor assigns a new value*/
        public double GrandTotal { get => grandTotal; set => grandTotal = value; }

        public void Calculations() //Calculations method contains code of math calculations
        {
            this.VATpercentage = (this.Total * 0.14); //VATpercentage equals Total x 0.14
            this.GrandTotal = (this.Total * this.VAT); //grandTotal equals Total x 1.14(as declared)
        }
    }

}

