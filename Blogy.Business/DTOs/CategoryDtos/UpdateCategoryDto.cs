﻿using Blogy.Business.DTOs.Common;

namespace Blogy.Business.DTOs.CategoryDtos;

public class UpdateCategoryDto : BaseDto
{
    public string Name { get; set; }
}
