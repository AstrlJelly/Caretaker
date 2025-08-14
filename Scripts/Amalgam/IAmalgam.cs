namespace Amalgam;

interface IAmalgam
{
    public enum ClientType
    {
        Discord = 0x0001,
        Revolt  = 0x0010,
    }
    // intended to check if both values in amalgam object are null
    public bool IsNull();
}