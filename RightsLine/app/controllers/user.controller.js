//(function () {
//    'use strict';

//    angular.module('rightsline').controller('UserCtrl',
//        ['$scope', '$state', '$timeout', 'rightslineConfig', 'userService',
//            function ($scope, $state, $timeout, rightslineConfig, userService) {
//                $scope.model = {
//                    mode: undefined,
//                    user: {
//                        Name: undefined,
//                        Email: undefined,
//                        Phone: undefined,
//                        BirthDate: undefined,
//                        Gender: undefined,
//                        IsActive: undefined
//                    },
//                };
                

//                function initialize() {
//                    $scope.model.mode = $state.params.action;
//                    if ($state.params.userId) {
//                        userService.getUser($state.params.userId).success(function (user) {
//                            $scope.model.user = user;
//                        });
//                    }
//                }

//                initialize();
//            }
//        ]);
//})();