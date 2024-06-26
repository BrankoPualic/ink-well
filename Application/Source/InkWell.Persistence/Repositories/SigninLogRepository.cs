﻿using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;

namespace InkWell.Persistence.Repositories;

public class SigninLogRepository : RepositoryContext, ISigninLogRepository
{
	public SigninLogRepository(InkWellContext context) : base(context)
	{
	}

	public void Add(SigninLog log)
	{
		Context.SigninLogs.Add(log);
	}
}