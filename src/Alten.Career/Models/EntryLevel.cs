using System;
using System.ComponentModel;

namespace Alten.Career.Models
{
    [Flags]
    [Description("Level of entry")]
    public enum EntryLevels
    {
        [Description("Unspecified")]
        None = 0,

        [Description("Young professionals")]
        YoungProfessionals = 1,

        [Description("Professionals")]
        ExperiencedProfessionals = 2
    }
}
