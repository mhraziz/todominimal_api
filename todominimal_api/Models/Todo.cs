using System;
using System.Collections.Generic;

namespace todominimal_api.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string? Todo1 { get; set; }

    public string? Completed { get; set; }

    //public int UserId { get; set; }
}
