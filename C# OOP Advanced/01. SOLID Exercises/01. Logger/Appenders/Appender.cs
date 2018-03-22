using System;
using System.Collections.Generic;
using System.Text;

public abstract class Appender : IAppender
{
    protected Appender(ILayout layout)
    {
        this.Layout = layout;
        this.ReportLevel = ReportLevel.INFO;
    }

    public int MessagesCount { get; protected set; }

    public ReportLevel ReportLevel { get; set; }

    public ILayout Layout { get; private set; }

    public abstract void Append(string date, ReportLevel level, string message);

    public override string ToString()
    {
        return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
    }
}