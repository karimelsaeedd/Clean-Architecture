using PostLand.Application.Features.Posts.Queries.GetPostsList;

namespace PostLand.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string content { get; set; }
        public CategoryDto Category { get; set; }
    }
}
