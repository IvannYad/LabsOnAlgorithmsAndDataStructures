using Laba.Services.Interfaces;

namespace Laba.Services
{
    public class PrepareCollectionServiceLab2 : IPrepareCollectionService<string[], double[][]>
    {
        public double[][] GetCollectionFromString(string[] inputCollection)
        {
            double[][] toReturn = new double[inputCollection.Length][];
            for (int i = 0; i < inputCollection.Length; i++)
            {
                toReturn[i] = inputCollection[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => double.Parse(s)).ToArray();
            }

            return toReturn;
        }
    }
}
