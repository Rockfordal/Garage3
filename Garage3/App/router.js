(function () {
    "use strict"

    var sampleVehicles =
    [{  Id: 1, 
        Manufacturer: "Audi",
        Model: "Quattro",
        RegNr: "AUD001", 
        NumberOfWheels: 4, 
        Color: "Svart", 
        VehicleType: { Id: 1,  Type: "Bil" }
        // VehicleTypeString: "Bil"
    }]

    angular.module("garage").config(function($stateProvider) {

    var vtState = {
        name: 'vehicletypes',
        url: '/vehicletypes',
        template: '<h3>Fordonstyper</h3>'
    }
    var vehicleState = {
        name: 'fordon',
        url: '/vehicles',
        component: 'vehicleIndex',
        resolve: {
            vehicles: function(Vehicle) {
            //return sampleVehicles;
             return Vehicle.query();
            }
        }
    }
    var peopleState = {
        name: 'personer',
        url: '/people',
        component: 'peopleIndex'
        // resolve: {
        //     people: function(People) {
        //     return People.query();
        //     }
        // }
    }

    $stateProvider.state(vtState);
    $stateProvider.state(vehicleState);
    $stateProvider.state(peopleState);
    }); 
})();