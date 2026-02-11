namespace tests;

public class UpdateOrderCommandHandlerTests
{
    [Fact]
    public async Task UpdateItemCommand_Should_Update_Item()
    {
        // Arrange 
        var order = new Order { Id = 1, CustomerName = "Test", OrderDate = DateTime.UtcNow };
        var repoMock = new Mock<IOrderRepository>();
        repoMock.Setup(r => r.GetById(1))
            .ReturnsAsync(order);

        var handler = new UpdateOrderCommandHandler(repoMock.Object);
        var command = new UpdateOrderCommand(1, "Other test", DateTime.Now);

        // Act 
        await handler.Handle(command, CancellationToken.None);

        // Assert 
        repoMock.Verify(r => r.Update(It.Is<Order>(i => i.Id == 1 && i.CustomerName == "Other test")), Times.Once);
    }

    [Fact]
    public async Task UpdateItemCommand_Should_Not_Update_If_Id_Does_Not_Exist()
    {
        // Arrange 
        var order = new Order { Id = 1, CustomerName = "Test", OrderDate = DateTime.UtcNow };
        var repoMock = new Mock<IOrderRepository>();

        var handler = new UpdateOrderCommandHandler(repoMock.Object);
        var command = new UpdateOrderCommand(1, "Other test", DateTime.Now);

        // Act 
        await handler.Handle(command, CancellationToken.None);

        // Assert 
        repoMock.Verify(r => r.Update(It.Is<Order>(i => i.Id == 1 && i.CustomerName == "Other test")), Times.Never);
    }
}
