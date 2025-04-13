namespace API.Business.Features.CQRS.Results.Category
{
    public class GetCategoryQueryResult
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
