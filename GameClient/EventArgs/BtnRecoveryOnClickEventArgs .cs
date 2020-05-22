namespace GameClient.EventArgs
{
	public class BtnRecoveryOnClickEventArgs : System.EventArgs
	{
		public string Username { set; get; }
		public string BirthDate { set; get; }
		public string SecurityText { set; get; }
	}
}
