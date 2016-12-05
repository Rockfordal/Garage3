(function () {
"use strict"

angular.module("garage").component("vehicleIndex", {
    templateUrl: "/App/vehicles/index.html",
    bindings: { vehicles: '<' },
    bindings: { vehicletypes: '<' },
    controllerAs: "model",
    controller: function (Vehicle) {
        this.toggle = true;

        this.toggleText = this.toggle ? 'Skapa' : 'Stäng';
        this.toggle = !this.toggle;
        this.dir = true;

        this.toggleDir = function () {
            this.DirText = this.dir ? 'up' : 'down';
            this.dir = !this.dir;
        }
            
        this.addRow = function () {
            var newVehicle = new Vehicle({
                'RegNr': this.RegNr,
                'Manufacturer': this.Manufacturer,
                'Model': this.Model,
                'NumberOfWheels': this.NumberOfWheels,
                'Color': this.Color,
                'VehicleType': this.VehicleType,
            });
            this.addVehicle(newVehicle);
            this.rensa();
        }

        this.addVehicle = function (newVehicle) {
            console.log(newVehicle);
            newVehicle.$save();
            this.vehicles.push(newVehicle);
        };

        this.remove = function (vehicle, index) {
            var that = this;
            Vehicle.delete({ id: vehicle.Id }, function () {
                that.vehicles.splice(index, 1);
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
})();