namespace JobCandidateHub.Cache
{
	public interface IJobCandidateCache<T>
	{
		public T GetCache(string key);
		public void SetCache(string key, T value);
		public void PurgeCache();
	}
}
