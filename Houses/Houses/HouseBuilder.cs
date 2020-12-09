using System.Collections.Generic;

namespace Houses
{
    public interface IHouseBuilder
    {
        public (int crossroadNumber, List<List<int>> ways) SuitableCrossroad();
    }
}