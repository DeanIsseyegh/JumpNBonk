namespace Boss.States
{
    public class FrogBossDirection
    {
        public const int FacingLeft = -1;
        public const int FacingRight = 1;

        public static int SwapDir(int currentDir)
        {
            return currentDir == FacingLeft ? FacingRight : FacingLeft;
        }
    }
}