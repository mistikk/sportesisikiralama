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
}]);