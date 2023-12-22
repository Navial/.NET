using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
