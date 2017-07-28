/*
 * File Name   : Doctor.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Doctor DB Table. SPs used -> GetAllDoctors
 * Created By  : Tony Jacob
 * Created On  : 12Sep2016
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *
 * */
using SmartClinic;
using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartClinic.Model
{
    public class Doctor : iRepository<DoctorDC>
    {
        public bool AddSmartClinic(DoctorDC obj)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateSmartClinic(DoctorDC obj)
        {
            return true;
        }

        public bool DeleteSmartClinic(DoctorDC obj)
        {
            return true;
        }

        public List<DoctorDC> GetObject(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<DoctorDC> GetObjects()
        {
            DataTable dtDoctor = null;
            List<DoctorDC> lstObjDoctor = null;
           
            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                DBParameterCollection paramCollection = new DBParameterCollection();

                dtDoctor = objDAL.ExecuteDataTable("GetAllDoctors", paramCollection, CommandType.StoredProcedure);
                
                lstObjDoctor = new List<DoctorDC>();

                foreach (DataRow dr in dtDoctor.Rows)
                {
                    lstObjDoctor.Add(new DoctorDC
                    {
                        DocID = Convert.ToInt32(dr["DocID"]),
                        DocName = Convert.ToString(dr["DocName"])
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjDoctor = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjDoctor;
        }
    }
}