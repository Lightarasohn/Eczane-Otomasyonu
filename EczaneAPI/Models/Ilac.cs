using System;
using System.Collections.Generic;

namespace EczaneAPI.Models;

public partial class Ilac
{
    public int Id { get; set; }

    public string Adi { get; set; } = null!;

    public double Fiyati { get; set; }

    public int StokDurumu { get; set; }

    public virtual ICollection<SatisIlac> SatisIlac { get; set; } = new List<SatisIlac>();
}
