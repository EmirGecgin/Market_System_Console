using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Entity
{
    public class Supplier
    {
        int _supplierId;
        string _supplierName, _contact;

        public Supplier(int supplierId, string supplierName, string contact)
        {
            _supplierId = supplierId;
            _supplierName = supplierName;
            _contact = contact;
        }

        public int SupplierId { get => _supplierId; set => _supplierId = value; }
        public string SupplierName { get => _supplierName; set => _supplierName = value; }
        public string Contact { get => _contact; set => _contact = value; }
    }
}
