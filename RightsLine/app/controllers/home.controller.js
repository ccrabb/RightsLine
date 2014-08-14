(function () {
    'use strict';

    angular.module('rightsline').controller('HomeCtrl', [
        '$scope', '$state', '$timeout',
        'rightslineConfig', 'userService',
        function ($scope, $state, $timeout, rightslineConfig, userService) {
            $scope.model = {
                users: [],
                currentUser: {
                    Name: undefined,
                    Email: undefined,
                    Phone: undefined,
                    BirthDate: undefined,
                    Gender: undefined,
                    IsActive: undefined
                },
                showUserForm: false,
                genders: rightslineConfig.genders,
                modelState: {},
                alerts: []
            };

            $scope.getGenderName = function (id) {
                for (var i = 0; i < rightslineConfig.genders.length; i++) {
                    if (rightslineConfig.genders[i].Id == id) {
                        return rightslineConfig.genders[i].Name;
                    }
                }
            };

            $scope.deleteUser = function (user) {
                $scope.model.currentUser = undefined;
                userService.deleteUser(user.ID)
                    .success(function () {
                        addAlert("Success! User Deleted", 5000);
                        var index = $scope.model.users.indexOf($scope.model.currentUser);
                        $scope.model.users.splice(index, 1);
                    })
                    .error(function (err) {
                        $scope.model.alerts.push({
                            msg: 'Error deleting ' + scope.model.currentUser.Name
                        });
                    });
            };

            $scope.save = function (form) {
                $scope.model.modelState = {};
                var u = $scope.model.currentUser;
                // If ID exists then this is a new user
                if ($scope.model.currentUser.ID) {
                    userService.updateUser(u.ID, u.Name, u.Email, u.Phone, u.BirthDate, u.Gender, u.IsActive)
                        .success(function (res) {
                            form.$setPristine();
                            addAlert("Success! User Updated", 5000);
                            var index = $scope.model.users.indexOf(u);
                            $scope.model.users.splice(index, 1, res);
                        })
                        .error(function (err) {
                            validateModelState(err.ModelState);

                        });
                } else {
                    userService.createUser(u.Name, u.Email, u.Phone, u.BirthDate, u.Gender, u.IsActive)
                        .success(function (user) {
                            form.$setPristine();
                            $scope.model.currentUser.ID = user.ID;
                            $scope.model.users.push(user);
                            addAlert("Success! User Created", 5000);
                        })
                        .error(function (err) {
                            validateModelState(err.ModelState);
                        });
                }
            };

            function initialize() {
                userService.getUsers().success(function (data) {
                    $scope.model.users = data;
                });
            }

            function addAlert(msg, timeout) {
                var alert = { msg: msg };
                $scope.model.alerts.push(alert);
                $timeout(function () {
                    var index = $scope.model.alerts.indexOf(alert);
                    $scope.model.alerts.splice(index, 1);
                }, timeout, true);
            }

            // Well... if client side validation gets bypassed this ends up being neat
            function validateModelState(modelState) {
                if ($scope.model.currentUser) {
                    for (var prop in $scope.model.currentUser) {
                        if (modelState['user.' + prop]) {
                            if (modelState['user.' + prop][0].toLowerCase().indexOf('required') != -1) {
                                $scope.model.modelState[prop] = prop.substr(prop.indexOf('.') + 1, prop.length) + ' is required.';
                            } else if (modelState['user.' + prop][0].toLowerCase().indexOf('invalid') != -1) {
                                $scope.model.modelState[prop] = prop.substr(prop.indexOf('.') + 1, prop.length) + ' is invalid.';
                            } else {
                                $scope.model.modelState[prop] = modelState['user.' + prop];
                            }
                        }
                    }
                }
            }

            initialize();
        }
    ]);
})();