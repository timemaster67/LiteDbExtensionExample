using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LiteDbExample.Persistence;
using LiteDB;
using AleRoe.LiteDB.Extensions.DependencyInjection;

namespace LiteDbExample
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IHost host = CreateHostBuilder(args).Build();

			//retrieve manually
			ILiteCollection<Persistence.Entity.Table1> table1 = host.Services.GetRequiredService<ILiteCollection<Persistence.Entity.Table1>>();
			table1.Insert(new Persistence.Entity.Table1() { Now = DateTime.Now });
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) =>
				{
					services.AddHostedService<Worker>();
					services.AddLiteDbCollection<Persistence.Entity.Table1>();
					services.AddLiteDatabase(":memory:");
				});
	}
}
