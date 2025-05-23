﻿using System;
using System.Collections.Generic;

namespace EczaneAPI.Models;

public partial class Satis
{
    public int Id { get; set; }

    public string AliciEmail { get; set; } = null!;

    public DateTime SatisTarihi { get; set; }

    public virtual ICollection<RaporSatis> RaporSatis { get; set; } = new List<RaporSatis>();

    public virtual ICollection<SatisIlac> SatisIlac { get; set; } = new List<SatisIlac>();
}
