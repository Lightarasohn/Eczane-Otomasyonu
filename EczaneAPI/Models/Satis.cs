using System;
using System.Collections.Generic;

namespace EczaneAPI.Models;

public partial class Satis
{
    public int Id { get; set; }

    public string AliciEmail { get; set; } = null!;

    public DateTime SatisTarihi { get; set; }

    public virtual ICollection<SatisIlac> SatisIlacs { get; set; } = new List<SatisIlac>();
}
