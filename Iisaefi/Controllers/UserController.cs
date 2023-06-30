
using Iisaefi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iisaefi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //private static List<UserModel> users = new List<UserModel>();

        [HttpPost(Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] UserModel user)
        {
            // Logique pour créer un nouvel utilisateur
            users.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            // Logique pour récupérer tous les utilisateurs
            return users;
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult GetUserById(string id)
        {
            // Logique pour récupérer un utilisateur par son ID
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        public IActionResult UpdateUser(string id, [FromBody] UserModel updatedUser)
        {
            // Logique pour mettre à jour un utilisateur existant
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            // Mettre à jour les propriétés de l'utilisateur avec les valeurs fournies
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            user.FullName = updatedUser.FullName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Role = updatedUser.Role;
            user.Token = updatedUser.Token;
            user.CreateAt = updatedUser.CreateAt;
            user.UpdateAt = DateTime.Now;
            user.MedicalRecord = updatedUser.MedicalRecord;

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public IActionResult DeleteUser(string id)
        {
            // Logique pour supprimer un utilisateur par son ID
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            return NoContent();
        }
        private static List<UserModel> users = new List<UserModel>
{
    new UserModel
    {
        Id = "1",
        Email = "user1@example.com",
        Password = "password1",
        FullName = "User 1",
        PhoneNumber = "1234567891",
        Role = UserModel.UserRole.User,
        Token = "token1",
        CreateAt = DateTime.Now,
        UpdateAt = DateTime.Now,
        MedicalRecord = new MedicalRecord
        {
            Id = "1",
            PatientName = "Patient 1",
            DateOfBirth = DateTime.Parse("1990-01-01"),
            BloodType = "A+",
            Allergies = new List<string> { "Allergy 1", "Allergy 2" },
            Medications = new List<string> { "Medication 1", "Medication 2" },
            Conditions = new List<string> { "Condition 1", "Condition 2" }
        }
    },
    new UserModel
    {
        Id = "2",
        Email = "user2@example.com",
        Password = "password2",
        FullName = "User 2",
        PhoneNumber = "1234567892",
        Role = UserModel.UserRole.Doctor,
        Token = "token2",
        CreateAt = DateTime.Now,
        UpdateAt = DateTime.Now,
        MedicalRecord = new MedicalRecord
        {
            Id = "2",
            PatientName = "Patient 2",
            DateOfBirth = DateTime.Parse("1991-01-01"),
            BloodType = "B+",
            Allergies = new List<string> { "Allergy 3", "Allergy 4" },
            Medications = new List<string> { "Medication 3", "Medication 4" },
            Conditions = new List<string> { "Condition 3", "Condition 4" }
        }
    },
    new UserModel
    {
        Id = "3",
        Email = "user3@example.com",
        Password = "password3",
        FullName = "User 3",
        PhoneNumber = "1234567893",
        Role = UserModel.UserRole.Operator,
        Token = "token3",
        CreateAt = DateTime.Now,
        UpdateAt = DateTime.Now,
        MedicalRecord = new MedicalRecord
        {
            Id = "3",
            PatientName = "Patient 3",
            DateOfBirth = DateTime.Parse("1992-01-01"),
            BloodType = "AB+",
            Allergies = new List<string> { "Allergy 5", "Allergy 6" },
            Medications = new List<string> { "Medication 5", "Medication 6" },
            Conditions = new List<string> { "Condition 5", "Condition 6" }
        }
    },
    new UserModel
    {
        Id = "4",
        Email = "user4@example.com",
        Password = "password4",
        FullName = "User 4",
        PhoneNumber = "1234567894",
        Role = UserModel.UserRole.Nurse,
        Token = "token4",
        CreateAt = DateTime.Now,
        UpdateAt = DateTime.Now,
        MedicalRecord = new MedicalRecord
        {
            Id = "4",
            PatientName = "Patient 4",
            DateOfBirth = DateTime.Parse("1993-01-01"),
            BloodType = "O+",
            Allergies = new List<string> { "Allergy 7", "Allergy 8" },
            Medications = new List<string> { "Medication 7", "Medication 8" },
            Conditions = new List<string> { "Condition 7", "Condition 8" }
        }
    },
    new UserModel
    {
        Id = "5",
        Email = "user5@example.com",
        Password = "password5",
        FullName = "User 5",
        PhoneNumber = "1234567895",
        Role = UserModel.UserRole.Driver,
        Token = "token5",
        CreateAt = DateTime.Now,
        UpdateAt = DateTime.Now,
        MedicalRecord = new MedicalRecord
        {
            Id = "5",
            PatientName = "Patient 5",
            DateOfBirth = DateTime.Parse("1994-01-01"),
            BloodType = "A-",
            Allergies = new List<string> { "Allergy 9", "Allergy 10" },
            Medications = new List<string> { "Medication 9", "Medication 10" },
            Conditions = new List<string> { "Condition 9", "Condition 10" }
        }
    }
};

    }
}

