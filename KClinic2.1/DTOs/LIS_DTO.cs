using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.DTOs
{
    public class SampleInfo
    {
        public string SpecimenID { get; set; }
        public string SpecimenName { get; set; }
        public string UserCollectedID { get; set; }
        public string UserCollectedName { get; set; }
        public DateTime SpecimenCollectedTime { get; set; }
        public object UserReceivedID { get; set; }
        public object UserReceivedName { get; set; }
        public object SpecimenReceivedTime { get; set; }
    }

    public class ListSubTest
    {
        public string TestId { get; set; }
        public string TestCode { get; set; }
        public string TestName { get; set; }
    }

    public class ListTestOrder
    {
        public string OrderId { get; set; }
        public DateTime RequestTime { get; set; }
        public string TestId { get; set; }
        public string TestCode { get; set; }
        public string TestName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public SampleInfo SampleInfo { get; set; }
        public List<ListSubTest> ListSubTest { get; set; }
        public ListAdditionalInfo ListAdditionalInfo { get; set; }
    }

    public class ListAdditionalInfo
    {
        public string InfoCode { get; set; }
        public string InfoName { get; set; }
    }

    public class ListOrder
    {
        public string OrderId { get; set; }
        public object ActionCode { get; set; }
        public string Diagnostic { get; set; }
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string ObjectID { get; set; }
        public string ObjectName { get; set; }
        public DateTime RequestTime { get; set; }
        public List<ListTestOrder> ListTestOrder { get; set; }
    }

    public class RootObject
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public object CitizenIdentity { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public string InsureNumber { get; set; }
        public string MedicalId { get; set; }
        public object Bed { get; set; }
        public string SampleId { get; set; }
        public string Sequence { get; set; }
        public DateTime RequestTime { get; set; }
        public object Intime { get; set; }
        public string HISCode { get; set; }
        public bool InPatient { get; set; }
        public bool Urgent { get; set; }
        public List<ListAdditionalInfo> ListAdditionalInfo { get; set; }
        public List<ListOrder> ListOrder { get; set; }
    }
}
