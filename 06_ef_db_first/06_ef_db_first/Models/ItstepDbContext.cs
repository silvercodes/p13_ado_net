using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _06_ef_db_first.Models;

public partial class ItstepDbContext : DbContext
{
    public ItstepDbContext()
    {
    }

    public ItstepDbContext(DbContextOptions<ItstepDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupsStudent> GroupsStudents { get; set; }

    public virtual DbSet<Homework> Homeworks { get; set; }

    public virtual DbSet<Pair> Pairs { get; set; }

    public virtual DbSet<PairsStudent> PairsStudents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ScheduleItem> ScheduleItems { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<UploadedHomework> UploadedHomeworks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=itstep_db;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__branches__3213E83F2F66A687");

            entity.ToTable("branches");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Title)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.City).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_branches_city");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cities__3213E83F5D4D55E6");

            entity.ToTable("cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classroo__3213E83F4F88C679");

            entity.ToTable("classrooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Number)
                .HasMaxLength(32)
                .HasColumnName("number");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");

            entity.HasOne(d => d.Branch).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_classrooms_branch");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__groups__3213E83F7B091443");

            entity.ToTable("groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasMany(d => d.Pairs).WithMany(p => p.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupsPair",
                    r => r.HasOne<Pair>().WithMany()
                        .HasForeignKey("PairId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_groups_pairs_pair"),
                    l => l.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_groups_pairs_group"),
                    j =>
                    {
                        j.HasKey("GroupId", "PairId");
                        j.ToTable("groups_pairs");
                        j.IndexerProperty<int>("GroupId").HasColumnName("group_id");
                        j.IndexerProperty<int>("PairId").HasColumnName("pair_id");
                    });
        });

        modelBuilder.Entity<GroupsStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__groups_s__3213E83FF0A8A55E");

            entity.ToTable("groups_students");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("end_date");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("start_date");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupsStudents)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_groups_students_group");

            entity.HasOne(d => d.Student).WithMany(p => p.GroupsStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_groups_students_student");
        });

        modelBuilder.Entity<Homework>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__homework__3213E83FBF40D30D");

            entity.ToTable("homeworks");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CoverLink)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("cover_link");
            entity.Property(e => e.DeadlineDate)
                .HasColumnType("date")
                .HasColumnName("deadline_date");
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .HasColumnName("description");
            entity.Property(e => e.FileLink)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("file_link");
            entity.Property(e => e.Theme)
                .HasMaxLength(256)
                .HasColumnName("theme");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("upload_date");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Homework)
                .HasForeignKey<Homework>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_homework_pair");
        });

        modelBuilder.Entity<Pair>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pairs__3213E83F30E16C27");

            entity.ToTable("pairs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.IsOnline).HasColumnName("is_online");
            entity.Property(e => e.PairDate)
                .HasColumnType("date")
                .HasColumnName("pair_date");
            entity.Property(e => e.ScheduleItemId).HasColumnName("schedule_item_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.TeacherStatus).HasColumnName("teacher_status");
            entity.Property(e => e.Theme)
                .HasMaxLength(256)
                .HasColumnName("theme");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Pairs)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK_pairs_classroom");

            entity.HasOne(d => d.ScheduleItem).WithMany(p => p.Pairs)
                .HasForeignKey(d => d.ScheduleItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pairs_schedule_item");

            entity.HasOne(d => d.Subject).WithMany(p => p.Pairs)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pairs_subject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Pairs)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pairs_teacher");
        });

        modelBuilder.Entity<PairsStudent>(entity =>
        {
            entity.HasKey(e => new { e.PairId, e.StudentId });

            entity.ToTable("pairs_students");

            entity.Property(e => e.PairId).HasColumnName("pair_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(1024)
                .HasColumnName("comment");
            entity.Property(e => e.IsOnline).HasColumnName("is_online");
            entity.Property(e => e.PairGrade).HasColumnName("pair_grade");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((3))")
                .HasColumnName("status");
            entity.Property(e => e.TestGrade).HasColumnName("test_grade");

            entity.HasOne(d => d.Pair).WithMany(p => p.PairsStudents)
                .HasForeignKey(d => d.PairId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pairs_students_pairs");

            entity.HasOne(d => d.Student).WithMany(p => p.PairsStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pairs_students_students");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F0C6B5DD0");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ScheduleItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__schedule__3213E83F468DCD5C");

            entity.ToTable("schedule_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemEnd).HasColumnName("item_end");
            entity.Property(e => e.ItemStart).HasColumnName("item_start");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83FA20C1FAF");

            entity.ToTable("students");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(64)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(64)
                .HasColumnName("last_name");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_student_user");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subjects__3213E83F3CC4A8D7");

            entity.ToTable("subjects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("smalldatetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Title)
                .HasMaxLength(256)
                .HasColumnName("title");

            entity.HasMany(d => d.Teachers).WithMany(p => p.Subjects)
                .UsingEntity<Dictionary<string, object>>(
                    "SubjectsTeacher",
                    r => r.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_subjects_teachers_teacher"),
                    l => l.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_subjects_teachers_subject"),
                    j =>
                    {
                        j.HasKey("SubjectId", "TeacherId");
                        j.ToTable("subjects_teachers");
                        j.IndexerProperty<int>("SubjectId").HasColumnName("subject_id");
                        j.IndexerProperty<int>("TeacherId").HasColumnName("teacher_id");
                    });
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teachers__3213E83FBD42F653");

            entity.ToTable("teachers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(64)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(64)
                .HasColumnName("last_name");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_teacher_user");
        });

        modelBuilder.Entity<UploadedHomework>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__uploaded__3213E83F62C26DD2");

            entity.ToTable("uploaded_homeworks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(1024)
                .HasColumnName("comment");
            entity.Property(e => e.FileLink)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("file_link");
            entity.Property(e => e.HomeworkId).HasColumnName("homework_id");
            entity.Property(e => e.SpentTime).HasColumnName("spent_time");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("upload_date");

            entity.HasOne(d => d.Homework).WithMany(p => p.UploadedHomeworks)
                .HasForeignKey(d => d.HomeworkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_uploaded_homeworks_homework");

            entity.HasOne(d => d.Student).WithMany(p => p.UploadedHomeworks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_uploaded_homeworks_student");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F8F814BFF");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E61647E12DCE6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Hash)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("hash");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
