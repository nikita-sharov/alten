using System.Diagnostics.CodeAnalysis;

namespace Alten.Jama.Models
{
    // See: https://help.jamasoftware.com/ah/en/administration/organization-administrator/manage-content/fields.html
    [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Predefined")]
    public enum FieldType
    {
        Actions = 0,
        Boolean,
        Calculated,
        Date,
        DocumentType,
        DocumentTypeCategoryItemLookup,
        DocumentTypeItemLookup,
        Group,
        Integer,
        Lookup,
        MultiLookup,
        Project,
        RelationshipStatus,
        RelativeDateRange,
        Release,
        Rollup,
        Steps,
        String,
        TestCaseStatus,
        TestRunStatus,
        Text,
        Time,
        UrlString,
        User
    }
}