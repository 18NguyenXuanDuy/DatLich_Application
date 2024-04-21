$(document).ready(function () {
    generatePieChart();

    $('#option-pie').change(function () {
        // Update the chart when the dropdown value changes
        generatePieChart();
    });





})

function generatePieChart() {
    var selectedValue = $('#option-pie').val();

    $.ajax({
        url: '/Admin/HomeAdmin/getdataCharBar',
        method: 'POST',
        data: { year: selectedValue },
        success: function (response) {
            if (response.success) {
                var labels = [];
                var data = [];

                var sumCounted = response.datachart.reduce((sum, value) => {
                    return sum + value.Count;
                }, 0);

                response.datachart.sort((a, b) => a.Month - b.Month);


                response.datachart.forEach(value => {
                    labels.push(`Month ${value.Month}`);
                    data.push(value.Count);
                });


                // Set default font styling
                Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
                Chart.defaults.global.defaultFontColor = '#292b2c';

                // Prepare random background colors for the pie chart segments
                var backgroundColors = generateRandomColors(data.length);

                const ctxPie = $('#myPieChart');
                const myPieChart = new Chart(ctxPie, {
                    type: 'pie',
                    data: {
                        labels: labels,
                        datasets: [{
                            data: data,
                            backgroundColor: backgroundColors,
                        }],
                    },
                    options: {
                        tooltips: {
                            callbacks: {
                                label: function (tooltipItem, data) {
                                    let dataset = data.datasets[tooltipItem.datasetIndex];
                                    /*//let total = dataset.data.reduce((previousValue, currentValue) => previousValue + currentValue);*/
                                    let currentValue = dataset.data[tooltipItem.index];
                                    let percentage = Math.floor(((currentValue / sumCounted) * 100) + 0.5);
                                    return percentage + '%';
                                },

                            }
                        },
                        plugins: {
                            datalabels: {
                                formatter: (value, ctx) => {
                                    let dataset = ctx.chart.data.datasets[ctx.datasetIndex];
                                    //let total = dataset.data.reduce((previousValue, currentValue) => previousValue + currentValue);
                                    let percentage = Math.round((value / sumCounted) * 100) + '%';
                                    return percentage;
                                },
                                color: '#fff', // Label color
                                font: {
                                    weight: 'bold' // Label font weight
                                }
                            }
                        }
                    }
                });
                console.log(myPieChart)
            } else {
                console.error('Failed to fetch data.');
            }
        },
        error: function (xhr, status, error) {
            console.error('AJAX request failed:', status, error);
        }
    });
}

// Function to generate random colors for pie chart segments
function generateRandomColors(count) {
    const predefinedColors = [
        '#007bff', '#dc3545', '#ffc107', '#28a745', '#f58231', '#911eb4',
        '#46f0f0', '#f032e6', '#d2f53c', '#fabebe', '#008080', '#e6beff'
    ];

    // If count exceeds predefined colors, cycle through colors
    const colors = [];
    for (let i = 0; i < count; i++) {
        colors.push(predefinedColors[i % predefinedColors.length]);
    }
    return colors;
}
