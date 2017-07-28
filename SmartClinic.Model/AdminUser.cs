/*
 * File Name   : AdminUser.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on UserAdmin DB Table. SPs used -> AddUserAdmin, GetUserAdmin, UpdateUserAdmin, DeleteUserAdmin
 * Created By  : Chandra
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          31May2016     Cleanup
 * */

using SmartClinic;
using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;
using System.Data;
namespace SmartClinic.Model
{
    public class AdminUser : iRepository<AdminUserDC>
    {
        public bool AddSmartClinic(AdminUserDC obj)
        {
            int newID = -100;
            
            DBParameter usrName = new DBParameter("@usrName", obj.usrName);
            DBParameter UsrType = new DBParameter("@UsrType", obj.UsrType);
            DBParameter DocID = new DBParameter("@DocID", obj.DocID);
            DBParameter UsrPwd = new DBParameter("@UsrPwd", obj.UsrPwd);
            DBParameter UsrAddress = new DBParameter("@UsrAddress", obj.UsrAddress);
            DBParameter UsrPhone1 = new DBParameter("@UsrPhone1", obj.UsrPhone1);
            DBParameter UsrPhone2 = new DBParameter("@UsrPhone2", obj.UsrPhone2);
            DBParameter UsrEmail = new DBParameter("@UsrEmail", obj.UsrEmail);
            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(usrName);
            paramCollection.Add(UsrType);
            paramCollection.Add(DocID);
            paramCollection.Add(UsrPwd);
            paramCollection.Add(UsrAddress);
            paramCollection.Add(UsrPhone1);
            paramCollection.Add(UsrPhone2); 
            paramCollection.Add(UsrEmail);

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();

                newID = Convert.ToInt32(objDAL.ExecuteScalar("AddUserAdmin", paramCollection, CommandType.StoredProcedure));
                Console.WriteLine("newID  : " + newID);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return true;
        }

        public int AddSmartClinic2(AdminUserDC obj)
        {
            int newID = -100;

            DBParameter usrName = new DBParameter("@usrName", obj.usrName);
            DBParameter UsrType = new DBParameter("@UsrType", obj.UsrType);
            DBParameter DocID = new DBParameter("@DocID", obj.DocID);
            DBParameter UsrPwd = new DBParameter("@UsrPwd", obj.UsrPwd);
            DBParameter UsrAddress = new DBParameter("@UsrAddress", obj.UsrAddress);
            DBParameter UsrPhone1 = new DBParameter("@UsrPhone1", obj.UsrPhone1);
            DBParameter UsrPhone2 = new DBParameter("@UsrPhone2", obj.UsrPhone2);
            DBParameter UsrEmail = new DBParameter("@UsrEmail", obj.UsrEmail);
            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(usrName);
            paramCollection.Add(UsrType);
            paramCollection.Add(DocID);
            paramCollection.Add(UsrPwd);
            paramCollection.Add(UsrAddress);
            paramCollection.Add(UsrPhone1);
            paramCollection.Add(UsrPhone2);
            paramCollection.Add(UsrEmail);

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();

                newID = Convert.ToInt32(objDAL.ExecuteScalar("AddUserAdmin", paramCollection, CommandType.StoredProcedure));
                Console.WriteLine("newID  : " + newID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return newID;
        }

        public bool UpdateSmartClinic(AdminUserDC obj)
        {
            DBParameter UsrID = new DBParameter("@UsrID", obj.UsrID);
            DBParameter usrName = new DBParameter("@usrName", obj.usrName);
            DBParameter UsrType = new DBParameter("@UsrType", obj.UsrType);
            DBParameter DocID = new DBParameter("@DocID", obj.DocID);
            DBParameter UsrPwd = new DBParameter("@UsrPwd", obj.UsrPwd);
            DBParameter UsrAddress = new DBParameter("@UsrAddress", obj.UsrAddress);
            DBParameter UsrPhone1 = new DBParameter("@UsrPhone1", obj.UsrPhone1);
            DBParameter UsrPhone2 = new DBParameter("@UsrPhone2", obj.UsrPhone2);
            DBParameter UsrEmail = new DBParameter("@UsrEmail", obj.UsrEmail);
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(UsrID);
            paramCollection.Add(usrName);
            paramCollection.Add(UsrType);
            paramCollection.Add(DocID);
            paramCollection.Add(UsrPwd);
            paramCollection.Add(UsrAddress);
            paramCollection.Add(UsrPhone1);
            paramCollection.Add(UsrPhone2);
            paramCollection.Add(UsrEmail);

            SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
            string message = objDAL.ExecuteNonQuery("UpdateUserAdmin", paramCollection, CommandType.StoredProcedure) > 0 ? "Record Updated successfully." : "Error in Updated record.";
            return true;
        }

        public bool DeleteSmartClinic(AdminUserDC obj)
        {
            DBParameter UsrID = new DBParameter("@UsrID", obj.UsrID);
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(UsrID);
            SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
            string message = objDAL.ExecuteNonQuery("DeleteUserAdmin", paramCollection, CommandType.StoredProcedure) > 0 ? "Record Deleted successfully." : "Error in Deleted record.";
            return true;
        }

        public List<AdminUserDC> GetObject(int id)
        {
            DataTable dtAdminUser = null;
            List<AdminUserDC> lstObjGetAdminUserModelDC = null;
            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                if (id == 0)
                {
                    dtAdminUser = objDAL.ExecuteDataTable("GetUserAdmin");
                }
                else
                {
                    dtAdminUser = objDAL.ExecuteDataTable("GetUserAdmin", new DBParameter("@UserID", id), CommandType.StoredProcedure);
                }

                lstObjGetAdminUserModelDC = new List<AdminUserDC>();
                foreach (DataRow drAU in dtAdminUser.Rows)
                {
                    lstObjGetAdminUserModelDC.Add(new AdminUserDC
                    {
                        //UsrID = Convert.ToInt32(drAU["UsrID"]),
                        usrName = Convert.ToString(drAU["usrName"]),
                        UsrType = Convert.ToChar(drAU["UsrType"]),
                        DocID = Convert.ToInt32(drAU["DocID"]),
                        UsrPwd = Convert.ToString(drAU["UsrPwd"]),
                        UsrAddress = Convert.ToString(drAU["UsrAddress"]),
                        UsrPhone1 = Convert.ToString(drAU["UsrPhone1"]),
                        UsrPhone2 = Convert.ToString(drAU["UsrPhone2"]),
                        UsrEmail = Convert.ToString(drAU["UsrEmail"]),
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjGetAdminUserModelDC = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjGetAdminUserModelDC;
        }

        public List<AdminUserDC> GetObject(string username, string password, string usrtype)
        {
            //Console.WriteLine("...Inside GetAllAdminUser()...");

            DataTable dtAdminUser = null;
            List<AdminUserDC> lstObjGetAdminUser = null;

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                //Console.WriteLine("...username : " + username);
                //Console.WriteLine("...doctorID : " + doctorID);

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@usrName", username));
                paramCollection.Add(new DBParameter("@UsrPwd", password));
                paramCollection.Add(new DBParameter("@UsrType", usrtype));

                //Console.WriteLine("...Calling  ExecuteDataTable...");
                dtAdminUser = objDAL.ExecuteDataTable("Login2", paramCollection, CommandType.StoredProcedure);
                //Console.WriteLine("...After  ExecuteDataTable...+++");

                lstObjGetAdminUser = new List<AdminUserDC>();

                foreach (DataRow drAU in dtAdminUser.Rows)
                {
                    lstObjGetAdminUser.Add(new AdminUserDC
                    {
                        UsrID = Convert.ToInt32(drAU["UsrID"]),
                        usrName = Convert.ToString(drAU["usrName"]),
                        UsrType = Convert.ToChar(drAU["UsrType"]),
                        UsrEmail = Convert.ToString(drAU["UsrEmail"]),
                        DocID = Convert.ToInt32(drAU["DocID"]),
                        UsrPwd = Convert.ToString(drAU["UsrPwd"]),
                        UsrPhone1 = Convert.ToString(drAU["UsrPhone1"]),
                        UsrPhone2 = Convert.ToString(drAU["UsrPhone2"]),
                        UsrAddress = Convert.ToString(drAU["UsrAddress"])

                    });
                }
            }
            catch (Exception expMsg)
            {
                Console.WriteLine("expMsg : " + expMsg.ToString());

                lstObjGetAdminUser = null;
            }
            finally
            {

            }

            return lstObjGetAdminUser;
        }

        public List<AdminUserDC> GetObject(string username, int docID)
        {
            //Console.WriteLine("...Inside GetAllAdminUser()...");

            DataTable dtAdminUser = null;
            List<AdminUserDC> lstObjGetAdminUser = null;

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();

                //Console.WriteLine("...username : " + username);
                //Console.WriteLine("...docID : " + docID);

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@UsrName", username));
                paramCollection.Add(new DBParameter("@DocID", docID));

                //Console.WriteLine("...Calling  ExecuteDataTable...");
                dtAdminUser = objDAL.ExecuteDataTable("CheckUserExists", paramCollection, CommandType.StoredProcedure);
                Console.WriteLine("...After  ExecuteDataTable...+++");

                lstObjGetAdminUser = new List<AdminUserDC>();

                foreach (DataRow drAU in dtAdminUser.Rows)
                {
                    lstObjGetAdminUser.Add(new AdminUserDC
                    {
                        UsrID = Convert.ToInt32(drAU["UsrID"]),
                        usrName = Convert.ToString(drAU["usrName"]),
                        UsrType = Convert.ToChar(drAU["UsrType"]),
                        UsrEmail = Convert.ToString(drAU["UsrEmail"]),
                        DocID = Convert.ToInt32(drAU["DocID"]),
                        UsrPwd = Convert.ToString(drAU["UsrPwd"]),
                        UsrPhone1 = Convert.ToString(drAU["UsrPhone1"]),
                        UsrPhone2 = Convert.ToString(drAU["UsrPhone2"]),
                        UsrAddress = Convert.ToString(drAU["UsrAddress"])

                    });
                }
            }
            catch (Exception expMsg)
            {
                Console.WriteLine("expMsg : " + expMsg.ToString());

                lstObjGetAdminUser = null;
            }
            finally
            {

            }

            return lstObjGetAdminUser;
        }
        
    }
}
