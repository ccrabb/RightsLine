(function () {
    'use strict';

    angular.module('rightsline').controller('HomeCtrl', ['$scope', '$state', 'rightslineConfig', 'userService',
        function ($scope, $state, rightslineConfig, userService) {
            $scope.model = {
                users: [],
                currentUser: undefined,
                showUserForm: false,
                genders: rightslineConfig.genders
            };

            $scope.deleteUser = function (user) {
                $scope.model.currentUser = undefined;
                userService.deleteUser(user.ID).success(function () {
                    debugger;
                });
            };

            $scope.save = function () {
                var u = $scope.model.currentUser;
                if ($scope.model.currentUser.ID) {
                    userService.updateUser(u.ID, u.Name, u.Email, u.Phone, u.BirthDate, u.Gender, u.IsActive)
                        .success(function (res) {
                            debugger;
                        });
                } else {
                    userService.createUser(u.Name, u.Email, u.Phone, u.BirthDate, u.Gender, u.IsActive)
                        .success(function (user) {
                            $scope.model.users.push(user);
                            debugger;
                        });
                }
            };

            function initialize() {
                userService.getUsers().success(function (data) {
                    $scope.model.users = data;
                });
            }

            initialize();
        }
    ]);
})();