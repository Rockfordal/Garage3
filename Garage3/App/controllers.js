angular.module("garage", ["GarageService"])
    .controller("VehicleTypeCtrl", function ($scope, VehicleType) {
        $scope.vehicletypes = VehicleType.query();
})
    .controller("VehicleCtrl", function ($scope, Vehicle) {
        $scope.toggle = false;

        $scope.$watch('toggle', function () {
            $scope.toggleText = $scope.toggle ? 'Stäng' : 'Skapa nytt fordon';
        })

        $scope.vehicles = Vehicle.query();

        $scope.addRow = function () {
            $scope.vehicles.push({
                'RegNr': $scope.RegNr,
                'Manufacturer': $scope.Manufacturer,
                'Model': $scope.Model,
                'NumberOfWheels': $scope.NumberOfWheels,
                'Color': $scope.Color,
                'VehicleTypeString': $scope.VehicleType
            });
            $scope.RegNr = '';
            $scope.Manufacturer = '';
            $scope.Model = '';
            $scope.NumberOfWheels = '';
            $scope.Color = '';
            $scope.VehicleType = '';
        }

        $scope.removeRow = function (id) {
            var index = -1;
            var vArr = eval($scope.vehicles);
            for (var i = 0; i < vArr.length; i++) {
                if (vArr[i].Id == id) {
                    index = i;
                    break;
                }
            }
            if (index === -1) {
                alert("Something went wrong");
            }
            $scope.vehicles.splice(index, 1);
        };
})
    .controller("PersonCtrl", function ($scope, Person) {
        $scope.people = Person.query();
})
    .controller("OwnerCtrl", function ($scope, Owner) {
        $scope.owners = Owner.query();
})
