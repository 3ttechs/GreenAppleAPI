/*
 * File Name   : SessionFactory.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Session DB Table. 
 *               SPs used -> GetNextSlotNo, AddSession, GetSession, UpdateSession, DeleteSession
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          01Jun2016      Cleanup
 *              Tony Jacob          29Aug2016     UpdateSessionIncrementCounter() added
 * */
using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;

namespace SmartClinic.Model.Factory
{
    public class SessionFactory
    {
        iRepository<SessionDC> objSession = new Session();
        
        public bool Factory(SessionDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                    //case "Add":
                    //    result = objSession.AddSmartClinic(obj);
                    //    break;
                    case "Update":
                        result = objSession.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objSession.DeleteSmartClinic(obj);
                        break;
                    //case "Select":
                    //    List<SessionDC> objList = objSession.GetObject(1);
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

        public int AddSession(SessionDC obj)
        {
            return ((Session)objSession).AddSmartClinicInt(obj);
        }

        public bool UpdateSessionIncrementCounter(SessionDC obj)
        {
            return ((Session)objSession).UpdateSessionIncrementCounter(obj);
        }

        public List<SessionDC> GetSession(int docID)
        {
            List<SessionDC> sessions = null;

            try
            {
                sessions = objSession.GetObject(docID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return sessions;
        }

        public bool UpdateSession(int sesID)
        {
            bool result = false;

            try
            {
                result = ((Session)objSession).UpdateSession(sesID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public int GetNextSlotNo(int sesID)
        {
            int nextSlotNo = 0;

            try
            {
                nextSlotNo = ((Session)objSession).GetNextSlotNo(sesID);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return nextSlotNo;
        }
    }
}
