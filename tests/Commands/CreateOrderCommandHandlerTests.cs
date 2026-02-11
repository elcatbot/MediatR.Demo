namespace tests;

public class CreateOrderCommandHandlerTests
{
    [Fact]
    public async Task CreateItemCommand_Should_Add_Item()
    {
        // Arrange 
        var repoMock = new Mock<IOrderRepository>();
        var handler = new CreateOrderCommandHandler(repoMock.Object);
        var command = new CreateOrderCommand("Test", DateTime.Now );

        // Act 
        await handler.Handle(command, CancellationToken.None);
        
        // Assert 
        repoMock.Verify(r => r.Create(It.Is<Order>(i => i.CustomerName == "Test")), Times.Once);
    }
}
