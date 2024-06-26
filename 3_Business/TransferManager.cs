using _1_Entity;
using _2_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace _3_Business
{
    public class TransferManager
    {
        TransferDAL transferDAL;
        public TransferManager()
        {
            transferDAL = TransferDAL.GetInstance();
        }
        public string Add(Transfer entity)
        {
            try
            {
                if(!IsTransferComplete(entity))
                {
                    return "Transfer Bilgileri Hatalı";
                }
                return transferDAL.Add(entity);
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
                if (entityId < 1)
                {
                    return "Seçmek istediğiniz transferi girin";
                }
                return transferDAL.Delete(entityId);
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
                return transferDAL.GetAll();
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
                return transferDAL.GetById(id);
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
                if (!IsTransferComplete(entity))
                {
                    return "Transfer Bilgileri Hatalı";
                }
                return transferDAL.Update(entity);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public bool IsTransferComplete(Transfer transfer)
        {
            if (transfer.TransferId < 1||transfer.Price<0)
            {
                return false;
            }
            if(transfer.OrderDate==null||transfer.ShipmentDate==null)
            {
                return false;
            }
            return true;
        }

    }
}
