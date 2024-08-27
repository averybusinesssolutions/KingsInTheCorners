namespace KiC.Core.Events
{
    public class MoveStackEventArgs
    {
        public MoveStackEventArgs(int stackToBeMoved, int stackedOn)
        {
            StackToBeMoved = stackToBeMoved;
            StackedOn = stackedOn;
        }

        public int StackToBeMoved { get; }
        public int StackedOn { get; }
    }
}