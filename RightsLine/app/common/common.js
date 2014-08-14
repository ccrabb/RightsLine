(function () {
    'use strict';

    // Time permitting I would actually use a t4 template to generate any and all enumerations to be used on the client
    angular.module('rightsline').value('rightslineConfig', {
        genders: [
            { Name: "Male", Id: 0 },
            { Name: "Female", Id: 1 }
        ]
    });
})();