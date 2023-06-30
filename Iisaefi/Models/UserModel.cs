using System;
using System.ComponentModel.DataAnnotations;
namespace Iisaefi.Models

{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public string Token { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        public UserModel()
        {
        }

        public UserModel(
            string id,
            string email,
            string password,
            string fullName,
            string phoneNumber,
            UserRole role,
            string token,
            DateTime? createAt,
            DateTime? updateAt,
            MedicalRecord medicalRecord)
        {
            Id = id;
            Email = email;
            Password = password;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Role = role;
            Token = token;
            CreateAt = createAt;
            UpdateAt = updateAt;
            MedicalRecord = medicalRecord;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static UserModel FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UserModel>(json);
        }

        public enum UserRole
        {
            User,
            Doctor,
            Operator,
            Nurse,
            Driver,
            Admin
        }
    }
}

