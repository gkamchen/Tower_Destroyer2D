namespace GameClient.EventArgs
{
    public class EnemyAttackEventArgs : System.EventArgs
    {
        public int Line { get; set; }
        public int Column { get; set; }
    }
}
