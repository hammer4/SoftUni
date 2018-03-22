using System;
using System.Collections.Generic;
using System.Text;

public class Logger : ILogger
{
    public Logger(params IAppender[] appenders)
    {
        this.Appenders = appenders;
    }

    public ICollection<IAppender> Appenders { get; private set; }

    public void Critical(string date, string message)
    {
        foreach(var appender in Appenders)
        {
            appender.Append(date, ReportLevel.CRITICAL, message);
        }
    }

    public void Error(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, ReportLevel.ERROR, message);
        }
    }

    public void Fatal(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, ReportLevel.FATAL, message);
        }
    }

    public void Info(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, ReportLevel.INFO, message);
        }
    }

    public void Warn(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, ReportLevel.WARNING, message);
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine("Logger info");

        foreach(var appender in this.Appenders)
        {
            builder.AppendLine(appender.ToString());
        }

        return builder.ToString().TrimEnd();
    }
}