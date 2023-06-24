using System;
using System.Collections.Generic;

namespace JatraApplication.Models.DatabaseModels;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public string? EventDescription { get; set; }

    public DateTime EventStartDate { get; set; }

    public DateTime EventEndDate { get; set; }

    public string? EventLocation { get; set; }

    public string? EventCommunity { get; set; }

    public string? EventHighlights { get; set; }

}
