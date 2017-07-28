/*
 * File Name   : Session.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Session DB Table. 
 *               SPs used -> GetNextSlotNo, AddSession, GetSession, UpdateSession, DeleteSession
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
using System.IO;

namespace SmartClinic.Model
{
    public class Session : iRepository<SessionDC>
    {
        private static  string Log(string sPathName, string sErrMsg)
        {
            StreamWriter sw = new StreamWriter(sPathName + System.DateTime.Now , true);
            sw.WriteLine(System.DateTime.Now + ":" + sErrMsg);
            sw.Flush();
            sw.Close();
            return "";
        }

        public int GetNextSlotNo(int sesID)
        {
            int nextSlotNo = 0;

            try
            {
                DBParameter param = new DBParameter("@SesID", sesID);
                DataTable dtNextSlotNo = null;

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();

                dtNextSlotNo = objDAL.ExecuteDataTable("GetNextSlotNo", param, CommandType.StoredProcedure);
                  
                //Note : Only one row expected
                foreach (DataRow drAU in dtNextSlotNo.Rows)
                {
                    nextSlotNo = Convert.ToInt32(drAU["NextSlot"]);
                }
            }
            catch (Exception ex)
            {
                nextSlotNo = 0;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return nextSlotNo;
        }

        //tjv . Remove this in favour of UpdateSmartClinic()
        public bool UpdateSession(int sesID)
        {
            bool result = false;

            try
            {
                DBParameter SesID = new DBParameter("@SesID ", sesID);
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(SesID);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("UpdateSession", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch(Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public List<SessionDC> GetObject(int id)
        {
            DataTable dtSession = null;
            List<SessionDC> lstObjSessionDC = null;

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                if (id == 0)
                {
                    dtSession = objDAL.ExecuteDataTable("GetSession");
                }
                else
                {
                    dtSession = objDAL.ExecuteDataTable("GetSession", new DBParameter("@DocID", id), CommandType.StoredProcedure);
                }

                lstObjSessionDC = new List<SessionDC>();
                foreach (DataRow drAU in dtSession.Rows)
                {
                    lstObjSessionDC.Add(new SessionDC
                    {
                        SesID = Convert.ToInt32(drAU["SesID"]),
                        DocID = Convert.ToInt32(drAU["DocID"]),
                        LocID = Convert.ToInt32(drAU["LocID"]),
                        SessionStart = Convert.ToDateTime(drAU["SessionStart"]),
                        SessionEnd = Convert.ToDateTime(drAU["SessionEnd"]),
                        Recurring = Convert.ToInt32(drAU["Recurring"]),
                        MaxSlot = Convert.ToInt32(drAU["MaxSlot"]),
                        AvailableSlot = Convert.ToInt32(drAU["AvailableSlot"]),
                        LocName = Convert.ToString(drAU["LocName"]),
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjSessionDC = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjSessionDC;
        }
       

        public bool AddSmartClinic(SessionDC objSes)
        {
            bool result = false;

            try
            {
                DBParameter DocID = new DBParameter("@DocID", objSes.DocID);
                DBParameter LocID = new DBParameter("@LocID", objSes.LocID);
                DBParameter SessionStart = new DBParameter("@SessionStart", objSes.SessionStart);
                SessionStart.Type = DbType.DateTime;
                DBParameter SessionEnd = new DBParameter("@SessionEnd",  objSes.SessionEnd);
                SessionEnd.Type = DbType.DateTime;
                DBParameter Recurring = new DBParameter("@Recurring", objSes.Recurring);    //tjv Talk to Lakshmy. Do later
                DBParameter MaxSlot = new DBParameter("@MaxSlot", objSes.MaxSlot);
                DBParameter AvailableSlot = new DBParameter("@AvailableSlot", objSes.AvailableSlot);

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(DocID);
                paramCollection.Add(LocID);
                paramCollection.Add(SessionStart);
                paramCollection.Add(SessionEnd);
                paramCollection.Add(Recurring);
                paramCollection.Add(MaxSlot);
                paramCollection.Add(AvailableSlot);
                Log(@"C:\temp\Sessionlog.txt", Convert.ToString(SessionStart) +":"+ Convert.ToString(SessionEnd) + ":" + Convert.ToString(DocID));
               

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();

                result = objDAL.ExecuteNonQuery("AddSession", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public int AddSmartClinicInt(SessionDC objSes)
        {
            int newID = -100;

            try
            {
                DBParameter DocID = new DBParameter("@DocID", objSes.DocID);
                DBParameter LocID = new DBParameter("@LocID", objSes.LocID);
                DBParameter SessionStart = new DBParameter("@SessionStart", objSes.SessionStart);
                SessionStart.Type = DbType.DateTime2;
                DBParameter SessionEnd = new DBParameter("@SessionEnd", objSes.SessionEnd);
                SessionEnd.Type = DbType.DateTime2;
                DBParameter Recurring = new DBParameter("@Recurring", objSes.Recurring);    //tjv Talk to Lakshmy. Do later
                DBParameter MaxSlot = new DBParameter("@MaxSlot", objSes.MaxSlot);
                DBParameter AvailableSlot = new DBParameter("@AvailableSlot", objSes.AvailableSlot);

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(DocID);
                paramCollection.Add(LocID);
                paramCollection.Add(SessionStart);
                paramCollection.Add(SessionEnd);
                paramCollection.Add(Recurring);
                paramCollection.Add(MaxSlot);
                paramCollection.Add(AvailableSlot);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                Log(@"C:\temp\Sessionlog.txt", Convert.ToString(SessionStart) + ":" + Convert.ToString(SessionEnd) + ":" + Convert.ToString(DocID));
                newID = Convert.ToInt32(objDAL.ExecuteScalar("AddSession", paramCollection, CommandType.StoredProcedure));
                Console.WriteLine("newID  : " + newID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return newID;
        }

        public bool UpdateSmartClinic(SessionDC obj)
        {
            bool result = false;

            try
            {
                DBParameter SesID = new DBParameter("@SesID ", obj.SesID);
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(SesID);
            
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("UpdateSession", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public bool UpdateSessionIncrementCounter(SessionDC obj)
        {
            bool result = false;

            try
            {
                DBParameter SesID = new DBParameter("@SesID ", obj.SesID);
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(SesID);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("UpdateSessionIncrementCounter", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public bool DeleteSmartClinic(SessionDC obj)
        {
            bool result = false;

            try
            {
                DBParameter SesID = new DBParameter("@SesID ", obj.SesID);
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(SesID);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("DeleteSession", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }
    }
}
