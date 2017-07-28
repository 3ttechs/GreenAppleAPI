/*
 * File Name   : AdminUserController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on UserAdmin DB Table. SPs used -> AddUserAdmin, GetUserAdmin, UpdateUserAdmin, DeleteUserAdmin
 * Created By  : Chandra
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          31May2016     Cleanup
 * */

#define DEBUG_MODE

using SmartClinic.Model.DC;
using SmartClinic.Model.Factory;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace SmartClinicAPI.Controllers
{
    public class AdminUserController : ApiController
    {
        [Route("{UsrID}")]
        [Route("AdminUser/GetAdminUser/{UsrID}")]
        [Route("GetAdminUser/{UsrID}")]
        [HttpGet]
        public List<AdminUserDC> GetAdminUser(int UsrID)
        {
            AdminUserFactory objAdminUserFactory = new AdminUserFactory();
            return objAdminUserFactory.GetAdminUser(UsrID);
        }
        
        [Route("AdminUser/Login/{username},{password},{usrtype}")]
        [Route("Login/{username},{password},{usrtype}")]
        [HttpGet]
        public List<AdminUserDC> Login(string username, string password, string usrtype)
        {
            #if DEBUG_MODE
            System.Console.WriteLine("Inside Login()...");
            System.Console.WriteLine("username : " + username);
            System.Console.WriteLine("usrtype : " + usrtype);
            #endif

            AdminUserFactory objAdminUserFactory = new AdminUserFactory();

            List<AdminUserDC> theList = objAdminUserFactory.GetAdminUser(username, password, usrtype);

            if (theList.Count > 0)
                return theList;
            else
                return null;
        }

        [Route("AdminUser/CheckUserExists/{username},{docID}")]
        [Route("CheckUserExists/{username},{docID}")]
        [HttpGet]
        public List<AdminUserDC> CheckUserExists(string username, int docID)
        {
            #if DEBUG_MODE
            System.Console.WriteLine("Inside CheckUserExists()...");
            System.Console.WriteLine("username : " + username);
            System.Console.WriteLine("docID : " + docID);
            #endif

            AdminUserFactory objAdminUserFactory = new AdminUserFactory();

            List<AdminUserDC> theList = objAdminUserFactory.GetAdminUser(username, docID);
            System.Console.WriteLine("theList.Count : " + theList.Count);
            if (theList.Count > 0)
                return theList;
            else
                return null;
        }

        [Route("AdminUser/GetAllAdminUser")]
        [Route("GetAllAdminUser")]
        [HttpGet]
        public List<AdminUserDC> GetAllAdminUser()
        {
            AdminUserFactory objAdminUserFactory = new AdminUserFactory();
            return objAdminUserFactory.GetAdminUser(0);
        }

        [Route("AdminUser/AddAdminUser")]
        [ActionName("AdminUser/AddAdminUser")]
        [HttpPost]
        public bool AddAdminUser([FromBody] AdminUserDC objUADC)
        {
            AdminUserFactory objAdminUserFactory = new AdminUserFactory();
            PatientFactory objPatientFactory = new PatientFactory ();

            int usrID = objAdminUserFactory.AddAdminUser(objUADC);

            #if DEBUG_MODE
            System.Console.WriteLine("usrID : " + usrID);
            #endif

            bool patientAddResult = false;

            if (usrID != -100)
            {
                PatientDC patObj = new PatientDC();

                patObj.UsrID = usrID;
                //System.Console.WriteLine("tjv...patObj.UsrID : " + patObj.UsrID);
                //System.Console.WriteLine("tjv...objUADC.DateOfBirth : " + objUADC.DateOfBirth);

                patObj.PatName = objUADC.usrName;
                patObj.DateOfBirth = objUADC.DateOfBirth;
                
                //System.Console.WriteLine("tjv...objUADC.Sex : " + objUADC.Sex);
                //System.Console.WriteLine("tjv...patObj.DateOfBirth : " + patObj.DateOfBirth);
                patObj.Sex = objUADC.Sex;

                //tjv hardcoded
                patObj.PatShortName = "-";
                patObj.GuardianName = "-";
                patObj.Occupation = "-";
                patObj.GuardianOccupation = "-";

                patientAddResult = objPatientFactory.Factory(patObj, "Add");

                #if DEBUG_MODE
                System.Console.WriteLine("patientAddResult : " + patientAddResult);
                #endif

                return patientAddResult;
            }
            else
            {
                patientAddResult = false;
            }

            return patientAddResult;
        }

        [Route("AdminUser/UpdateAdminUser")]
        [ActionName("AdminUser/UpdateAdminUser")]
        [HttpPatch]
        public bool UpdateAdminUser([FromBody] AdminUserDC objUADC)
        {
            AdminUserFactory objAdminUserFactory = new AdminUserFactory();
            if (objAdminUserFactory.Factory(objUADC, "Update"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("AdminUser/DeleteAdminUser")]
        [ActionName("AdminUser/DeleteAdminUser")]
        [HttpDelete]
        public bool DeleteAdminUser([FromBody] AdminUserDC objUADC)
        {
            AdminUserFactory objAdminUser = new AdminUserFactory();
            if (objAdminUser.Factory(objUADC, "Delete"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
