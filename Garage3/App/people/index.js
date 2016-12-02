(function () {
"use strict"

angular.module("garage").component("peopleIndex", {
    templateUrl: "/App/people/index.html",
    controllerAs: "model",
    controller: function() {
        // this.people = Person.query();
        // this.toggle = false;

        // this.$watch('toggle', function () {
        //     this.toggleText = this.toggle ? 'Stäng' : 'Skapa nytt fordon';
        // })

        // this.addRow = function () {
        //     this.vehicles.push({
        //         'RegNr': this.RegNr,
        //         'Manufacturer': this.Manufacturer,
        //         'Model': this.Model,
        //         'NumberOfWheels': this.NumberOfWheels,
        //         'Color': this.Color,
        //         'VehicleTypeString': this.VehicleType
        //     });
        //     this.rensa();
        // }

        // this.removeRow = function (id) {
        //     var index = -1;
        //     var vArr = eval(this.vehicles);
        //     for (var i = 0; i < vArr.length; i++) {
        //         if (vArr[i].Id == id) {
        //             index = i;
        //             break;
        //         }
        //     }
        //     if (index === -1) {
        //         alert("Something went wrong");
        //     }
        //     this.vehicles.splice(index, 1);
        // }

        // this.rensa = function() {
        //     this.RegNr = '';
        //     this.Manufacturer = '';
        //     this.Model = '';
        //     this.NumberOfWheels = '';
        //     this.Color = '';
        //     this.VehicleType = '';
        // }
    }
});
})();