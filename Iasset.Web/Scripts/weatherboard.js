var app = angular.module('weather-board', ['ui.bootstrap']);

app.controller('weatherController', ['$scope', '$http', '$log', function ($scope, $http, $log) {

    console.log("Starting weatherController ...");

    $scope.data = { country: "Australia", city: "Sydney" };

    var url = "http://localhost:17753/api/weather/getweather?country=" + $scope.country + "&city=" + $scope.city;
    console.log("fetching data from", url);

    $http.get(url)
        .then(function (response) {
            console.log("received data", response);
            $scope.data = response.data;

        }, function (response) {
            console.error(response);
        });

}]);