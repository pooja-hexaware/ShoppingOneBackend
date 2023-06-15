using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;
using AutoMapper;
namespace backend.Api.Middleware
{
public class MappingFile : Profile
{
    public MappingFile()
    {
        // Mapping variables
		CreateMap<Receiver , ReceiverDto>(); 
		CreateMap<Sender , SenderDto>(); 
		CreateMap<Message , MessageDto>(); 
		CreateMap<Review , ReviewDto>(); 
		CreateMap<OrderItem , OrderItemDto>(); 
		CreateMap<Order , OrderDto>(); 
		CreateMap<Product , ProductDto>(); 
		CreateMap<Category , CategoryDto>(); 
		CreateMap<Comment , CommentDto>(); 
		CreateMap<Post , PostDto>(); 
		CreateMap<User , UserDto>(); 
    }
  }
}
