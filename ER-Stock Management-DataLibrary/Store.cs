using ER_Stock_Management_DataLibrary.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ER_Stock_Management_DataLibrary
{
    public class Store
    {
        [Key]
        public string? Id { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public string? Address { get; set; }
        public string? Supervisor { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public List<Product>? Products { get; set; } = [];

        [SetsRequiredMembers]
        public Store(DtoStore dtoStore)
        {
            Id = dtoStore.Id;
            Name = dtoStore.Name;
            City = dtoStore.City;
            Address = dtoStore.Address;
            Supervisor = dtoStore.Supervisor;
            Phone = dtoStore.Phone;
            Email = dtoStore.Email;
        }

        [SetsRequiredMembers]
        public Store(string? id, string name, string city, string? address, string? supervisor, string? phone, string? email)
        {
            Id = id;
            Name = name;
            City = city;
            Address = address;
            Supervisor = supervisor;
            Phone = phone;
            Email = email;
        }

        // Remove this
        public void CleanWhitespaces()
        {
            Id.TrimNullSafe();
            Name.TrimNullSafe();
            City.TrimNullSafe();
            Address.TrimNullSafe();
            Supervisor.TrimNullSafe();
            Phone.TrimNullSafe();
            Email.TrimNullSafe();
        }
    }
}
