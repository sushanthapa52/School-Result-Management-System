using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SRMSDataAccess.Models
{
    public partial class SrmsContext : DbContext
    {
      

        public SrmsContext(DbContextOptions<SrmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<ExamClassRelation> ExamClassRelations { get; set; } = null!;

        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<ClassSubjectRelation> ClassSubjectRelations { get; set; } = null!; 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");

                
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("exam");

                entity.Property(e => e.Id).HasColumnName("id");


                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");



          

            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("marks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Marks).HasColumnName("marks");

                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                //entity.HasOne(d => d.Result)
                //    .WithMany(p => p.Marks)
                //    .HasForeignKey(d => d.ResultId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__marks__result_id__72C60C4A");

              
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("result");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                

               

               

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                //entity.HasOne(d => d.Class)
                //    .WithMany(p => p.Results)
                //    .HasForeignKey(d => d.ClassId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__result__class_id__74AE54BC");

                //entity.HasOne(d => d.Student)
                //    .WithMany(p => p.Results)
                //    .HasForeignKey(d => d.StudentId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__result__student___778AC167");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

               
                entity.Property(e => e.StudentDob)
                    .HasColumnType("date")
                    .HasColumnName("student_dob");

                entity.Property(e => e.StudentEmailId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("student_email_id");

                entity.Property(e => e.StudentGender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("student_gender");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("student_name");

                entity.Property(e => e.StudentRollNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("student_roll_no");


                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__student__class_i__787EE5A0");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("subject_name");

                
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserContactNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("user_contact_no");

                entity.Property(e => e.UserCreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("user_created_on");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserProfile)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("user_profile");

                entity.Property(e => e.UserStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_status");

                entity.Property(e => e.UserType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });

            modelBuilder.Entity<ClassSubjectRelation>(entity =>
            {
                entity.ToTable("ClassSubjectRelation");
               
                entity.Property(e => e.CS_Id).HasColumnName("id");
                entity.HasKey(e => e.CS_Id);


                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            });

            modelBuilder.Entity<ExamClassRelation>(entity =>
            {
                entity.ToTable("ExamClassRelation");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ResultPublished)
              .HasColumnName("result_published");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.ClassID).HasColumnName("class_id");

                entity.Property(e => e.ExamYear).HasColumnName("exam_year");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
