using System;

namespace ST10085213_ICE_Task_4
{
    class Item
    {
        private string items;
        private double price;

        public double Delivery { get; }
        public string Date { get; }

        public Item(string item, double price)
        {
            SetItems(item);
            SetPrice(price);
        }

        public Item(string item, double price, double delivery, string date) : this(item, price)
        {
            Delivery = delivery;
            Date = date;
        }

        public string GetItems()
        {
            return items;
        }

        public void SetItems(string value)
        {
            items = value;
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double value)
        {
            price = value;
        }
    }
}
