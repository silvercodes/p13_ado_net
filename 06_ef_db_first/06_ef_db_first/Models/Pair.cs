using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class Pair
{
    public int Id { get; set; }

    public DateTime PairDate { get; set; }

    public int ScheduleItemId { get; set; }

    public int SubjectId { get; set; }

    public bool IsOnline { get; set; }

    public int? ClassroomId { get; set; }

    public int TeacherId { get; set; }

    public byte TeacherStatus { get; set; }

    public string Theme { get; set; } = null!;

    public virtual Classroom? Classroom { get; set; }

    public virtual Homework? Homework { get; set; }

    public virtual ICollection<PairsStudent> PairsStudents { get; set; } = new List<PairsStudent>();

    public virtual ScheduleItem ScheduleItem { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
