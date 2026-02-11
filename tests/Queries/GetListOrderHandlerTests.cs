namespace tests;

public class GetListOrderHandlerTests
{
    [Fact]
    public async Task GetListOrder_Should_Return_List()
    {
        // Arrange 
        var orders = new List<Order>
        {
            new Order { Id = 1, CustomerName = "Customer 1", OrderDate = DateTime.Now },
            new Order { Id = 2, CustomerName = "Customer 2", OrderDate = DateTime.Now },
            new Order { Id = 3, CustomerName = "Customer 3", OrderDate = DateTime.Now },
        };

        var repoMock = new Mock<IOrderRepository>();
        repoMock.Setup(r => r.GetList()).ReturnsAsync(orders);

        var handler = new GetListOrderHandler(repoMock.Object);
        var command = new GetListOrderQuery();

        // Act 
        var sut = await handler.Handle(command, CancellationToken.None);
        
        // Assert 
        repoMock.Verify(r => r.GetList(), Times.Once);
        Assert.Equal(orders, sut);
    }

    [Fact]
    public async Task GetListOrder_When_There_is_No_Data_Should_Return_Null()
    {
        // Arrange 
        var repoMock = new Mock<IOrderRepository>();

        var handler = new GetListOrderHandler(repoMock.Object);
        var command = new GetListOrderQuery();

        // Act 
        var sut = await handler.Handle(command, CancellationToken.None);
        
        // Assert 
        repoMock.Verify(r => r.GetList(), Times.Once);
        Assert.Null(sut);
    }
}
