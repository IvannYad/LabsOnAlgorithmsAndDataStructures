function add(arr) {
    return new Chart("myChart", {
        type: "line",
        data: {
            labels: arr,
            datasets: [{
                data: arr,
                borderColor: "red",
                fill: false
            }, {
                data: [1600, 1700, 1700, 1900, 2000, 2700, 4000, 5000, 6000, 7000],
                borderColor: "green",
                fill: false
            }, {
                data: [300, 700, 2000, 5000, 6000, 4000, 2000, 1000, 200, 100],
                borderColor: "blue",
                fill: false
            }]
        },
        options: {
            legend: { display: false }
        }
    });
}