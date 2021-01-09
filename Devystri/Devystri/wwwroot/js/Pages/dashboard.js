var ctx = document.getElementById('visit-website-graphic').getContext('2d');

var myLineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Decembre'],
        datasets: [{
            label: 'Visites sur le site web',
            backgroundColor: 'transparent',
            borderColor: '#7CADD8',
            data: [0, 10, 5, 2, 20, 30, 45, 200, 248 , 150 ,10 ,350],
    }]
    },
    options: {}
});

var ctx = document.getElementById('popular-os-graphic').getContext('2d');

var myPieChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: [
            'MacOS',
            'Windows',
            'IOS',
            'Android'
        ],
        datasets: [{
            data: [300, 50, 100, 200],
            backgroundColor: [
                '#E17CFD',
                '#4CD7F6',
                '#6DBFFF',
                '#7166F9'
            ],
        }]
    },

    options: {}
});

var ctx = document.getElementById('newsletter-users-graphic').getContext('2d');

var myLineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Decembre'],
        datasets: [{
            label: 'Inscrit à la newsletter',
            backgroundColor: 'transparent',
            borderColor: 'rgb(255, 190, 87)',
            data: [420000, 421243, 421863, 423594, 424856, 425123, 425486, 425542, 425795, 425142, 425764, 425053],
        }]
    },
    options: {}
});

