using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Iisaefi.Models
{
    public class MedicalRecord
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("patientName")]
        public string PatientName { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonProperty("bloodType")]
        public string BloodType { get; set; }

        [JsonProperty("allergies")]
        public List<string> Allergies { get; set; }

        [JsonProperty("medications")]
        public List<string> Medications { get; set; }

        [JsonProperty("conditions")]
        public List<string> Conditions { get; set; }

        public MedicalRecord()
        {
        }

        public MedicalRecord(
            string id,
            string patientName,
            DateTime? dateOfBirth,
            string bloodType,
            List<string> allergies,
            List<string> medications,
            List<string> conditions)
        {
            Id = id;
            PatientName = patientName;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            Allergies = allergies;
            Medications = medications;
            Conditions = conditions;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static MedicalRecord FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MedicalRecord>(json);
        }
    }



}

