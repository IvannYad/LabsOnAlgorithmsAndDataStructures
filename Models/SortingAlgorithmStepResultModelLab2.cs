using System.ComponentModel.DataAnnotations;

namespace Laba.Models
{
    public class SortingAlgorithmStepResultModelLab2
    {
        [Required]
        public double[][] MatrixBefore { get; set; }
        public double[][] MatrixAfter { get; set; }
        public double[] SumsBefore { get; set; }
        public double[] SumsAfter { get; set; }
        public int[] SwappableIndexes { get; set; }
        public int Step { get; set; }
        public int Iteration { get; set; }
        public int Index1ToSwap { get; set; }
        public int Index2ToSwap { get; set; }
    }
}
