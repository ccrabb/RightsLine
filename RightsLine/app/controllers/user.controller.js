(function () {
    'use strict';

    angular.module('rightsline').controller('UserCtrl',
        ['$scope', '$timeout', 'rightslineConfig',
            function ($scope, $timeout, rightslineConfig) {
                $scope.model = {
                    user: {
                        name: undefined,
                        email: undefined,
                        phone: undefined,
                        birthDate: undefined,
                        gender: undefined,
                        isActive: undefined
                    },
                    genders: rightslineConfig.genders
                };
            }
        ]);
})();