﻿using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab5
{
    public interface IOrdinarySortingService5 : ISorting<int[], double>, ISwap<int>
    {
        public void PopulateBounds(int lower, int upper, int length);
    }
}
