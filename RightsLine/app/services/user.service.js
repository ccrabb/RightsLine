(function () {
    'use strict';

    angular.module('rightsline').factory('userService', ['$http', function ($http) {
        var url = "/api/User/";

        function getUsers() {
            return $http({
                url: url,
                method: 'GET'
            });
        }

        function getUser(id) {
            return $http({
                url: url + id,
                method: 'GET'
            });
        }

        function createUser(name, email, phone, birthDate, gender, isActive) {
            return $http({
                url: url,
                method: 'POST',
                data: {
                    Name: name,
                    Email: email,
                    Phone: phone,
                    BirthDate: birthDate,
                    Gender: gender,
                    IsActive: isActive
                }
            });
        }

        function updateUser(id, name, email, phone, birthDate, gender, isActive) {
            return $http({
                url: url + id,
                method: 'PUT',
                data: {
                    Name: name,
                    Email: email,
                    Phone: phone,
                    BirthDate: birthDate,
                    Gender: gender,
                    IsActive: isActive
                }
            });
        }

        function deleteUser(id) {
            return $http({
                url: url + id,
                method: 'DELETE'
            });
        }

        return {
            getUsers: getUsers,
            getUser: getUser,
            createUser: createUser,
            updateUser: updateUser,
            deleteUser: deleteUser
        };
    }]);
})();