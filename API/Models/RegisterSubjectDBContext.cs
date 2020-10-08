using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class RegisterSubjectDBContext : DbContext
    {
        public RegisterSubjectDBContext()
        {
        }

        public RegisterSubjectDBContext(DbContextOptions<RegisterSubjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ClassMajor> ClassMajors { get; set; }
        public virtual DbSet<ClassRegister> ClassRegisters { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TrainingMode> TrainingModes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=RegisterSubjectDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdAccount);

                entity.ToTable("Account");

                entity.Property(e => e.IdAccount).HasColumnName("id_account");

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ClassMajor>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PK_Class");

                entity.ToTable("ClassMajor");

                entity.Property(e => e.IdClass)
                    .HasColumnName("id_class")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdFaculty)
                    .HasColumnName("id_faculty")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdLecturers)
                    .HasColumnName("id_Lecturers")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NameClass)
                    .HasColumnName("name_class")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdLecturersNavigation)
                    .WithMany(p => p.ClassMajors)
                    .HasForeignKey(d => d.IdLecturers)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Class_Lecturers");
            });

            modelBuilder.Entity<ClassRegister>(entity =>
            {
                entity.HasKey(e => e.IdClassRegister)
                    .HasName("PK_ClassSubject");

                entity.ToTable("ClassRegister");

                entity.Property(e => e.IdClassRegister)
                    .HasColumnName("id_ClassRegister")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdLecturers)
                    .HasColumnName("id_lecturers")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdSemester)
                    .HasColumnName("id_Semester")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdStudent)
                    .HasColumnName("id_student")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdSubject)
                    .HasColumnName("id_subject")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Room)
                    .HasColumnName("room")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdLecturersNavigation)
                    .WithMany(p => p.ClassRegisters)
                    .HasForeignKey(d => d.IdLecturers)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ClassRegister_Lecturers");

                entity.HasOne(d => d.IdSemesterNavigation)
                    .WithMany(p => p.ClassRegisters)
                    .HasForeignKey(d => d.IdSemester)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ClassRegister_Semester");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.ClassRegisters)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK_ClassRegister_Subject");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.HasKey(e => e.IdDegree);

                entity.ToTable("Degree");

                entity.Property(e => e.IdDegree)
                    .HasColumnName("id_degree")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NameDegree)
                    .HasColumnName("name_degree")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.IdDepartment);

                entity.ToTable("Department");

                entity.Property(e => e.IdDepartment)
                    .HasColumnName("id_department")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdFaculty)
                    .HasColumnName("id_faculty")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NameDepartment)
                    .HasColumnName("name_department")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.IdFaculty)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Department_Faculty");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.IdFaculty);

                entity.ToTable("Faculty");

                entity.Property(e => e.IdFaculty)
                    .HasColumnName("id_faculty")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NameFaculty)
                    .HasColumnName("name_faculty")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasKey(e => e.IdLecturers);

                entity.Property(e => e.IdLecturers)
                    .HasColumnName("id_lecturers")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250);

                entity.Property(e => e.IdDegree)
                    .HasColumnName("id_degree")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdDepartment)
                    .HasColumnName("id_department")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.PassAccount)
                    .HasColumnName("passAccount")
                    .HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.HasOne(d => d.IdDegreeNavigation)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.IdDegree)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Lecturers_Degree");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Lecturers_Department");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.IdSemester)
                    .HasName("PK_Semester_1");

                entity.ToTable("Semester");

                entity.Property(e => e.IdSemester)
                    .HasColumnName("id_semester")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent);

                entity.ToTable("Student");

                entity.Property(e => e.IdStudent)
                    .HasColumnName("id_student")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250);

                entity.Property(e => e.IdClass)
                    .HasColumnName("id_class")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdTrainingMode)
                    .HasColumnName("id_TrainingMode")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.PassAccount)
                    .HasColumnName("passAccount")
                    .HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Student_ClassMajor");

                entity.HasOne(d => d.IdTrainingModeNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdTrainingMode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Student_TrainingMode");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject);

                entity.ToTable("Subject");

                entity.Property(e => e.IdSubject)
                    .HasColumnName("id_subject")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NameSubject)
                    .HasColumnName("name_subject")
                    .HasMaxLength(250);

                entity.Property(e => e.NumberOfCredits).HasColumnName("number_of_credits");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TrainingMode>(entity =>
            {
                entity.HasKey(e => e.IdTrainingMode);

                entity.ToTable("TrainingMode");

                entity.Property(e => e.IdTrainingMode)
                    .HasColumnName("id_trainingMode")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NameTraing)
                    .HasColumnName("name_traing")
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
