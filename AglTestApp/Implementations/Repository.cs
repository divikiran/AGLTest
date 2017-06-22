using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AglTestApp.Interfaces;
using SQLite.Net;

namespace AglTestApp.Implementations
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
		protected static readonly object _locker = new object();

		public SQLiteConnection Connection
		{
			get; set;
		}


		public virtual List<T> GetAll()
		{
			try
			{
				lock (_locker)
				{
					return Connection.Table<T>().ToList();
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
			return null;
		}
    }
}
