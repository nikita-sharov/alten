using System.Collections.Generic;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_ItemType
    public sealed class ItemType : ItemTypeRequest
    {
        public int Id { get; set; }

        public List<ItemTypeField> Fields { get; set; }

        public bool System { get; set; }
    }
}
