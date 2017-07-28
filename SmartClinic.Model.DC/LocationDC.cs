/*
 * File Name   : LocationDC.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Location DB Table. SPs used -> GetLocation
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *
 * */

namespace SmartClinic.Model.DC
{
    public partial class LocationDC
    {
        public int DocID { get; set; }
        public int LocID { get; set; }
        public string LocName { get; set; }
        public string LocAddress { get; set; }
        public string LocPhone1 { get; set; }
        public string LocPhone2 { get; set; }
        public string LocEmail { get; set; }
    }
}