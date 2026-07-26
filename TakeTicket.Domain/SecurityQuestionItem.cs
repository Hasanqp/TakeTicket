namespace TakeTicket.Domain
{
    public class SecurityQuestionItem
    {
        public string Key { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
