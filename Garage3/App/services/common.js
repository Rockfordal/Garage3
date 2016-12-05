angular.module("garage.common", [])
    .service("Common",  function() {
        this.AddEntity = AddEntity
    }
);

function AddEntity(newEntity, entities) {
    newEntity.$save(function (data, putResponseHeaders) {
        //console.log('add success: ', data);
        entities.push(newEntity);
    }, function (res) {
        console.log('fel vid skapa. modelState: ', res.data.ModelState);
    });
    return null;
};
