﻿using System.ComponentModel.DataAnnotations;

namespace Laba.Models
{
    public class Lab2VM
    {
        [Required]
        public string MatrixString { get; set; }
        [Required]
        public double[][] MatrixBefore;
        public List<SortingAlgorithmStepResultModelLab2> SortingAlgorithmStepsResult { get; set; }
        public int TimeToSortInMiliseconds { get; set; }

        public int SwipesCount { get; set; }
        public int ComparesCount { get; set; }
    }
}
