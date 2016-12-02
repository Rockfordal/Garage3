(function () {
"use strict"

angular.module("garage").component("vehicletypeIndex", {
    templateUrl: "/App/vehicletypes/index.html",
    bindings: { vehicletypes: '<' },
    controllerAs: "model",
    controller: function() {
    }
});

})();
