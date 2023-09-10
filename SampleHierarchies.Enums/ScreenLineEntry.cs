namespace SampleHierarchies.Gui
{
    public class ScreenLineEntry
    {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public string Text { get; set; }

        public ScreenLineEntry(ConsoleColor backgroundColor, ConsoleColor foregroundColor, string text)
        {
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
            Text = text;
        }
    }
}
