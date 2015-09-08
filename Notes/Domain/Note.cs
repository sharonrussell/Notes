namespace Notes
{
    public class Note
    {
        private string _text;

        public Note(string text)
        {
            SetText(text);
        }

        public void SetText(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
    }
}
