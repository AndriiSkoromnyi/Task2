using SampleHierarchies.Interfaces.Data;
using System;
using System.Drawing;

namespace SampleHierarchies.Interfaces.Services
{
    public interface ISettingsService
    {
        Color MainScreenTextColor { get; set; }
        ISettings Settings { get; set; } // Adding the ISettings property
        void ChangeTextColors(ConsoleColor textColor);
    }
}
