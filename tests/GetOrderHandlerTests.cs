namespace tests;

public class GetOrderHandlerTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task GetOrder_When_There_Are_Data_Should_Return_Order(int id)
    {
        // Arrange 
        var orders = new List<Order>
        {
            new Order { Id = 1, CustomerName = "Customer 1", OrderDate = DateTime.Now },
            new Order { Id = 2, CustomerName = "Customer 2", OrderDate = DateTime.Now },
            new Order { Id = 3, CustomerName = "Customer 3", OrderDate = DateTime.Now },
        };

        var order = orders.FirstOrDefault(x => x.Id == id);

        var repoMock = new Mock<IOrderRepository>();
        repoMock.Setup(r => r.GetById(id))!.ReturnsAsync(order);

        var handler = new GetOrderHandler(repoMock.Object);
        var command = new GetOrderQuery(id);

        // Act 
        var sut = await handler.Handle(command, CancellationToken.None);

        // Assert 
        repoMock.Verify(r => r.GetById(id), Times.Once);
        Assert.NotNull(sut);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task GetOrder_When_There_is_No_Data_Should_Return_Null(int id)
    {
        // Arrange 
        var repoMock = new Mock<IOrderRepository>();

        var handler = new GetOrderHandler(repoMock.Object);
        var command = new GetOrderQuery(id);

        // Act 
        var sut = await handler.Handle(command, CancellationToken.None);

        // Assert 
        repoMock.Verify(r => r.GetById(id), Times.Once);
        Assert.Null(sut);
    }
}
