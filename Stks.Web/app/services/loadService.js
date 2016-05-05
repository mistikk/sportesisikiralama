'use strict';
app.factory('loadService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var loadServiceFactory = {};

    var _getCities = function () {

        return $http.get(serviceBase + 'api/get/il').then(function (results) {
            return results;
        });
    };

    var _getDistricts = function (ilKodu) {

        return $http.post(serviceBase + 'api/get/getilce?ilId='+ilKodu).then(function (results) {
            return results;
        });
    };

    loadServiceFactory.getCities = _getCities;
    loadServiceFactory.getDistricts = _getDistricts;

    return loadServiceFactory;

}]);