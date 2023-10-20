function simulateGraph(times, selectionSort, shellSort, quickSort, mergeSort, countSort) {
    return new Chart("myChart", {
        type: "line",
        data: {
            labels: times,
            datasets: [{
                data: selectionSort,
                borderColor: "red",
                fill: false
            },
            {
                data: shellSort,
                borderColor: "yellow",
                fill: false
            },
            {
                data: quickSort,
                borderColor: "green",
                fill: false
            },
            {
                data: mergeSort,
                borderColor: "orange",
                fill: false
            },
            {
                data: countSort,
                borderColor: "purple",
                fill: false
            }]
        },
        options: {
            legend: { display: false }
        }
    });
}

function simulateDiagram(index, selectionSort, shellSort, quickSort, mergeSort, countSort, numElements, chartName) {
    return new Chart(chartName, {
        type: "bar",
        data: {
            labels: ["SelectionSort", "ShellSort", "QuickSort", "MergeSort", "CountSort"],
            datasets: [{
                backgroundColor: ["red", "yellow", "green", "orange", "purple"],
                data: [selectionSort[index], shellSort[index], quickSort[index], mergeSort[index], countSort[index]]
            }]
        },
        options: {
            legend: { display: false },
            title: {
                display: true,
                text: "Sorting time for " + numElements
            }
        }
    });
}