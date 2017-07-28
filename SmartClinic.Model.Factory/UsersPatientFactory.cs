/*
 * File Name   : UsersPatientFactory.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Patient, UserAdmin DB Tables. SPs used -> GetPatientList, GetUserPatientList
 * Created By  : Tony Jacob
 * Created On  : 12May2016
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
    public class UsersPatientFactory
    {
        iRepository<UsersPatientDC> objUserPatient = new UsersPatient();

        public bool Factory(UsersPatientDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                    case "Add":
                        result = objUserPatient.AddSmartClinic(obj);
                        break;
                    case "Update":
                        result = objUserPatient.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objUserPatient.DeleteSmartClinic(obj);
                        break;
                    //case "Select":
                    //    List<UserPatientDC> objList = objUserPatient.GetObject(1);
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

        public List<UsersPatientDC> GetUserPatientList(int usrID, int docID)
        {
            List<UsersPatientDC> userPatientList = null;

            try
            {
                userPatientList = ((UsersPatient)objUserPatient).GetObjects(usrID, docID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return userPatientList;
        }

        public List<UsersPatientDC> GetDoctorPatientList(int docID)
        {
            List<UsersPatientDC> userPatientList = null;

            try
            {
                userPatientList = ((UsersPatient)objUserPatient).GetObjects(docID);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return userPatientList;
        }
    }
}
