using System;
using System.ComponentModel;

namespace Alten.Career.Models
{
    [Flags]
    public enum BusinessBranches
    {
        // TODO: Compare to "Weitere Branchen" in German version.
        [Description("Sector irrelevant")]
        None = 0,

        AutomotiveEngineering = 1,

        [Description("Electric[al] <del>&</del>[and] Electronic Engineering")]
        ElectricalAndElectronicEngineering = 2,

        SemiconductorTechnology = 4,
    }
}
