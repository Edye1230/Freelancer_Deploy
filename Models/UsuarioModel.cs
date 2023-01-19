using System;
using System.Collections.Generic;

namespace Freelancer_Deploy.Models;

public partial class UsuarioModel
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? DocType { get; set; }

    public string? DocNumber { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Currency { get; set; }

    public string? TotalAmmount { get; set; }

    public string? Logo { get; set; }
}
