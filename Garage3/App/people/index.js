(function () {
"use strict"

angular.module("garage").component("peopleIndex", {
    templateUrl: "/App/people/index.html",
    bindings: { people: '<' },
    controllerAs: "model",
    controller: function (Person, Common) {
        var vm = this;
        this.add = function () {
            var newPerson = new Person(vm.person);
            Common.AddEntity(newPerson, vm.people);
        }
        this.remove = function (person, index) {
            Person.delete({ id: person.Id }, function () {
                vm.people.splice(index, 1);
            });
        }
        this.startedit = function (person) {
            vm.editing = true;
            vm.person = person;
        }
        this.update = function () {
            vm.person.$update();
            vm.clear();
        }
        this.clear = function () {
            vm.editing = false;
            vm.person = new Person();
        }
    }
});
})();