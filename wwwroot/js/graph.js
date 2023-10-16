function add(times, selectionSort, shellSort, quickSort, mergeSort, countSort) {
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