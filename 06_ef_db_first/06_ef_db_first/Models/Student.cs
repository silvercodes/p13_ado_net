using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<GroupsStudent> GroupsStudents { get; set; } = new List<GroupsStudent>();

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<PairsStudent> PairsStudents { get; set; } = new List<PairsStudent>();

    public virtual ICollection<UploadedHomework> UploadedHomeworks { get; set; } = new List<UploadedHomework>();
}
