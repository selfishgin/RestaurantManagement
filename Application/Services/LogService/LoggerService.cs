﻿
using Serilog;

namespace Application.Services.LogService;

public class LoggerService : ILoggerService
{
	public void LogError(string message, Exception ex)
	{
		Log.Error(message, ex);
	}

	public void LogInfo(string message)
	{
		Log.Information(message);
	}

	public void LogWarning(string message)
	{
		Log.Warning(message);
	}
}
