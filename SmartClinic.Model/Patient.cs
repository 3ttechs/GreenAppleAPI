/*
 * File Name   : Patient.cs
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

using SmartClinic;
using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartClinic.Model
{
    public class Patient : iRepository<PatientDC>
    {
        public bool AddSmartClinic(PatientDC obj)
        {
            bool result = false;

            try
            { 
                DBParameter UsrID = new DBParameter("@UsrID", obj.UsrID);
                DBParameter PatName = new DBParameter("@PatName", obj.PatName);
                DBParameter PatShortName = new DBParameter("@PatShortName", obj.PatShortName);
                DBParameter GuardianName = new DBParameter("@GuardianName", obj.GuardianName);
                DBParameter Occupation = new DBParameter("@Occupation", obj.Occupation);
                DBParameter GuardianOccupation = new DBParameter("@GuardianOccupation", obj.GuardianOccupation);
                DBParameter DateOfBirth = new DBParameter("@DateOfBirth", obj.DateOfBirth);
                DateOfBirth.Type = DbType.DateTime;
                DBParameter Sex = new DBParameter("@Sex", obj.Sex);
      
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(UsrID);
                paramCollection.Add(PatName);
                paramCollection.Add(PatShortName);
                paramCollection.Add(GuardianName);
                paramCollection.Add(Occupation);
                paramCollection.Add(GuardianOccupation);
                paramCollection.Add(DateOfBirth);

                paramCollection.Add(Sex);
                
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("AddPatient", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch(Exception ex)
            {
                result = false;
                Console.WriteLine("Exception  : " + ex.ToString());
            }

            return result;
        }

        public bool UpdateSmartClinic(PatientDC obj)
        {
            bool result = false;

            try
            {
                DBParameter PatID = new DBParameter("@PatID", obj.PatID);
                DBParameter UsrID = new DBParameter("@UsrID", obj.UsrID);
                DBParameter PatName = new DBParameter("@PatName", obj.PatName);
                DBParameter PatShortName = new DBParameter("@PatShortName", obj.PatShortName);
                DBParameter GuardianName = new DBParameter("@GuardianName", obj.GuardianName);
                DBParameter Occupation = new DBParameter("@Occupation", obj.Occupation);
                DBParameter GuardianOccupation = new DBParameter("@GuardianOccupation", obj.GuardianOccupation);
                DBParameter DateOfBirth = new DBParameter("@DateOfBirth", obj.DateOfBirth);
                DBParameter Sex = new DBParameter("@Sex", obj.Sex);
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(PatID);
                paramCollection.Add(UsrID);
                paramCollection.Add(PatName);
                paramCollection.Add(PatShortName);
                paramCollection.Add(GuardianName);
                paramCollection.Add(Occupation);
                paramCollection.Add(GuardianOccupation);
                paramCollection.Add(DateOfBirth);
                paramCollection.Add(Sex);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("UpdatePatient", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch(Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public bool DeleteSmartClinic(PatientDC obj)
        {
            bool result = false;

            try
            {
                DBParameter PatID = new DBParameter("@PatID", obj.PatID);
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(PatID);
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("DeletePatient", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch(Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public List<PatientDC> GetObject(int id)
        {
            DataTable dtPatient = null;
            List<PatientDC> lstObjGetPatientDC = null;
            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                if (id == 0)
                {
                    dtPatient = objDAL.ExecuteDataTable("GetPatient");
                }
                else
                {
                    dtPatient = objDAL.ExecuteDataTable("GetPatient", new DBParameter("@PatID", id), CommandType.StoredProcedure);
                }

                lstObjGetPatientDC = new List<PatientDC>();
                foreach (DataRow drAU in dtPatient.Rows)
                {
                    lstObjGetPatientDC.Add(new PatientDC
                    {
                        UsrType = Convert.ToString(drAU["UsrType"]),
                        DocID = Convert.ToString(drAU["DocID"]),
                        usrName = Convert.ToString(drAU["usrName"]),
                        UsrPwd = Convert.ToString(drAU["UsrPwd"]),
                        UsrAddress = Convert.ToString(drAU["UsrAddress"]),
                        UsrPhone1 = Convert.ToString(drAU["UsrPhone1"]),
                        UsrPhone2 = Convert.ToString(drAU["UsrPhone2"]),
                        UsrEmail = Convert.ToString(drAU["UsrEmail"]),
                        PatID = Convert.ToInt32(drAU["PatID"]),
                        UsrID = Convert.ToInt32(drAU["UsrID"]),
                        PatName = Convert.ToString(drAU["PatName"]),
                        PatShortName = Convert.ToString(drAU["PatShortName"]),
                        GuardianName = Convert.ToString(drAU["GuardianName"]),
                        Occupation = Convert.ToString(drAU["Occupation"]),
                        GuardianOccupation = Convert.ToString(drAU["GuardianOccupation"]),
                        DateOfBirth = Convert.ToDateTime(drAU["DateOfBirth"]),
                        Sex = Convert.ToInt16(drAU["Sex"])
                     });
                }
            }
            catch (Exception ex)
            {
                lstObjGetPatientDC = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjGetPatientDC;
        }
    }
}
