(function () {
"use strict"

angular.module("garage").component("vehicleIndex", {
    templateUrl: "/App/vehicles/index.html",
    bindings: {
        vehicles: '<',
        vehicletypes: '<'
    },
    controllerAs: "model",
    controller: function (Vehicle, Common) {
        var vm = this;
        this.toggle = true;

        this.toggleText = this.toggle ? 'Skapa' : 'Stäng';
        this.toggle = !this.toggle;
        this.dir = true;

        this.toggleDir = function () {
            this.DirText = this.dir ? 'up' : 'down';
            this.dir = !this.dir;
        }
            
        this.add = function () {
            var newVehicle = new Vehicle({
                'RegNr': this.RegNr.toUpperCase(),
                'Manufacturer': capitalizeFirstLetter(this.Manufacturer),
                'Model': capitalizeFirstLetter(this.Model),
                'NumberOfWheels': this.NumberOfWheels,
                'Color': capitalize(this.Color),
                'VehicleType': this.VehicleType
            });
            Common.AddEntity(newVehicle, this.vehicles);
            angular.element('#addForm').modal('hide');
            this.rensa();
        }

        this.remove = function (vehicle, index) {
            Vehicle.delete({ id: vehicle.Id }, function () {
                vm.vehicles.splice(index, 1);
            });
        }

        this.rensa = function() {
            this.RegNr = '';
            this.Manufacturer = '';
            this.Model = '';
            this.NumberOfWheels = '';
            this.Color = '';
        }

    }
});

function capitalize(str) {

    return str.charAt(0).toUpperCase() + str.slice(1).toLowerCase();
}

function capitalizeFirstLetter(str) {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

//function capitalize(str) {
//    return str.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
//}

})();