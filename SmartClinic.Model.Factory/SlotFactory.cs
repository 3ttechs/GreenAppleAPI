/*
 * File Name   : SlotFactory.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on  DB Tables -> Slot, Patient, UserAdmin
 *               SPs used -> GetPatientSlotList, AddSlot, DeleteSlot, UpdateSlot
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          1Jun2016      Cleanup
 * */

using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;

namespace SmartClinic.Model.Factory
{
    public class SlotFactory
    {
        iRepository<SlotDC> objSlot = new Slot();

        public bool Factory(SlotDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                //    case "Add":
                //        result = objSlot.AddSmartClinic(obj);
               //         break;
                    case "Update":
                        result = objSlot.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objSlot.DeleteSmartClinic(obj);
                        break;
                    //case "Select":
                    //    List<SlotDC> objList = ObjSlot.GetObject(1);
                    //    break;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public int AddSlot(SlotDC obj)
        {
            return ((Slot)objSlot).AddSmartClinicInt(obj);
        }
        public List<SlotDC> GetSlot(int SloID)
        {
            List<SlotDC> slotList = null;

            try
            {
                slotList = ((Slot)objSlot).GetObject(SloID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return slotList;
        }
       
        public List<SlotDC> GetSlot(int SesID, int DocID)
        {
            List<SlotDC> slotList = null;

            try
            {
                slotList = ((Slot)objSlot).GetObject(SesID, DocID);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return slotList;
        }
    }
}
