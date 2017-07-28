/*
 * File Name   : PatientSlotDC.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Slot DB Table. SPs used -> GetPatientSlotList
 * Created By  : Tony Jacob
 * Created On  : 10May2016
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Model.DC
{
    public class PatientSlotDC
    {
        public int SloID { get; set; }
        public int SesID { get; set; }
        public int DocID { get; set; }
        public int PatID { get; set; }
        public int SlotNO { get; set; }
        public string BillNo { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public DateTime SessionStart { get; set; }
    }
}