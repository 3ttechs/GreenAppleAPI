/*
 * File Name   : AdminUserFactory.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on UserAdmin DB Table. SPs used -> AddUserAdmin, GetUserAdmin, UpdateUserAdmin, DeleteUserAdmin
 * Created By  : Chandra
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          31May2016     Cleanup
 * */

using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;

namespace SmartClinic.Model.Factory
{
    public class AdminUserFactory
    {
        iRepository<AdminUserDC> objAdminUser = new AdminUser();
        
        public bool Factory(AdminUserDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                    //case "Add":
                    //    result = objAdminUser.AddSmartClinic(obj);
                    //    break;
                    case "Update":
                        result = objAdminUser.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objAdminUser.DeleteSmartClinic(obj);
                        break;
                    //case "Select":
                    //    List<AdminUserDC> objList = objAdminUser.GetObject(1);
                    //    break;
                }
            }
            catch (Exception expMsg)
            {
                result = false;
                Console.WriteLine("Exception : " + expMsg.ToString());
            }

            return result;
        }

        public int AddAdminUser(AdminUserDC obj)
        {
            return ((AdminUser)objAdminUser).AddSmartClinic2(obj);
        }

        public List<AdminUserDC> GetAdminUser(int UsrId)
        {
            return objAdminUser.GetObject(UsrId);
        }
       
        public List<AdminUserDC> GetAdminUser(string username, string password, string usrtype)
        {
            List<AdminUserDC> userList = null;

            try
            {
                userList = ((AdminUser)objAdminUser).GetObject(username, password, usrtype);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return userList;
        }

        public List<AdminUserDC> GetAdminUser(string username, int docID)
        {
            List<AdminUserDC> userList = null;

            try
            {
                userList = ((AdminUser)objAdminUser).GetObject(username, docID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return userList;
        }
    }
}
