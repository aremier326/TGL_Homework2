namespace Homework2.Utils;

public class RacingCarEventArgs : EventArgs
{
    public readonly string msg;
    public RacingCarEventArgs(string msg)
    {
        this.msg = msg;
    }
}