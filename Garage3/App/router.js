(function () {
    "use strict"

    var sampleVehicles =
    [{  Id: 1, 
        Manufacturer: "Test",
        Model: "Bil",
        RegNr: "BIL001", 
        NumberOfWheels: 4, 
        Color: "Gra", 
        VehicleType: { Id: 1, Type: "Bil" }
    }]

    angular.module("garage").config(function($stateProvider) {

    var vtState = {
        name: 'vehicletypes',
        url: '/vehicletypes',
        component: 'vehicletypeIndex',
        resolve: {
            vehicletypes: function(VehicleType) {
                return VehicleType.query();
            }
        }
    }
    var vehicleState = {
        name: 'fordon',
        url: '/vehicles',
        component: 'vehicleIndex',
        resolve: {
            vehicles: function(Vehicle) {
                return Vehicle.query();
            }
        }
    }
    var peopleState = {
        name: 'personer',
        url: '/people',
        component: 'peopleIndex',
         resolve: {
             people: function(Person) {
                 return Person.query();
             }
         }
    }

    $stateProvider.state(vtState);
    $stateProvider.state(vehicleState);
    $stateProvider.state(peopleState);
    }); 
})();