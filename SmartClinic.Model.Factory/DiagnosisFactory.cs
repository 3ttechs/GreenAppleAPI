/*
 * File Name   : DiagnosisFactory.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Diagnosis DB Table. SPs used -> AddDiagnosis, GetDiagnosis, UpdateDiagnosis, DeleteDiagnosis
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
    public class DiagnosisFactory
    {
        iRepository<DiagnosisDC> objDiagnosis = new Diagnosis();

        public bool Factory(DiagnosisDC obj, string TypeOf)
        {
            bool result = false;
            try
            {
                switch (TypeOf)
                {
                    case "Add":
                        result = objDiagnosis.AddSmartClinic(obj);
                        break;
                    case "Update":
                        result = objDiagnosis.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objDiagnosis.DeleteSmartClinic(obj);
                        break;
                    //case "Select":
                    //    List<DiagnosisDC> objList = objDiagnosis.GetObject(1);
                    //    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
                result = false;
            }

            return result;
        }

        public List<DiagnosisDC> GetDiagnosis(int SloID)
        {
            List<DiagnosisDC> diagnosisList = null;

            try
            {
                diagnosisList = objDiagnosis.GetObject(SloID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return diagnosisList;
        }
    }
}
