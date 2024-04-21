
$(document).ready(function () {
    generatePieBar()

    $('#option-bar').change(function () {
        // Update the chart when the dropdown value changes
        generatePieBar();
    });


});

function generatePieBar() {
    var selectedValue = $('#option-bar').val();
    console.log(selectedValue)
    $.ajax({
        url: '/Admin/HomeAdmin/getdataCharBar',
        method: 'POST',
        data: { year: selectedValue },
        success: function (response) {
            if (response.success) {
                if (response.success) {

                    var array = new Array(12).fill(0);

                    response.datachart.forEach(function (value) {
                        array[value.Month - 1] = value.Count;
                    });

                    barchart_data = array


                    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
                    Chart.defaults.global.defaultFontColor = '#292b2c';

                    var ctx = $('#myBarChart');
                    var myLineChart = new Chart(ctx, {

                        type: 'bar',
                        data: {
                            labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                            datasets: [{
                                label: "Số đặt lịch ",
                                backgroundColor: "rgba(2,117,216,1)",
                                borderColor: "rgba(2,117,216,1)",
                                //data: [4215, 5312, 6251, 7841, 9821, 14984, 4215, 4215, 4215, 4215, 4215, 9821],
                                data: barchart_data,
                            }],
                        },
                        options: {
                            scales: {
                                xAxes: [{
                                    time: {
                                        unit: 'month'
                                    },
                                    gridLines: {
                                        display: false
                                    },
                                    ticks: {
                                        maxTicksLimit: 12
                                    }
                                }],
                                yAxes: [{
                                    ticks: {
                                        min: 0,
                                        max: 15,
                                        maxTicksLimit: 5
                                    },
                                    gridLines: {
                                        display: true
                                    }
                                }],
                            },
                            legend: {
                                display: false
                            }
                        }
                    });

                }
                console.log(response.datachart); // Example: Log the data received
            } else {
                console.error('Failed to fetch data.');
            }
        },
        error: function (xhr, status, error) {
            console.error('AJAX request failed:', status, error);
        }
    });
}