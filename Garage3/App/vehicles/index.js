(function () {
"use strict"

angular.module("garage").component("vehicleIndex", {
    templateUrl: "/App/vehicles/index.html",
    bindings: { vehicles: '<' },
    controllerAs: "model",
    controller: function (Vehicle) {
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
        if (this.VehicleType && this.VehicleType.value)
        {
            this.VehicleType.value = this.VehicleType.value.split(":")[1];
            alert(this.VehicleType.value);
        }
            
        this.addRow = function () {

            var vehicle = new Vehicle({
                'RegNr': this.RegNr,
                'Manufacturer': this.Manufacturer,
                'Model': this.Model,
                'NumberOfWheels': this.NumberOfWheels,
                'Color': this.Color,
                'VehicleType': {value : this.VehicleType.value, name : this.VehicleType.name}
            });
            //alert(this.getVt(this.VehicleType.name));
            this.vehicles.push(vehicle);
            vehicle.$save();
            this.rensa();
        }

        this.getVt = function(VehicleType)
        {
            if (VehicleType == "Bil")
                return this.vehicletypes[0];
            else if (VehicleType == "Lastbil")
                return this.vehicletypes[1];
            else if (VehicleType == "Båt")
                return this.vehicletypes[2];
            else if (VehicleType == "Motorcykel")
                return this.vehicletypes[3];
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
            this.VehicleType = '';
        }

    }
});
})();