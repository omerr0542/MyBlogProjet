﻿using Blogy.Entity.Entites.Common;

namespace Blogy.Entity.Entites;

public class Social : BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
