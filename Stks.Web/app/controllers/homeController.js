'use strict';
app.controller('homeController', ['$scope', 'loadService', '$log', '$http', function ($scope, loadService, $log, $http) {

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


    ////////////////////////////////////////////
    $scope.iller = "sa";
    $scope.formdata = {
        sporTuru: ""
    }
    $scope.load = function () {
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

    $scope.result = null;
    
    $scope.ara = function () {
        $scope.formdata.il = 'sakarya';
        $scope.formdata.ilce = 'serdivan';

        if ($scope.formdata.servis == 'farketmez') {
            $scope.formdata.servis = "";
        }
        else if ($scope.formdata.servis == 'var') {
            $scope.formdata.servis = true;
        }
        else if ($scope.formdata.servis == 'yok') {
            $scope.formdata.servis = false;
        }
        console.log($scope.formdata);
        $http.post('http://localhost:26264/api/tesis/search', $scope.formdata).then(function (results) {
            $scope.result = results.data;
            console.info("results", results.data);
        });
    };
    $scope.today = function () {
        $scope.formdata.tarih1 = new Date();
        $scope.formdata.tarih2 = new Date();
    };
    $scope.today();

    $scope.clear = function () {
        $scope.dt = null;
    };

    $scope.inlineOptions = {
        customClass: getDayClass,
        minDate: new Date(),
        showWeeks: true
    };

    $scope.dateOptions = {
        formatYear: 'yy',
        maxDate: new Date(2020, 5, 22),
        minDate: new Date(),
        startingDay: 1
    };

    // Disable weekend selection
    function disabled(data) {
        var date = data.date,
          mode = data.mode;
        return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
    }

    $scope.toggleMin = function () {
        $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
        $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
    };

    $scope.toggleMin();

    $scope.open1 = function () {
        $scope.popup1.opened = true;
    };

    $scope.open2 = function () {
        $scope.popup2.opened = true;
    };

    $scope.setDate = function (year, month, day) {
        $scope.dt = new Date(year, month, day);
    };

    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];
    $scope.altInputFormats = ['M!/d!/yyyy'];

    $scope.popup1 = {
        opened: false
    };

    $scope.popup2 = {
        opened: false
    };

    var tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    var afterTomorrow = new Date();
    afterTomorrow.setDate(tomorrow.getDate() + 1);
    $scope.events = [
      {
          date: tomorrow,
          status: 'full'
      },
      {
          date: afterTomorrow,
          status: 'partially'
      }
    ];

    function getDayClass(data) {
        var date = data.date,
          mode = data.mode;
        if (mode === 'day') {
            var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

            for (var i = 0; i < $scope.events.length; i++) {
                var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                if (dayToCheck === currentDay) {
                    return $scope.events[i].status;
                }
            }
        }

        return '';
    }

    //////////////////////////////

    $scope.hstep = 1;
    $scope.mstep = 30;

    var d = new Date();
    d.setMinutes(0);
    $scope.formdata.saat1 = d;
    $scope.formdata.saat2 = d;
}]);