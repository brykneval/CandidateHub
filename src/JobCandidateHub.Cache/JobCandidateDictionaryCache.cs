namespace JobCandidateHub.Cache
{
	public class JobCandidateDictionaryCache<T> : IJobCandidateCache<T>
	{
		private static IDictionary<string, T> _cache;
		public JobCandidateDictionaryCache()
		{
			if (_cache == null)
			{
				_cache = new Dictionary<string, T>();
			}
		}

		public T GetCache(string key)
		{
			_cache.TryGetValue(key, out T cachedItem);
			return cachedItem;
		}

		public void SetCache(string key, T value)
		{
			if (GetCache(key) == null)
			{
				_cache.Add(key, value);
			}
			else
			{
				_cache[key] = value;
			}
		}

		public void PurgeCache()
		{
			_cache = new Dictionary<string, T>();
		}
	}
}