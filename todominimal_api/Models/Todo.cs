using System;
using System.Collections.Generic;

namespace todominimal_api.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string Todo1 { get; set; } = null!;

    public string Completed { get; set; } = null!;

    public int UserId { get; set; }
}
