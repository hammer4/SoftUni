using System;
using System.Collections.Generic;
using System.Text;

public class Controller
{
    public void Act(int countOfAppenders)
    {
        IAppender[] appenders = new IAppender[countOfAppenders];

        for(int i=0; i<countOfAppenders; i++)
        {
            var input = Console.ReadLine().Split();

            ILayout layout = null;

            switch (input[1])
            {
                case nameof(SimpleLayout):
                    layout = new SimpleLayout();
                    break;
                case nameof(XmlLayout):
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException();
            }

            IAppender appender = null;

            switch (input[0])
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout);
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout);
                    ((FileAppender)appender).File = new LogFile();
                    break;
            }

            if(input.Length == 3)
            {
                ReportLevel level = (ReportLevel)Enum.Parse(typeof(ReportLevel), input[2]);
                appender.ReportLevel = level;
            }

            appenders[i] = appender;
        }

        var logger = new Logger(appenders);


        string command;

        while((command = Console.ReadLine()) != "END")
        {
            var input = command.Split('|');

            string time = input[1];
            string message = input[2];

            ReportLevel level = (ReportLevel)Enum.Parse(typeof(ReportLevel), input[0]);

            switch (level)
            {
                case ReportLevel.CRITICAL:
                    logger.Critical(time, message);
                    break;
                case ReportLevel.ERROR:
                    logger.Error(time, message);
                    break;
                case ReportLevel.FATAL:
                    logger.Fatal(time, message);
                    break;
                case ReportLevel.INFO:
                    logger.Info(time, message);
                    break;
                case ReportLevel.WARNING:
                    logger.Warn(time, message);
                    break;
            }
        }

        Console.WriteLine(logger);
    }
}