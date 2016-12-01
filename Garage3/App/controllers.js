angular.module("garage", ["GarageService"])
    .controller("VehicleTypeCtrl", function ($scope, VehicleType) {
        $scope.vehicletypes = VehicleType.query();
})
    .controller("VehicleCtrl", function ($scope, Vehicle) {
        $scope.vehicles = Vehicle.query();
})
    .controller("PersonCtrl", function ($scope, Person) {
        $scope.people = Person.query();
})
    .controller("OwnerCtrl", function ($scope, Owner) {
        $scope.owners = Owner.query();
})
