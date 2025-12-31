let warningShown = false;
let storeId = "";
let lang = "";

document.addEventListener('DOMContentLoaded', () => RenderPage(), false);

async function RenderPage() {
    storeId = localStorage.getItem("StoreId");
    lang = localStorage.getItem("Lang")
    await CheckMode();

    document.getElementById("mainPage").innerHTML = Translation("MainPage", lang);
    document.getElementById("cityLabel").innerHTML = Translation("City", lang);
    document.getElementById("addressLabel").innerHTML = Translation("Address", lang);
    document.getElementById("supervisorLabel").innerHTML = Translation("Supervisor", lang);
    document.getElementById("phoneLabel").innerHTML = Translation("Phone", lang);
    document.getElementById("emailLabel").innerHTML = Translation("Email", lang);
    document.getElementById("modifyStoreInfo").innerHTML = Translation("ModifyStoreInfo", lang);
    document.getElementById("deleteStore").innerHTML = Translation("DeleteStore", lang);
    document.getElementById("viewProductsButton").innerHTML = Translation("ViewProductsButton", lang);

    await GetStoreInfo(storeId);
    let storeData = JSON.parse(localStorage.getItem("StoreAndProducts"));
    let productNames = [];
    let productCount = [];

    let products = Array.from(storeData['products']);

    for (const product of products) {
        productNames.push(product["name"]);
        productCount.push(product["inStock"]);
    }

    ProductChart(productNames, productCount, Translation("ProductChart", lang));
}

async function GetStoreInfo(storeId) {
    const url = "https://localhost:7233/GetStoreDataWithId?id=" + storeId;

    await fetch(url)
        .then(data => {
            if (!data.ok) {
                document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
                throw new Error("Promise chain cancelled");
            }
            return data.json();
        })
        .then(data => {
            if (!data) {
                document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
                throw new Error("Promise chain cancelled");
            }
            else {
                document.getElementById('Name').innerHTML = data["name"];
                document.getElementById('City').innerHTML = data["city"];
                document.getElementById('Address').innerHTML = data["address"];
                document.getElementById('Supervisor').innerHTML = data["supervisor"];
                document.getElementById('Phone').innerHTML = data["phone"];
                document.getElementById('Email').innerHTML = data["email"];
                localStorage.setItem("StoreAndProducts", JSON.stringify(data));
            }
        })
        .catch((error) => {
            console.error(error)
        });
}

function ShowWarning() {
    if (!warningShown) {
        document.getElementById("WarningText").innerHTML = Translation("DeleteWarningText", lang);

        var delCol = document.getElementById("DeleteCol");
        var delButton = document.createElement('input');
        delButton.type = "button";
        delButton.className = "btn btn-danger";
        delButton.value = Translation("IAmSure", lang);
        delButton.onclick = () => { DeleteStore(storeId) };
        delCol.appendChild(delButton);

        warningShown = true;
    }
}

function DeleteStore(storeId) {
    const url = "https://localhost:7233/DeleteStore?id=" + storeId;

    fetch(url, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: storeId
    }).then(response => {
        if (response.ok) {
            Redirect("Index.html");
        }
        else {
            document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
        }
    });
}

let chart1 = null;
function ProductChart(productNames, productCount, title) {
    // Colors for the chart.
    var colors = [];
    while (colors.length < productNames.length) {
        do {
            var color = Math.floor((Math.random() * 1000000) + 1);
        } while (colors.indexOf(color) >= 0);
        colors.push("#" + ("000000" + color.toString(16)).slice(-6));
    }

    // Chart
    let myChart1 = document.getElementById('myChart1').getContext('2d');

    Chart.defaults.global.defaultFontFamily = 'Arial';
    Chart.defaults.global.defaultFontSize = 12;
    Chart.defaults.global.defaultFontColor = 'green';

    chart1 = new Chart(myChart1, {
        type: 'pie',
        data: {
            labels: productNames,
            datasets: [{
                label: 'Tiedot',
                data: productCount,
                backgroundColor: colors,
                borderWidth: 2,
                borderColor: 'white',
                hoverBorderWidth: 3,
                hoverBorderColor: 'black'
            }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: title,
                fontSize: 25
            },
            legend: {
                display: true,
                position: 'top',
                labels: {
                    fontColor: '#808080'
                }
            },
            layout: {
                padding: {
                    left: 0,
                    right: 0,
                    bottom: 0,
                    top: 0
                }
            },
            tooltips: {
                callbacks: {
                    label: function (tooltipItem, data) {
                        var allData = data.datasets[tooltipItem.datasetIndex].data;
                        var tooltipLabel = data.labels[tooltipItem.index];
                        var tooltipData = allData[tooltipItem.index];
                        var total = 0;
                        for (var i in allData) {
                            total += allData[i];
                        }
                        var tooltipPercentage = Math.round((tooltipData / total) * 100);
                        return tooltipLabel + ': ' + tooltipData + ' (' + tooltipPercentage + '%)';
                    }
                }
            }
        }
    })
}