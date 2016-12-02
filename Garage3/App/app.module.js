(function () {
    'use strict';

    var module = angular.module('garage',
        [ 'ui.router',
          'garage.service'])

    module.controller('MainCtrl', function MainCtrl($scope) {
        $scope.brand = 'Garaget';
        $scope.date = '2016';
    });

})();