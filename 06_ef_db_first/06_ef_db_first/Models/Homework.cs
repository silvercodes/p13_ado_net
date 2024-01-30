using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class Homework
{
    public int Id { get; set; }

    public string Theme { get; set; } = null!;

    public string FileLink { get; set; } = null!;

    public string CoverLink { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime UploadDate { get; set; }

    public DateTime DeadlineDate { get; set; }

    public virtual Pair IdNavigation { get; set; } = null!;

    public virtual ICollection<UploadedHomework> UploadedHomeworks { get; set; } = new List<UploadedHomework>();
}
