using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Laba.DataStructures.Interfaces
{
    public interface ITree
    {
        void Add(double value);
        double[] GetTraversing();
        bool IfExists(double value);
        (double parent, double[]? children) GetParentAndChildren();
        string GetPackedArray();
    }
}
