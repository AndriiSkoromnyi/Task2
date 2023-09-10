using Newtonsoft.Json;

namespace SampleHierarchies.Gui
{
    public static class ScreenDefinitionService
    {
        public static ScreenDefinition Load(string jsonFileName)
        {
            try
            {
                string jsonData = File.ReadAllText(jsonFileName)!;
                ScreenDefinition? screenDefinition = JsonConvert.DeserializeObject<ScreenDefinition>(jsonData);
                return screenDefinition!;
            }
            catch
            {
                return null!;
            }
        }

        public static bool Save(ScreenDefinition screenDefinition, string jsonFileName)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(screenDefinition, Formatting.Indented);
                File.WriteAllText(jsonFileName, jsonData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DisplayScreenLinesWithColors(string filePath, int Numb)
        {
            ScreenDefinition screenDefinition = Load(filePath);
            Console.ForegroundColor = screenDefinition.LineEntries[Numb].ForegroundColor;
            Console.BackgroundColor = screenDefinition.LineEntries[Numb].BackgroundColor;
            Console.WriteLine(screenDefinition.LineEntries[Numb].Text);
        }
    }
}
