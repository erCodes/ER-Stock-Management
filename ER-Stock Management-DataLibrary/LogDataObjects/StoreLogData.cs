﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary.LogDataObjects
{
    public class StoreLogData
    {
        [SetsRequiredMembers]
        public StoreLogData(UserAction action, Store current, Store? updated = null)
        {
            if (updated != null)
            {
                NewName = updated.Name;
                NewCity = updated.City;
                NewAddress = updated.Address;
                NewSupervisor = updated.Supervisor;
                NewPhone = updated.Phone;
                NewEmail = updated.Email;
            }

            Id = current.Id;
            Action = action;
            OldName = current.Name;
            OldCity = current.City;
            OldAddress = current.Address;
            OldSupervisor = current.Supervisor;
            OldPhone = current.Phone;
            OldEmail = current.Email;
        }

        public enum UserAction
        {
            Added,
            Modified,
            Deleted
        }

        [Key]
        public required string Id { get; set; }
        public required UserAction Action { get; set; }
        public required string OldName { get; set; }
        public string? NewName { get; set; }
        public required string OldCity { get; set; }
        public string? NewCity { get; set; }
        public string? OldAddress { get; set; }
        public string? NewAddress { get; set; }
        public string? OldSupervisor { get; set; }
        public string? NewSupervisor { get; set; }
        public string? OldPhone { get; set; }
        public string? NewPhone { get; set; }
        public string? OldEmail { get; set; }
        public string? NewEmail { get; set; }
    }
}
