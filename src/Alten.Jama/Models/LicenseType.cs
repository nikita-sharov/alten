namespace Alten.Jama.Models
{
    // See: https://help.jamasoftware.com/ah/en/administration/organization-administrator/manage-users/license-types.html
    public enum LicenseType
    {
        Named = 0,
        Floating,
        Stakeholder,
        FloatingCollaborator,
        ReservedCollaborator,
        FloatingREViewer,
        ReservedReviewer,
        NamedReviewer,
        TestRunner,
        ExpiringTrial,
        Inactive
    }
}