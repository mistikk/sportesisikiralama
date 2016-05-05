'use strict';
app.controller('homeController', ['$scope', 'loadService', function ($scope, loadService) {

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

    $('#timepicker1').timepicker({
        minuteStep: 30,
        showMeridian: false
    });
    $('#timepicker2').timepicker({
        minuteStep: 30,
        showMeridian: false
    });

    $(document).ready(function () {
        $('input').iCheck({
            checkboxClass: 'icheckbox_square-aero',
            radioClass: 'iradio_square-aero',
            increaseArea: '20%' // optional
        });
    });

    ////////////////////////////////////////////
    $scope.iller = "sa";
    $scope.load = function () {
        console.log("sa");
        loadService.getCities().then(function (results) {
            $scope.cities = results.data;
        }, function (error) {
            console.log("hataaaaaaa.");
            //alert(error.data.message);
        });
    };

    $scope.getDistrict = function (ilKodu) {
        loadService.getDistricts(ilKodu).then(function (results) {
            $scope.districts = results.data;
        }, function (error) {
            console.log("hataaaaaaa.");
            //alert(error.data.message);
        });
    };
}]);