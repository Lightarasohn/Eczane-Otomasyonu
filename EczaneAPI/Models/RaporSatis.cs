using System;
using System.Collections.Generic;

namespace EczaneAPI.Models;

public partial class RaporSatis
{
    public int RaporId { get; set; }

    public int SatisId { get; set; }

    public double ToplamTutar { get; set; }

    public virtual Rapor Rapor { get; set; } = null!;

    public virtual Satis Satis { get; set; } = null!;
}
