using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Waver_InfoApp.Entities
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SmisStudent> SmisStudent { get; set; }
        public virtual DbSet<SmisWaiverInfo> SmisWaiverInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("server=192.168.10.124\\SQLEXPRESS;User Id=sa;Password=Start777;database=ERP");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmisStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__student__7F60ED59");

                entity.ToTable("SMIS_STUDENT");

                entity.Property(e => e.StudentId)
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalInfoOfStudent)
                    .HasColumnName("additionalInfoOfStudent")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AdmReferenceName)
                    .HasColumnName("ADM_REFERENCE_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdmissionFromSlno)
                    .HasColumnName("ADMISSION_FROM_SLNO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BatchId)
                    .IsRequired()
                    .HasColumnName("BATCH_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlockCause)
                    .HasColumnName("BLOCK_CAUSE")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Blocked)
                    .HasColumnName("BLOCKED")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BrifDescription)
                    .HasColumnName("brifDescription")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CommentsAcc)
                    .HasColumnName("COMMENTS_ACC")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompletionDate)
                    .HasColumnName("COMPLETION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("CREATED_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocLoc)
                    .HasColumnName("DOC_LOC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DropCause)
                    .HasColumnName("DROP_CAUSE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnName("ENROLLMENT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExDiu)
                    .HasColumnName("EX_DIU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExemptedCredit)
                    .HasColumnName("EXEMPTED_CREDIT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpireDate)
                    .HasColumnName("EXPIRE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkAdmissionReferenceDetails).HasColumnName("FK_ADMISSION_REFERENCE_DETAILS");

                entity.Property(e => e.FkCampus)
                    .IsRequired()
                    .HasColumnName("FK_CAMPUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FkConvocation).HasColumnName("FK_CONVOCATION");

                entity.Property(e => e.FkPassingDiscipline).HasColumnName("FK_PASSING_DISCIPLINE");

                entity.Property(e => e.FkStudentIdOfRelative)
                    .HasColumnName("FK_STUDENT_ID_OF_RELATIVE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GoldenGpa)
                    .HasColumnName("GOLDEN_GPA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GradeLetter)
                    .HasColumnName("GRADE_LETTER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GradePoints).HasColumnName("GRADE_POINTS");

                entity.Property(e => e.GraduationCgpa)
                    .HasColumnName("GRADUATION_CGPA")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.HscCgpa)
                    .HasColumnName("HSC_CGPA")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.InitialPassword)
                    .HasColumnName("INITIAL_PASSWORD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InitialProblem)
                    .HasColumnName("initialProblem")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Laptop)
                    .IsRequired()
                    .HasColumnName("LAPTOP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LastSemester)
                    .HasColumnName("LAST_SEMESTER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastSemesterRemarks)
                    .HasColumnName("LAST_SEMESTER_REMARKS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MastersCgpa)
                    .HasColumnName("MASTERS_CGPA")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnName("MODIFIED_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NetCredit)
                    .HasColumnName("NET_CREDIT")
                    .HasComputedColumnSql("([PROGRAM_CREDIT]-[EXEMPTED_CREDIT])");

                entity.Property(e => e.PassOutDate)
                    .HasColumnName("PASS_OUT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.PassOutSemester)
                    .HasColumnName("PASS_OUT_SEMESTER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentScheme).HasColumnName("PAYMENT_SCHEME");

                entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");

                entity.Property(e => e.PersonalInterest)
                    .HasColumnName("personalInterest")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramCredit)
                    .HasColumnName("PROGRAM_CREDIT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Reference)
                    .HasColumnName("REFERENCE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityCode)
                    .HasColumnName("SECURITY_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasColumnName("SHIFT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SscCgpa)
                    .HasColumnName("SSC_CGPA")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.StrangthOfStudent)
                    .HasColumnName("strangthOfStudent")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TotalMarks).HasColumnName("TOTAL_MARKS");

                entity.Property(e => e.TransferId)
                    .HasColumnName("TRANSFER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeaknessOfStudent)
                    .HasColumnName("weaknessOfStudent")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkStudentIdOfRelativeNavigation)
                    .WithMany(p => p.InverseFkStudentIdOfRelativeNavigation)
                    .HasForeignKey(d => d.FkStudentIdOfRelative)
                    .HasConstraintName("FK_SMIS_STUDENT_SMIS_STUDENT_OF_RELATIVE");

                entity.HasOne(d => d.Transfer)
                    .WithMany(p => p.InverseTransfer)
                    .HasForeignKey(d => d.TransferId)
                    .HasConstraintName("FK_SMIS_STUDENT_SMIS_STUDENT");
            });

            modelBuilder.Entity<SmisWaiverInfo>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("SMIS_WAIVER_INFO");

                entity.Property(e => e.StudentId)
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("CREATED_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnName("MODIFIED_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WaiverPercent).HasColumnName("WAIVER_PERCENT");

                entity.Property(e => e.Yn)
                    .IsRequired()
                    .HasColumnName("YN")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.SmisWaiverInfo)
                    .HasForeignKey<SmisWaiverInfo>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMIS_WAIVER_INFO_SMIS_STUDENT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
