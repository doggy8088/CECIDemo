﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreDemo.Models
{
    public partial class ContosoUniversityContext : DbContext
    {
        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);
                Console.WriteLine("Status: {0}", entry.State);

                if (entry.State == EntityState.Modified)
                {
                    entry.CurrentValues.SetValues(new { ModifiedOn = DateTime.Now });
                }
            }

            return base.SaveChanges();
        }
    }
}