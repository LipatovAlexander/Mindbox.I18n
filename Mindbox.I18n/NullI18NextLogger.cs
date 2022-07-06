using System;

namespace Mindbox.I18n;

public class NullI18NextLogger : ILogger
{
	public void LogMissingNamespace(Locale locale, string @namespace, string key)
	{
		// empty
	}

	public void LogMissingLocale(Locale locale, string key)
	{
		// empty
	}

	public void LogMissingKey(Locale locale, string @namespace, string key)
	{
		// empty
	}

	public void LogInvalidKey(string key)
	{
		// empty
	}

	public void LogInvalidOperation(string message)
	{
		// empty
	}

	public void LogError(Exception exception, string message)
	{
		// empty
	}
}