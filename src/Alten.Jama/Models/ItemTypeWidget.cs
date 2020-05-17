namespace Alten.Jama.Models
{
    public sealed class ItemTypeWidget
    {
        public static readonly ItemTypeWidget Activities = new ItemTypeWidget("ACTIVITIES");
        public static readonly ItemTypeWidget Attachments = new ItemTypeWidget("ATTACHMENTS");
        public static readonly ItemTypeWidget ChangeRequests = new ItemTypeWidget("CHANGE_REQUESTS");
        public static readonly ItemTypeWidget FolderList = new ItemTypeWidget("FOLDER_LIST");
        public static readonly ItemTypeWidget History = new ItemTypeWidget("HISTORY");
        public static readonly ItemTypeWidget InsideChangeRequest = new ItemTypeWidget("INSIDE_CHANGE_REQUEST");
        public static readonly ItemTypeWidget ItemsWithAttachment = new ItemTypeWidget("ITEMS_WITH_ATTACHMENT");
        public static readonly ItemTypeWidget Relationships = new ItemTypeWidget("RELATIONSHIPS");
        public static readonly ItemTypeWidget Risk = new ItemTypeWidget("RISK");
        public static readonly ItemTypeWidget Selenium = new ItemTypeWidget("SELENIUM");
        public static readonly ItemTypeWidget SynchronizedItems = new ItemTypeWidget("SYNCHRONIZED_ITEMS");
        public static readonly ItemTypeWidget Tags = new ItemTypeWidget("TAGS");
        public static readonly ItemTypeWidget TestCase = new ItemTypeWidget("TEST_CASE");
        public static readonly ItemTypeWidget TestHistoryOld = new ItemTypeWidget("TEST_HISTORY_OLD");
        public static readonly ItemTypeWidget TestRuns = new ItemTypeWidget("TEST_RUNS");
        public static readonly ItemTypeWidget Urls = new ItemTypeWidget("URLS");
        public static readonly ItemTypeWidget Versions = new ItemTypeWidget("VERSIONS");

        public ItemTypeWidget() { }

        private ItemTypeWidget(string name) => Name = name;

        public string Name { get; set; }

        public bool Synchronize { get; set; }
    }
}