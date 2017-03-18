var app = angular.module('weather-board', ['ui.bootstrap'   ]);

app.controller('weatherController', ['$scope', '$http', function ($scope, $http) {

    console.log("Starting weatherController ...");

    $scope.country = "Australia";
    $scope.city = "Adelaide Airport";
    $scope.cities = [$scope.city];

    var handleError = function(err) {
        console.error(err);
        if (err.statusText)
            alert(err.statusText);
    }

    $scope.getCities = function() {
        var url = "http://localhost:17753/api/weather/getcities?country=" + $scope.country;
        console.log("fetching cities from", url);

        $http.get(url)
            .then(function (response) {
                console.log("received cities", response);
                if (response.data && response.data.length) {
                        $scope.cities = response.data;
                        $scope.city = $scope.cities[0];
                        $scope.changeCity();
                    }
                },
                function() {  });

    }

    $scope.changeCity = function() {

        if (!$scope.city)
            return;

        var url = "http://localhost:17753/api/weather/getweather?country=" + $scope.country + "&city=" + $scope.city;
        console.log("fetching weather from", url);

        $http.get(url)
            .then(function(response) {
                    console.log("received weather", response);
                    $scope.data = response.data;

                },
                function () { });
    }

    $scope.getCities();
    $scope.changeCity();
}]);