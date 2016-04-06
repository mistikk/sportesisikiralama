'use strict';
app.controller('homeController', ['$scope', function ($scope) {

    $scope.today = "06/04/2016";

    $('.input-daterange input').each(function () {
        $(this).datepicker({
            format: "dd/mm/yyyy",
            todayBtn: "linked",
            language: "tr",
            todayHighlight: true,
            autoclose: true,
            startDate: $scope.today
        });
    });

   
}]);