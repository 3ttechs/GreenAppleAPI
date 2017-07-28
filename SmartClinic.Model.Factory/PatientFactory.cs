/*
 * File Name   : PatientFactory.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Patient, UserAdmin DB Tables. 
 *               SPs used -> AddPatient, GetPatient, UpdatePatient, DeletePatient
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          1Jun2016      Cleanup
 * */

using SmartClinic.Repository;
using System;
using SmartClinic.Model.DC;
using System.Collections.Generic;
namespace SmartClinic.Model.Factory
{
    public class PatientFactory
    {
        iRepository<PatientDC> objPatient = new Patient();

        public bool Factory(PatientDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                    case "Add":
                        result = objPatient.AddSmartClinic(obj);
                        break;
                    case "Update":
                        result = objPatient.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objPatient.DeleteSmartClinic(obj);
                        break;
                   // case "Select":
                   //    List<PatientDC> objList = ObjPatient.GetObject(1);
                   //     break;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString()); 
            }

            return result;
        }

        public  List<PatientDC> GetPatient(int PatID)
        {
            List<PatientDC> patientList = null;

            try
            {
                patientList = objPatient.GetObject(PatID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return patientList;
        }
    }
}
