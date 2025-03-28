﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ER_Stock_Management_DataLibrary
{
    [method: SetsRequiredMembers]
    public class Store(string name, string city, string? address, string? supervisor, string? phone, string? email)
    {
        [Key]
        public string? Id { get; set; }
        public required string Name { get; set; } = name;
        public required string City { get; set; } = city;
        public string? Address { get; set; } = address;
        public string? Supervisor { get; set; } = supervisor;
        public string? Phone { get; set; } = phone;
        public string? Email { get; set; } = email;
        public List<Product>? Products { get; set; } = [];

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
