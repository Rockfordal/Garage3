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
                var v = Vehicle.query();
                return v;
                //Vehicle.query(function(data) {
                //    console.log("data", data);
                //    //return data;
                //    return sampleVehicles;
                //}, function(error) {
                //    console.log("error");
                //    return sampleVehicles;
                //});
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