﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace trial3
{
    public partial class CLOUD_CSYEContext : DbContext
    {
        public CLOUD_CSYEContext()
        {
        }

        public CLOUD_CSYEContext(DbContextOptions<CLOUD_CSYEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=CLOUD_CSYE;user= deosthale;password=NikonD%100");
            }
        }

         public virtual DbSet<NOTES> notes { get; set; }

         public virtual DbSet<Attachments> attachments {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");


                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasColumnType("varchar(20)");
            });


            modelBuilder.Entity<NOTES>(enitityNotes =>{
                enitityNotes.ToTable("NOTES");
                 enitityNotes.Property(e => e.noteID)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnType("varchar(100)");

                enitityNotes.Property(e => e.content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(100)");
                enitityNotes.Property(e => e.title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(100)");
                enitityNotes.Property(e => e.created_on)
                    .HasColumnName("Created_On")
                    .HasColumnType("DateTime");
                  enitityNotes.Property(e => e.last_updated_on)
                    .HasColumnName("Last_Updated_On")
                    .HasColumnType("DateTime");
                     enitityNotes.Property(e => e.EMAIL)
                    .HasColumnName("EMAIL")
                    .HasColumnType("varchar(40)");

            });
            modelBuilder.Entity<Attachments>(attach =>{
                attach.ToTable("Attachments");
                attach.Property(e=> e.AID).IsRequired().HasColumnName("AID").HasColumnType("varchar(40)");
                attach.Property(e=> e.url).HasColumnName("URL").HasColumnType("varchar(40)");
                attach.Property(e=> e.FileName).HasColumnName("FileName").HasColumnType("varchar(40)");
                attach.Property(e=> e.length).HasColumnName("length").HasColumnType("varchar(40)");
                attach.Property(e=>e.noteID).HasColumnName("NoteID").HasColumnType("varchar(40)");
        
            });
        }
    }
}
