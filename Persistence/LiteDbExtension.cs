using Microsoft.Extensions.DependencyInjection;

namespace LiteDbExample.Persistence
{
	internal static class LiteDbExtension
	{
		internal static void AddLiteDbCollection<T>(this IServiceCollection collection)
		{
			collection.AddTransient<LiteDB.ILiteCollection<T>>(serviceProvider =>
			{
				var database = serviceProvider.GetRequiredService<LiteDB.LiteDatabase>();
				return database.GetCollection<T>();
			});
		}

	}


}
