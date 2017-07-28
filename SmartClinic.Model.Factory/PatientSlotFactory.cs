/*
 * File Name   : PatientSlotFactory.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Slot DB Table. SPs used -> GetPatientSlotList
 * Created By  : Tony Jacob
 * Created On  : 10May2016
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          1Jun2016      Cleanup
 * */
using SmartClinic.Repository;
using SmartClinic.Model.DC;
using System;
using System.Collections.Generic;

namespace SmartClinic.Model.Factory
{
    public class PatientSlotFactory
    {
        iRepository<PatientSlotDC> objPatientSlot = new PatientSlot();

        public bool Factory(PatientSlotDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                    case "Add":
                        result = objPatientSlot.AddSmartClinic(obj);
                        break;
                    case "Update":
                        result =  objPatientSlot.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result =  objPatientSlot.DeleteSmartClinic(obj);
                        break;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }
       
        public List<PatientSlotDC> GetPatientSlotList(int patID, int docID)
        {
            List<PatientSlotDC> patientSlotList = null;

            try
            {
                patientSlotList = ((PatientSlot)objPatientSlot).GetObjects(patID, docID);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return patientSlotList;
        }
    }
}
