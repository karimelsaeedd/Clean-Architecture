using AutoMapper;
using MediatR;
using PostLand.Application.Contract;
using PostLand.domain;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(
            IPostRepository postRepository,
            IMapper mapper
            )
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);

            CreateCommendValidator validator = new CreateCommendValidator();
            var result = await validator.ValidateAsync(request);

            if(result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            post = await _postRepository.AddAsync(post);
            return post.Id;

        }
    }
}
