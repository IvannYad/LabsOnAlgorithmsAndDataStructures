using System.ComponentModel.DataAnnotations;

namespace Laba.Models.VM
{
    public class Lab2VM
    {
        [Required]
        public string MatrixString { get; set; }
        [Required]
        public double[][] Matrix;
        public List<SortingAlgorithmStepResultModelLab2> SortingAlgorithmStepsResult { get; set; }
        public int TimeToSortInTicks { get; set; }

        public int SwipesCount { get; set; }
        public int ComparesCount { get; set; }
    }
}
