(function () {
    'use strict';

angular.module("garage.services", ["ngResource"])
       .factory("VehicleType", function ($resource) {
           return $resource(
               "/api/vehicletypes/:Id",
               { Id: "@Id" },
               { "update": { method: "PUT" } }
          );
       })

       .factory("Vehicle", function ($resource) {
           return $resource(
               "/api/vehicles/:Id",
               { Id: "@Id" },
               { "update": { method: "PUT" } }
          );
       })

       .factory("Person", function ($resource) {
           return $resource(
               "/api/people/:Id",
               { Id: "@Id" },
               { "update": { method: "PUT" } }
          );
       })

       .factory("Owner", function ($resource) {
           return $resource(
               "/api/owners/:Id",
               { Id: "@Id" },
               { "update": { method: "PUT" } }
          );
       });

}());
