using Starbucks.Domain.Entities;

namespace Starbucks.Infrastructure.UnitTests.Fixtures
{
    public class InfrastructureFixture
    {
        public static List<Tax> getTaxItems() => new() {
        new Tax(Guid.Parse("61cd2c6e-9622-434b-a344-544eaeb5775c"), 5,"lima", 18),
         new Tax(Guid.Parse("32eea375-1abf-4f4c-ab36-a17366b86c77"), 44,"Arequipa", 18),
          new Tax(Guid.Parse("57eb4b1f-8fe3-44e2-bed4-5592c383d664"), 15,"Cusco", 18),
        };
    }
}

