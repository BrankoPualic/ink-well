using Dapper;
using InkWell.Domain.Entities.Application;
using InkWell.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InkWell.Test.Database;

public class DatabaseFixture : IDisposable
{
	private InkWellContext _context;

	public InkWellContext Context => _context;

	public DatabaseFixture()
	{
		_context = new InkWellContext("Data Source=localhost;Initial Catalog=InkWell_Test;TrustServerCertificate=true;Integrated security = true");
		CleanDb();
		InitDb();
	}

	private void InitDb()
	{
		var c1 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Sport",
		};

		var c2 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Lego",
		};

		var c3 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Movies",
		};

		var c4 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Basketball",
		};

		c4.Parent = c1;

		var c5 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Horror",
		};
		var c6 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Romance",
		};
		var c7 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Action",
		};

		c3.Children.Add(c5);
		c3.Children.Add(c6);
		c3.Children.Add(c7);

		_context.Categories.Add(c1);
		_context.Categories.Add(c4);
		_context.Categories.Add(c3);

		_context.SaveChanges();
	}

	public void Dispose()
	{
		CleanDb();
	}

	private void CleanDb()
	{
		using var connection = new SqlConnection("Data Source=localhost;Initial Catalog=InkWell_Test;TrustServerCertificate=true;Integrated security = true");
		connection.Execute("CleanDatabase", commandType: CommandType.StoredProcedure);
	}
}