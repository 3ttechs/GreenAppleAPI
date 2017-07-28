/*
 * File Name   : DoctorFactory.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Patient DB Table. SPs used -> GetAllDoctors
 * Created By  : Tony Jacob
 * Created On  : 12Sep2016
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *
 * */
using SmartClinic.Repository;
using SmartClinic.Model.DC;
using System;
using System.Collections.Generic;

namespace SmartClinic.Model.Factory
{
    public class DoctorFactory
    {
        iRepository<DoctorDC> objDoctor = new Doctor();
        //Doctor objDoctor = new Doctor();

        public bool Factory(DoctorDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                    case "Update":
                        result = objDoctor.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objDoctor.DeleteSmartClinic(obj);
                        break;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }
       
        public List<DoctorDC> GetDoctorList()
        {
            List<DoctorDC> doctorList = null;

            try
            {
                doctorList = ((Doctor)objDoctor).GetObjects();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }
           
            return doctorList;
        }

    }
}
