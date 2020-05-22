namespace GameClient.EventArgs
{
	public class BtnSaveOnClickEventArgs : System.EventArgs
	{
		public string Name { set; get; }
		public string Username { set; get; }
		public string Password { set; get; }
		public string BirthDate { set; get; }
		public string SecurityText { set; get; }
	}
}
