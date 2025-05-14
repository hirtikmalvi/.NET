using System;

namespace Classes
{
    internal class Product
    {
        private string _Name;
        private string _Category;
        private decimal _Price;

        public void SetName(string name)
        {
            _Name = name;
        }
        public string Name()
        {
            return _Name;
        }

        public void SetCategory(string category)
        {
            _Category = category;
        }
        public string Category()
        {
            return _Category;
        }

        public void SetPrice(decimal price)
        {
            _Price = price;
        }
        public decimal Price()
        {
            return _Price;
        }
        public decimal CalculateDiscount()
        {
            decimal discountPercentage = 0;
            if (_Price < 50)
            {
                discountPercentage = 10;
            }
            else if(_Price < 500)
            {
                discountPercentage = 30;
            }
            else
            {
                discountPercentage = 45;
            }

                return _Price - (discountPercentage * _Price / 100);
        }
    }
}
