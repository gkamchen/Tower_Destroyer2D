namespace GameClient.EventArgs
{
	public class BtnUpdatePasswordOnClickEventArgs : System.EventArgs
	{
		public int IdPlayer { set; get; }
		public string Password { set; get; }
	}
}
