using System;
using System.ComponentModel;

namespace Alten.Career.Models
{
    [Flags]    
    public enum ApplicationAreas
    {
        [Description("Other applications")]
        None = 0,

        Commissioning = 1,

        [Description("Requirements / Systems Engineering")]
        RequirementsAndOrSystemsEngineering = 2,

        SoftwareDevelopment = 4
    }
}
