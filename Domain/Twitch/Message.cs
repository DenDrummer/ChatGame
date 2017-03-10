namespace ChatGame.BL.Domain
{
    public class Message
    {
        public string Msg { get; }
        public string Issuer { get; }
        public bool IsDirectedMsg { get; set; }

        public Message(string msg, string issuer)
        {
            Msg = msg;
            Issuer = issuer;
        }

        public override string ToString()
        {
            if (IsDirectedMsg)
            {
                return $"@{Issuer} : {Msg}";
            }
            else
            {
                return Msg;
            }
        }
    }
}
