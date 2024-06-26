using _1_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_DataAccess
{
    public class TransferDAL : IRepostry<Transfer>
    {
        List<Transfer> transfers;
        static TransferDAL transferDAL;

        public TransferDAL()
        {
            transfers = new List<Transfer>();
            transfers.Add(new Transfer(1,1500, new DateTime(2020, 1, 1), new DateTime(2020, 2, 2)));
            transfers.Add(new Transfer(2,1900, new DateTime(2020, 3, 15), new DateTime(2020, 4, 15)));
            transfers.Add(new Transfer(3,150, new DateTime(2020, 5, 21), new DateTime(2020, 6, 27)));
            transfers.Add(new Transfer(4,25000, new DateTime(2020, 6, 6), new DateTime(2020, 7, 2)));
        }

        public string Add(Transfer entity)
        {
            try
            {
                transfers.Add(entity);
                return "Kayıt Başarıyla Eklendi";
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
                foreach (Transfer item in transfers)
                {
                    if (item.TransferId == entityId)
                    {
                        transfers.Remove(item);
                        return "Kayıt Başarıyla Kaldırıldı";
                    }
                }
                return "Kayıt Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Transfer> GetAll()
        {
            try
            {
                return transfers;
            }
            catch (Exception)
            {

                return new List<Transfer>();
            }
        }

        public Transfer GetById(int id)
        {
            try
            {
                foreach (Transfer item in transfers)
                {
                    if (item.TransferId == id)
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

        public string Update(Transfer entity)
        {
            try
            {
                for (int i = 0; i < transfers.Count; i++)
                {
                    if (transfers[i].TransferId == entity.TransferId)
                    {
                        transfers[i] = entity;
                        return " Kayıt Başarıyla Güncellendi";
                    }
                }
                return "Kayıt Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        public static TransferDAL GetInstance()
        {
            if (transferDAL == null)
            {
                transferDAL = new TransferDAL();
            }
            return transferDAL;
        }
    }
}
