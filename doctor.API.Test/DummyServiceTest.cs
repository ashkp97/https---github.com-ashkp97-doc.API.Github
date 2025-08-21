namespace doctor.API.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        //Anything to run before starting the test - like an initializer
    }

    [Test]
    public void AddSuccessTest()
    {
        //Arrange
        DummyServiceForTest obj = new DummyServiceForTest();
        int a = 1; int b = 2;
        //Act
        var res = obj.Sum(a, b);
        //Assert
        Assert.That(res, Is.EqualTo(3));
    }

    [TearDown]
    public void TearDown()
    {
        //Anything to run after ending the test - like a destructor
    }
}
