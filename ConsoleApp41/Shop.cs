using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp41
{
    internal class Shop
    {
         private List<Order> _orders;
        public Shop()
        {
            _orders = new List<Order>();
        }
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }
       
        public List<Order> FilterOrderByPrice(double min, double max)
        {
            return _orders.FindAll(x => x.TotalAmount > min && x.TotalAmount < max);
        }
        public double GetOrdersAvg(DateTime times)
        {
            var order = _orders.FindAll(x => x.CreatedAt > times);
            double dbl = 0;
            foreach (var item in order)
            {
                dbl += item.TotalAmount;
            }
            return dbl / order.Count;
        }
        public void RemoveOrderByNo(int? no)
        {
            if (no == null)
                throw new Exception("Xetaaa");
            var order = _orders.Find(x => x.No == no);
            if (order != null)
                _orders.Remove(order);
        }
        public double GetOrdersAvg()
        {
            if (_orders.Count != 0)
            {
                double dbl = 0;
                foreach (var item in _orders)
                {
                    dbl += item.TotalAmount;
                }
                return dbl / _orders.Count;
            }
            return 0;


        }

    }
}