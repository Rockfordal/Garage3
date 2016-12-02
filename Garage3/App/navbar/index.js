(function () {
    "use strict"

    angular.module("garage").component('menuBar', {
        bindings: {
            brand: '<'
        },
        templateUrl: '/App/navbar/index.html',
        controllerAs: "model",
        controller: function() {
            // this.brand = "Garage";
            this.menus = [{
                name: "Fordon",
                state: "fordon"
            }, {
                name: "Personer",
                state: "personer"
            }, {
                name: "FordonsTyper",
                state: "vehicletypes"
            }];
        }
    });

})();