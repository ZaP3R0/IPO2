namespace pokemon
{
    internal class AdaptiveText
    {
        public AdaptiveText()
        {
        }

        public string Text { get; set; }
        public object HintStyle { get; set; }
        public bool HintWrap { get; internal set; }
    }
}