/*
 * File Name   : UsersPatient.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Patient, UserAdmin DB Tables. SPs used -> GetPatientList, GetUserPatientList
 * Created By  : Tony Jacob
 * Created On  : 12May2016
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
    public class UsersPatient : iRepository<UsersPatientDC>
    {
        public bool AddSmartClinic(UsersPatientDC obj)
        {
            return true;
        }

        public bool UpdateSmartClinic(UsersPatientDC obj)
        {
            return true;
        }

        public bool DeleteSmartClinic(UsersPatientDC obj)
        {
            return true;
        }

        public List<UsersPatientDC> GetObject(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<UsersPatientDC> GetObjects(int usrID, int docID)
        {
            DataTable dt = null;
            List<UsersPatientDC> lstObjUserPatient = null;

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@UsrID", usrID));
                paramCollection.Add(new DBParameter("@DocID", docID));

                dt = objDAL.ExecuteDataTable("GetUserPatientList", paramCollection, CommandType.StoredProcedure);
                
                lstObjUserPatient = new List<UsersPatientDC>();
                
                foreach (DataRow dr in dt.Rows)
                {
                    lstObjUserPatient.Add(new UsersPatientDC
                    {
                        PatID = Convert.ToInt32(dr["PatID"]),
                        PatName = Convert.ToString(dr["PatName"])
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjUserPatient = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjUserPatient;
        }

        public List<UsersPatientDC> GetObjects(int docID)
        {
            DataTable dt = null;
            List<UsersPatientDC> lstObjUserPatient = null;

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DocID", docID));

                dt = objDAL.ExecuteDataTable("GetPatientList", paramCollection, CommandType.StoredProcedure);

                lstObjUserPatient = new List<UsersPatientDC>();
                
                foreach (DataRow dr in dt.Rows)
                {
                    lstObjUserPatient.Add(new UsersPatientDC
                    {
                        PatID = Convert.ToInt32(dr["PatID"]),
                        PatName = Convert.ToString(dr["PatName"])
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjUserPatient = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }
           
            return lstObjUserPatient;
        }
    }
}