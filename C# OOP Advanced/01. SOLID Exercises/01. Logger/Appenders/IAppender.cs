using System;
using System.Collections.Generic;
using System.Text;

public interface IAppender
{
    ILayout Layout { get; }

    void Append(string date, ReportLevel level, string message);

    ReportLevel ReportLevel { get; set; }
}