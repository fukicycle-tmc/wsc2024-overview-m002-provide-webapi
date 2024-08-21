using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Shifting
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly ScheduleStartTime { get; set; }

    public TimeOnly ScheduleEndTime { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public int ShiftingTypeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ShiftingType ShiftingType { get; set; } = null!;
}
