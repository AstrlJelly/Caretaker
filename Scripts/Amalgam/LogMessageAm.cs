using RevoltSharp;

namespace Amalgam;

class LogMessageAm : IAmalgam
{
    internal class LogMessageR
    {
        string message;
        RevoltSharp.RevoltLogSeverity severity;
    }
    Discord.LogMessage? _d;
    LogMessageR? _r;

    // public static explicit operator LogMessageAm(Discord.LogMessage logMessage)
    public static implicit operator LogMessageAm(Discord.LogMessage logMessage)
    {
        return new LogMessageAm
        {
            _d = logMessage
        };
    }

    public static implicit operator LogMessageAm(LogMessageR logMessage)
    {
        return new LogMessageAm
        {
            _r = logMessage
        };
    }

    public override string ToString()
    {
        return base.ToString();
    }
}