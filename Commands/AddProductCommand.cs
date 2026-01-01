using MediatR;

namespace CqrsMediatR.Commands
{ 
    // we are using a domain product entity as the retur type for the query and as a parameter for the command
    // in real world apps we would use DTOs to hide a domain entity from the piblic API    
    //public record AddProductCommand(Product Product) : IRequest;
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
