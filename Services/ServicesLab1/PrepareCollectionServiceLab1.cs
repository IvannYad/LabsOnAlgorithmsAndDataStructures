using Laba.Services.Interfaces;

namespace Laba.Services.ServicesLab1
{
    public class PrepareCollectionServiceLab1 : IPrepareCollectionService<string, string[]>
    {
        public string[] GetCollectionFromString(string inputCollection)
        {
            return inputCollection.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
