var app = angular.module('weather-board', ['ui.bootstrap']);

app.controller('weatherController', ['$scope', '$http', function ($scope, $http) {

    console.log("Starting weatherController ...");

    $scope.data = { country: "Australia", city: "Sydney" };

    var url = "http://localhost:17753/api/weather/getweather?country=" + $scope.data.country + "&city=" + $scope.data.city;
    console.log("fetching data from", url);

    $http.get(url)
        .then(function (response) {
            console.log("received data", response);
            $scope.data = response.data;

        }, function (err) {
            console.error(err);
            if (err.statusText)
                alert(err.statusText);
        });

}]);