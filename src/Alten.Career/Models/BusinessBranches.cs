using System;
using System.ComponentModel;

namespace Alten.Career.Models
{
    [Flags]
    public enum BusinessBranches
    {
        [Description("Other Branches")]
        None = 0,

        [Description("Automotive Engineering")]
        AutomotiveEngineering = 1,

        [Description("Electric & Electronic Engineering")]
        ElectricAndElectornicEngineering = 2,

        [Description("Semiconductor Technology")]
        SemiconductorTechnology = 4,
    }
}
