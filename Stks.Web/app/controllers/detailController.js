'use strict';
app.controller('detailController', ['$scope', function ($scope) {
    $scope.class = "btn-success";
    $scope.text = "Rezervasyon";
    $scope.tick = false;
    $scope.rezervasyon = function () {
        $scope.class = "btn-danger";
        $scope.text = '';
        $scope.tick = true;
    };

}]);