(function () {
"use strict"

angular.module("garage").component("vehicleIndex", {
    templateUrl: "/App/vehicles/index.html",
    bindings: { vehicles: '<' },
    controllerAs: "model",
    controller: function(Vehicle) {
        this.toggle = true;

        this.toggleit = function() {
            this.toggleText = this.toggle ? 'Skapa' : 'Stäng';
            this.toggle = !this.toggle;
        }
        this.toggleit();

        this.vehicletypes = [
                { value: '1', name: 'Bil' }, 
                { value: '2', name: 'Lastbil' },
                { value: '3', name: 'Båt' },
                { value: '4', name: 'Motorcykel' }
        ];
        this.VehicleType = this.vehicletypes[0];
        // this.VehicleType = 1;

        this.addRow = function () {
            this.vehicles.push({
                'RegNr':             this.RegNr,
                'Manufacturer':      this.Manufacturer,
                'Model':             this.Model,
                'NumberOfWheels':    this.NumberOfWheels,
                'Color':             this.Color,
                'VehicleTypeString': this.VehicleType
            });
            this.rensa();
        }

        this.removeRow = function (id) {
            var index = -1;
            var vArr = eval(this.vehicles);
            for (var i = 0; i < vArr.length; i++) {
                if (vArr[i].Id == id) {
                    index = i;
                    break;
                }
            }
            if (index === -1) {
                alert("Something went wrong");
            }
            this.vehicles.splice(index, 1);
        }

        this.rensa = function() {
            this.RegNr = '';
            this.Manufacturer = '';
            this.Model = '';
            this.NumberOfWheels = '';
            this.Color = '';
            // this.VehicleType = '';
        }

    }
});
})();