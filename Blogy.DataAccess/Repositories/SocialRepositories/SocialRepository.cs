﻿using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entites;

namespace Blogy.DataAccess.Repositories.SocialRepositories;

public class SocialRepository : GenericRepository<Social>, ISocialRepository
{
    public SocialRepository(AppDbContext context) : base(context)
    {
    }
}
