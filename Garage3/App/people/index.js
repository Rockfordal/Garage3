(function () {
"use strict"

angular.module("garage").component("peopleIndex", {
    templateUrl: "/App/people/index.html",
    bindings: { people: '<' },
    controllerAs: "model",
    controller: function() {


    }
});
})();