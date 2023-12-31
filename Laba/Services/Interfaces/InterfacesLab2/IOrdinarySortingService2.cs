﻿using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab2
{
    public interface IOrdinarySortingService2: ISorting<int[], double>, ISwap<int>
    {
        public void PopulateBounds(int lower, int upper, int length);
    }
}
