using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;

namespace SmartClinic.Model.Utilities
{
    public class QueueFactory
    {
        iRepository<QueueDC> ObjQueue = new Queue();
        public bool Factory(QueueDC obj, string TypeOf)
        {
            try
            {
                switch (TypeOf)
                {
                    case "Add":
                        ObjQueue.AddSmartClinic(obj);
                        break;
                    case "Update":
                        ObjQueue.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        ObjQueue.DeleteSmartClinic(obj);
                        break;
                    case "Select":
                        List<QueueDC> objList = ObjQueue.GetObject(1);
                        break;
                }
                return true;
            }
            catch (Exception expMsg)
            {
                return false;
            }
        }
        public List<QueueDC> GetQueue(int DocID)
        {
            return ObjQueue.GetObject(DocID);
        }
    }
}
