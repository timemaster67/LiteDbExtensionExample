using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using LiteDbExample.Persistence.Entity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LiteDbExample
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly ILiteCollection<Table1> table1Collection;

		public Worker(ILogger<Worker> logger, ILiteCollection<Table1> table1Collection)
		{
			_logger = logger;
			//Retrieved through constructor dependency injection
			this.table1Collection = table1Collection;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				_logger.LogInformation($"Found {table1Collection.Count()} entry in collection");
				table1Collection.Insert(new Table1() { Now = DateTime.Now });

				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}
