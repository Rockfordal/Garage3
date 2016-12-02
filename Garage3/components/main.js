(function () {
    'use strict';

    angular.module('garage', ['ui.router',
                              //'garage.vehicles',
                              //'garage.services',
                              //'ngResource'
    ])

    .component('vehicles', {
        bindings: { vehicles: '<' },

        template: '<h1>hohoh</h1>',
        //template: '<h3>{{$ctrl.vehicles}} Solar System!</h3>' +
        //          '<button ng-click="$ctrl.toggleGreeting()">toggle greeting</button>',

        controller: function () {
            //this.greeting = 'hello';

            //this.toggleGreeting = function () {
            //    this.greeting = (this.greeting == 'hello') ? 'whats up' : 'hello'
            //}
        }
    })

    .config(function ($stateProvider) {
        var vehiclesState = {
            name: 'vehicles',
            url: '/vehicles',
            component: 'vehicles'
            //template: '<h3>Frodon!</h3>'
        };

        var peopleState = {
            name: 'people',
            url: '/people',
            template: '<h3>People</h3>'
        };

        $stateProvider.state(vehiclesState);
        $stateProvider.state(peopleState);
    });

})();