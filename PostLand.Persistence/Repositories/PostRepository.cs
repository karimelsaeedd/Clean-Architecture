using Microsoft.EntityFrameworkCore;
using PostLand.Application.Contract;
using PostLand.domain;

namespace PostLand.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostDbContext postDbContext) : base(postDbContext)
        {
            
        }
        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> AllPosts = new List<Post>();
            AllPosts = includeCategory ? await _dbContext.Posts.Include(p => p.Category).ToListAsync() : await _dbContext.Posts.ToListAsync();

            return AllPosts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            Post post = new Post();

            post = includeCategory ? await _dbContext.Posts.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id) : await GetByIdAsync(id);

            return post;
        }
    }
}
