var app = angular.module('weather-board', ['ui.bootstrap']);

app.controller('weatherController', ['$scope', '$http', function ($scope, $http) {

    console.log("Starting weatherController ...");

    $scope.country = "Australia";
    $scope.city = "Sydney";

    var url = "http://localhost:17753/api/weather/getweather?country=" + $scope.country + "&city=" + $scope.city;
    console.log("fetching data from", url);

    $scope.changeCity = function() {

        $http.get(url)
            .then(function(response) {
                    console.log("received data", response);
                    $scope.data = response.data;

                },
                function(err) {
                    console.error(err);
                    if (err.statusText)
                        alert(err.statusText);
                });
    }

    $scope.changeCity();
}]);