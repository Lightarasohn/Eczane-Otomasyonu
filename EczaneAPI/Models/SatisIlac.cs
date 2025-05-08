using System;
using System.Collections.Generic;

namespace EczaneAPI.Models;

public partial class SatisIlac
{
    public int SatisId { get; set; }

    public int IlacId { get; set; }

    public int Miktar { get; set; }

    public virtual Ilac Ilac { get; set; } = null!;

    public virtual Satis Satis { get; set; } = null!;
}
