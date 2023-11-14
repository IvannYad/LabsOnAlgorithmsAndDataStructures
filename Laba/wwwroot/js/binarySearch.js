function DrawGistogram(labels, colors, data) {
    return new Chart(elements, {
        type: "bar",
        data: {
            labels: labels,
            datasets: [{
                backgroundColor: colors,
                data: data
            }]
        },
        options: {
            legend: { display: false },
            title: {
                display: false,
                text: ""
            }
        }
    });
}
