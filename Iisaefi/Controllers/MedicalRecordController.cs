using System;
using Iisaefi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Iisaefi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalRecordController : ControllerBase
    {
        private static List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        [HttpPost(Name = "CreateMedicalRecord")]
        public IActionResult CreateMedicalRecord([FromBody] MedicalRecord medicalRecord)
        {
            // Logique pour créer un nouveau dossier médical
            medicalRecords.Add(medicalRecord);
            return CreatedAtAction(nameof(GetMedicalRecordById), new { id = medicalRecord.Id }, medicalRecord);
        }

        [HttpGet(Name = "GetAllMedicalRecords")]
        public IEnumerable<MedicalRecord> GetAllMedicalRecords()
        {
            // Logique pour récupérer tous les dossiers médicaux
            return medicalRecords;
        }

        [HttpGet("{id}", Name = "GetMedicalRecordById")]
        public IActionResult GetMedicalRecordById(string id)
        {
            // Logique pour récupérer un dossier médical par son ID
            var medicalRecord = medicalRecords.FirstOrDefault(mr => mr.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return Ok(medicalRecord);
        }

        [HttpPut("{id}", Name = "UpdateMedicalRecord")]
        public IActionResult UpdateMedicalRecord(string id, [FromBody] MedicalRecord updatedMedicalRecord)
        {
            // Logique pour mettre à jour un dossier médical existant
            var medicalRecord = medicalRecords.FirstOrDefault(mr => mr.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            // Mettre à jour les propriétés du dossier médical avec les valeurs fournies
            medicalRecord.PatientName = updatedMedicalRecord.PatientName;
            medicalRecord.DateOfBirth = updatedMedicalRecord.DateOfBirth;
            medicalRecord.BloodType = updatedMedicalRecord.BloodType;
            medicalRecord.Allergies = updatedMedicalRecord.Allergies;
            medicalRecord.Medications = updatedMedicalRecord.Medications;
            medicalRecord.Conditions = updatedMedicalRecord.Conditions;

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteMedicalRecord")]
        public IActionResult DeleteMedicalRecord(string id)
        {
            // Logique pour supprimer un dossier médical par son ID
            var medicalRecord = medicalRecords.FirstOrDefault(mr => mr.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            medicalRecords.Remove(medicalRecord);
            return NoContent();
        }
    }
}


