using System;
using System.Collections.Generic;

namespace EczaneAPI.Models;

public partial class Satis
{
    public int Id { get; set; }

    public string AliciEmail { get; set; } = null!;

    public int IlacId { get; set; }

    public DateTime SatisTarihi { get; set; }

    public virtual Ilac Ilac { get; set; } = null!;
}
