using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_Entity;
using _2_DataAccess;

namespace _3_Business
{
    public class SupplierManager
    {
      SupplierDAL supplierDAL;
        public SupplierManager()
        {
            supplierDAL=SupplierDAL.GetInstance();
        }
        public List<Supplier> GetAll()
        {
            try
            {
              return supplierDAL.GetAll();
            }
            catch (Exception ex)
            {
                return new List<Supplier>();
            }
        }
        public Supplier GetById(int id)
        {
            try
            {
              return supplierDAL.GetById(id);
            }
            catch (Exception)
            {

              return null;  
            }

        }

        public string Add(Supplier entity)
        {
            try
            {
                if (!IsSupplierComplete(entity))
                {
                    return "Tedarikçi Bilgileri Hatalı";
                }
                return supplierDAL.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(Supplier entity)
        {
            try
            {
                if (!IsSupplierComplete(entity))
                {
                    return "Tedarikçi Bilgileri Hatalı";
                }
                return supplierDAL.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool IsSupplierComplete(Supplier supplier)
        {
            if (supplier.SupplierId < 1)
            {
            return false; 
            }
            if (string.IsNullOrEmpty(supplier.Contact)  || string.IsNullOrEmpty(supplier.SupplierName))
            {
                return false;
            }
            return true;
        }
    }
}
