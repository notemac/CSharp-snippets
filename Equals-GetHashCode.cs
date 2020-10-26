class Entry
{
	public string m_UserLogin;
	public string m_OrgCode;
	public Entry(string userLogin, string orgCode)
	{
		m_UserLogin = userLogin;
		m_OrgCode = orgCode;
	}
	public override bool Equals(object obj)
	{
		// Often we should compare an instance with itself, 
		// so let's have a special case for it (optimization)
		if (ReferenceEquals(this, obj))
			return true;

		Entry other = obj as Entry;
		// other != null line in your code can cause StackOverflow:
		// "!=" calls "Equals" which in turn calls "!=" etc...
		if (ReferenceEquals(null, other))
			return false;

		// class members can be null
		if (ReferenceEquals(m_UserLogin, other.m_UserLogin) && ReferenceEquals(m_OrgCode, other.m_OrgCode))
			return true;
		else if (ReferenceEquals(m_UserLogin, null) || ReferenceEquals(other.m_UserLogin, null)
				|| ReferenceEquals(m_OrgCode, null) || ReferenceEquals(other.m_OrgCode, null))
			return false;

		return String.Equals(m_UserLogin, other.m_UserLogin, StringComparison.OrdinalIgnoreCase)
			&& String.Equals(m_OrgCode, other.m_OrgCode, StringComparison.OrdinalIgnoreCase);
	}
	public override int GetHashCode()
	{
		unchecked
		{
			// Choose large primes to avoid hashing collisions
			const int hashMultiplier = 16777619;
			int hash = (int)2166136261;
			hash = (hash * hashMultiplier) + (ReferenceEquals(null, m_UserLogin) ? 0 : m_UserLogin.GetHashCode());
			hash = (hash * hashMultiplier) + (ReferenceEquals(null, m_OrgCode) ? 0 : m_OrgCode.GetHashCode());
			// It's typical to return 0 in case of null
			return hash;
		}
	}
}
