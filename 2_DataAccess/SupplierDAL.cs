using _1_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_DataAccess
{
    public class SupplierDAL:IRepostry<Supplier>
    {
        List<Supplier> suppliers;
        static SupplierDAL supplierDAL;
        public SupplierDAL()
        {
            suppliers = new List<Supplier>();
            suppliers.Add(new Supplier(1, "Yılmaz Taşımacılık", "0555"));
            suppliers.Add(new Supplier(2, "Doğan Taşımacılık", "0444"));
            suppliers.Add(new Supplier(3, "Kızıllar Tedarik", "0222"));
            suppliers.Add(new Supplier(4, "Gücen Nakliyat", "0777"));
        }

        public string Add(Supplier entity)
        {
            try
            {
                suppliers.Add(entity);
                return entity.SupplierName + " Tedarikçisi Başarıyla Eklendi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int entityId)
        {
            try
            {
                foreach (Supplier item in suppliers)
                {
                    if (item.SupplierId == entityId)
                    {
                        suppliers.Remove(item);
                        return item.SupplierName + " Tedarikçisi Başarıyla Kaldırıldı";
                    }
                }
                return "Tedarikçi Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Supplier> GetAll()
        {
            try
            {
                return suppliers;
            }
            catch (Exception)
            {

                return new List<Supplier>();
            }
        }

        public Supplier GetById(int id)
        {
            try
            {
                foreach (Supplier item in suppliers)
                {
                    if (item.SupplierId == id)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Update(Supplier entity)
        {
            try
            {
                for (int i = 0; i < suppliers.Count; i++)
                {
                    if (suppliers[i].SupplierId == entity.SupplierId)
                    {
                        suppliers[i] = entity;
                        return entity.SupplierName + " Tedarikçisi Başarıyla Güncellendi";
                    }
                }
                return "Tedarikçi Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SupplierDAL GetInstance()
        {
            if (supplierDAL == null)
            {
                supplierDAL = new SupplierDAL();
            }
            return supplierDAL;
        }
    }
    
    
}
