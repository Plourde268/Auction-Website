(function () {
    angular.module('Auction')
        .factory('DbService', DbService);

    function DbService($http, $q) {
        var items = [];
        var initialDeferred = $q.defer();
        var service = {};

        preloadItems();

        service.getItems = getItems;
        service.addItem = addItem;

        function preloadItems() {
            $http({
                url: 'api/Auction',
                method: 'GET'
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
                data: item
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

    
})();