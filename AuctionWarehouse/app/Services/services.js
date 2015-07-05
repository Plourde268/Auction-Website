(function () {
    angular.module('Auction')
        .factory('DbService', DbService)
        .factory('loginService', loginService);

    function DbService($http, $q, $window) {
        var items = [];
        var initialDeferred = $q.defer();
        var token = $window.sessionStorage.getItem('token');
        var service = {};

        preloadItems();

        service.getItems = getItems;
        service.addItem = addItem;

        function preloadItems() {
            $http({
                url: 'api/Auction',
                method: 'GET',
                headers: {'Authorization' : 'Bearer ' + token}
            })
            .success(function (data) {
                console.log(data);

                data.ItemList.forEach(function (item) {
                    items.push(item);
                })
                initialDeferred.resolve(items);
            })
            .error(function () {
                initialDeferred.reject();
            });
        }

        function getItems() {
            return initialDeferred.promise;
        };

        function addItem(item) {
            var deferred = $q.defer();
            $http({
                url: '/api/Auction',
                method: 'POST',
                data: item,
                headers: {'Authorization': 'Bearer ' + token}
            })
            .success(function (data){
                if (data) {
                    items.push(item);
                }
                deferred.resolve();
            })
            .error(function (){
                deferred.reject();
            });
            return deferred.promise;
        }
        return service;
    }

    function loginService($http, $q, $window) {
        var service = {};

        service.login = login;

        function login(username, password) {
            var deferred = $q.defer();

            $http({
                url: '/Token',
                method: 'POST',
                data: 'username=' + username + '&password=' + password + '&grant_type=password',  //Hyper-Insecure
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                $window.sessionStorage.setItem('token', data.access_token);
                deferred.resolve();
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        }
        return service;
    }
})();