(function () {
    'use strict';

    var module = angular.module('garage',
        [ 'ui.router',
          'ngAnimate',
          'garage.data',
          'garage.common'
        ])

    module.controller('MainCtrl', function MainCtrl($scope) {
        $scope.brand = 'Garaget';
        $scope.date = '2016';
    });

})();