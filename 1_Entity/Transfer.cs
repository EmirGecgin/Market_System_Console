using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Entity
{
    public class Transfer
    {
        int _transferId;
        double _price;
        DateTime _orderDate, _shipmentDate;

        public Transfer(int transferId, double price, DateTime orderDate, DateTime shipmentDate)
        {
            _transferId = transferId;
            _price = price;
            _orderDate = orderDate;
            _shipmentDate = shipmentDate;
        }

        public int TransferId { get => _transferId; set => _transferId = value; }
        public double Price { get => _price; set => _price = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        public DateTime ShipmentDate { get => _shipmentDate; set => _shipmentDate = value; }
    }
}
