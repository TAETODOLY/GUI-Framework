namespace TestSolution.Models
{
    public class ProjectModel
    {
        public int? Id { get; set; }
        public string? Content { get; set; }
        public int? ItemsCount { get; set; }
        public int? Icon { get; set; }
        public int? ItemType { get; set; }
        public int? ParentId { get; set; }
        public bool? Collapsed { get; set; }
        public int? ItemOrder { get; set; }
        public List<ProjectModel>? Children { get; set; }
        public bool? IsProjectShared { get; set; }
        public string? ProjectShareOwnerName { get; set; }
        public string? ProjectShareOwnerEmail { get; set; }
        public bool? IsShareApproved { get; set; }
        public bool? IsOwnProject { get; set; }
        public string? LastSyncedDateTime { get; set; }
        public string? LastUpdatedDate { get; set; }
        public bool? Deleted { get; set; }
        public int? SyncClientCreationId { get; set; }
    }
}
