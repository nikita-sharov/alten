namespace Alten.Jama.Models
{
    // See: https://help.jamasoftware.com/ah/en/administration/organization-administrator/manage-users/license-types.html
    public enum LicenseType
    {
        ExpiringTrial = 0,
        Floating,
        FloatingCollaborator,
        FloatingReviewer,
        Inactive,
        Named,
        NamedReviewer,
        ReservedCollaborator,
        ReservedReviewer,
        Stakeholder,
        TestRunner
    }
}