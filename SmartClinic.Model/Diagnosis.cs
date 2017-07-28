/*
 * File Name   : Diagnosis.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Diagnosis DB Table. SPs used -> AddDiagnosis, GetDiagnosis, UpdateDiagnosis, DeleteDiagnosis
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          1Jun2016     Cleanup
 * */
using SmartClinic;
using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartClinic.Model
{
    public class  Diagnosis  : iRepository<DiagnosisDC>
    {
        public bool AddSmartClinic(DiagnosisDC obj)
        {
            bool result = false;
            try
            {
                DBParameter SloID = new DBParameter("@SloID", obj.SloID);
                DBParameter Illness = new DBParameter("@Illness", obj.Illness);
                DBParameter DoctorComments = new DBParameter("@DoctorComments", obj.DoctorComments);
                DBParameter Prescription = new DBParameter("@Prescription", obj.Prescription);
                DBParameter DiscussionTemplate = new DBParameter("@DiscussionTemplate", obj.DiscussionTemplate);
                DBParameter PostAction = new DBParameter("@PostAction", obj.PostAction);

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(SloID);
                paramCollection.Add(Illness);
                paramCollection.Add(DoctorComments);
                paramCollection.Add(Prescription);
                paramCollection.Add(DiscussionTemplate);
                paramCollection.Add(PostAction);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("AddDiagnosis", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
                result = false;
            }
            finally
            {

            }

            return result;
        }

        public bool UpdateSmartClinic(DiagnosisDC obj)
        {
            bool result = false;
            try
            {
                DBParameter SloID = new DBParameter("@SloID", obj.SloID);
                DBParameter Illness = new DBParameter("@Illness", obj.Illness);
                DBParameter DoctorComments = new DBParameter("@DoctorComments", obj.DoctorComments);
                DBParameter Prescription = new DBParameter("@Prescription", obj.Prescription);
                DBParameter DiscussionTemplate = new DBParameter("@DiscussionTemplate", obj.DiscussionTemplate);
                DBParameter PostAction = new DBParameter("@PostAction", obj.PostAction);

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(SloID);
                paramCollection.Add(Illness);
                paramCollection.Add(DoctorComments);
                paramCollection.Add(Prescription);
                paramCollection.Add(DiscussionTemplate);
                paramCollection.Add(PostAction);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("UpdateDiagnosis", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
                result = false;
            }
            finally
            {

            }

            return result;
        }

        public bool DeleteSmartClinic(DiagnosisDC obj)
        {
            bool result = false;
            try
            {
                DBParameter DID = new DBParameter("@DID", obj.DID);
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(DID);
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("DeleteDiagnosis", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return result;
        }

        public List<DiagnosisDC> GetObject(int id)
        {
            DataTable dtDiagnosis = null;
            List<DiagnosisDC> lstObjDiagnosisDC = null;
            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
               
                if (id == 0)
                {
                    dtDiagnosis = objDAL.ExecuteDataTable("GetDiagnosis");
                }
                else
                {
                    dtDiagnosis = objDAL.ExecuteDataTable("GetDiagnosis", new DBParameter("@SloID", id), CommandType.StoredProcedure);
                }

                lstObjDiagnosisDC = new List<DiagnosisDC>();
                foreach (DataRow dr in dtDiagnosis.Rows)
                {
                    lstObjDiagnosisDC.Add(new DiagnosisDC
                    {
                        DID = Convert.ToInt32(dr["DID"]),
                        SloID = Convert.ToInt32(dr["SloID"]),
                        Illness = Convert.ToString(dr["Illness"]),
                        DoctorComments = Convert.ToString(dr["DoctorComments"]),
                        Prescription = Convert.ToString(dr["Prescription"]),
                        DiscussionTemplate = Convert.ToString(dr["DiscussionTemplate"]),
                        PostAction = Convert.ToString(dr["PostAction"]),
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjDiagnosisDC = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjDiagnosisDC;
        }
    }
}