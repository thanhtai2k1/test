using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLSV.Entities
{
    public partial class SM5Context : DbContext
    {
        public SM5Context()
        {
        }

        public SM5Context(DbContextOptions<SM5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Examp> Examps { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DRTHKFS\\THANHTAI;Initial Catalog=SM5;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("CLASS");

                entity.Property(e => e.Classid)
                    .ValueGeneratedNever()
                    .HasColumnName("CLASSID");

                entity.Property(e => e.Classname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLASSNAME");

                entity.Property(e => e.Courseid).HasColumnName("COURSEID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Courseid)
                    .HasConstraintName("FK__CLASS__COURSEID__3F466844");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .ValueGeneratedNever()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");
            });

            modelBuilder.Entity<Examp>(entity =>
            {
                entity.HasKey(e => e.Examid)
                    .HasName("PK__EXAMP__8D5AA6D0A44FE74A");

                entity.ToTable("EXAMP");

                entity.Property(e => e.Examid)
                    .ValueGeneratedNever()
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Examname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXAMNAME");

                entity.Property(e => e.Examps).HasColumnName("EXAMPS");

                entity.Property(e => e.Ranks)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RANKs");

                entity.Property(e => e.Studentid).HasColumnName("STUDENTID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Examps)
                    .HasForeignKey(d => d.Studentid)
                    .HasConstraintName("FK__EXAMP__STUDENTID__403A8C7D");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENTS");

                entity.Property(e => e.Studentid)
                    .ValueGeneratedNever()
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Andress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ANDRESS");

                entity.Property(e => e.Loginname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGINNAME");

                entity.Property(e => e.Passwords)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORDS");

                entity.Property(e => e.Studenname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STUDENNAME");

                entity.Property(e => e.Subjectid).HasColumnName("SUBJECTID");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Subjectid)
                    .HasConstraintName("FK__STUDENTS__SUBJEC__412EB0B6");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("SUBJECTs");

                entity.Property(e => e.Subjectid)
                    .ValueGeneratedNever()
                    .HasColumnName("SUBJECTID");

                entity.Property(e => e.Classid).HasColumnName("CLASSID");

                entity.Property(e => e.Subjectname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECTNAME");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.Classid)
                    .HasConstraintName("FK__SUBJECTs__CLASSI__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
