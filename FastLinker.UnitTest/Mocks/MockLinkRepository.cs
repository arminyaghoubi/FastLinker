using FastLinker.Application.Contracts.Persistence;
using FastLinker.Domain;
using Moq;

namespace FastLinker.UnitTest.Mocks;

internal class MockLinkRepository
{
    public static Mock<ILinkRepository> GetLinkRepository()
    {
        List<Link> links = new List<Link>
        {
            new Link
            {
                Id=1,
                Url="https://www.varzesh3.com/",
                IsActive=true,
                CreationDateTime=DateTime.Now
            }
        };

        Mock<ILinkRepository> mock = new Mock<ILinkRepository>();

        return mock;
    }
}
