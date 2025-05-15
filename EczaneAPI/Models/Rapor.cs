using System;
using System.Collections.Generic;

namespace EczaneAPI.Models;

public partial class Rapor
{
    public int Id { get; set; }

    public DateOnly BaslangicTarihi { get; set; }

    public DateOnly BitisTarihi { get; set; }

    public virtual ICollection<RaporSatis> RaporSatis { get; set; } = new List<RaporSatis>();
}
