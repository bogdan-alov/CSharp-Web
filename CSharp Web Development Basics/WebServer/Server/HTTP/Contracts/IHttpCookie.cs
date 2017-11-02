using System;

namespace WebServer.Server.HTTP.Contracts
{
	public interface IHttpCookie
	{
		string Key { get; }

		string Value { get; }

		DateTime Expires { get; }

		bool IsNew { get; }

	}
}