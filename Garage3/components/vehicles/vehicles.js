(function () {
    'use strict';

    angular.module('garage.vehicles', [])
	.controller('VehiclesController', function ($scope, Vehicle) {
        $scope.vehicles = Vehicle.query();
	})

}());

//angular.module('garage').controller("VehicleCtrl", function ($scope, Vehicle) {
//    $scope.vehicles = Vehicle.query();
