(function () {
    angular.module('Auction')
        .factory('DbService', DbService)
        .factory('loginService', loginService);
    function DbService($http, $q, $window) {
        var token = $window.sessionStorage.getItem('token');
        var service = {};
        var initialDeferred = $q.defer();
        var segundoDeferred = $q.defer();
        var items = [];
        var userItems = [];
        var bids = [];
        var userBids = [];
        var index = {};
        var itemIndex = {};
        var itemUserIndex = {};
        var bid = {};


        preloadItems();
        //preloadBids();

        service.getItems = getItems;
        service.getBids = getBids;
        service.addItem = addItem;
        service.getItem = getItem;
        service.storeIndex = storeIndex;
        service.placeBid = placeBid;
        service.getUserItems = getUserItems;
        service.storeUserIndex = storeUserIndex;
        service.getUserItem = getUserItem;
        service.replaceItem = replaceItem;
        service.getUserBids = getUserBids;
        service.storeUserBidIndex = storeUserBidIndex;
        service.replaceBid = replaceBid;
        service.deleteUserBid = deleteUserBid;
        service.deleteUserItem = deleteUserItem;

        function preloadItems() {
            $http({
                url: 'api/Auction/Get',
                method: 'GET',
                headers: { 'Authorization': 'Bearer ' + token }
            }).success(function (data) {
                console.log(data);
                data.ItemList.forEach(function (item) {
                    items.push(item);
                })
                initialDeferred.resolve(items);
            }).error(function () {
                initialDeferred.reject();
            });
        };
        function getItems() {
            return initialDeferred.promise;
        };

        function getBids($rootScope) {
            var deferred = $q.defer();
            $http({
                url: 'api/Auction/FetchBids',
                method: 'GET',
                headers: {'Authorization': 'Bearer ' + token}
            }).success(function (data) {
                console.log(data, "service data ajax call");
                data.BidsList.forEach(function (bid) {
                    console.log(bid, "after the first loop:getBids");
                    bids.push(bid);
                    console.log(bids, "array after the push");
                })
                deferred.resolve(bids);
            }).error(function (){
                deferred.reject();
            })
            return deferred.promise;
        };

        function getUserItems() {
            var deferred = $q.defer();
            $http({
                url: 'api/Auction/GetUserItems',
                method: 'GET',
                headers: {'Authorization': 'Bearer ' + token}
            }).success(function (data) {
                console.log(data, 'getUserItems, service, retreival');
                data.UserItemsList.forEach(function (item) {
                    console.log(item, "getUserItems, after first loop");
                    userItems.push(item);
                })
                deferred.resolve(userItems);
            }).error(function () {
                deferred.promise;
            })
            return deferred.promise;
        }
        function storeIndex(index) {
            itemIndex = index;
        };
        function storeUserIndex(index) {
            itemUserIndex = index;
        };
        function storeUserBidIndex(index){
            bidUserIndex = index;
        }
        function getItem() {
            console.log(itemIndex)
            return items[itemIndex];
        };
        function getUserItem() {
            console.log(userItems)
            console.log(itemUserIndex)
            console.log(userItems[itemUserIndex]);
            return userItems[itemUserIndex];
        };
        function getUserBids() {
            console.log(bids[bidUserIndex])
            return bids[bidUserIndex];
        }
        
        function addItem(item) {
            var deferred = $q.defer();
            $http({
                url: 'api/Auction/Post',
                method: 'POST',
                data: item,
                headers: { 'Authorization': 'Bearer ' + token}
            }).success(function (data) {
                if (data) {
                    items.push(item);
                }
                deferred.resolve();
                console.log(token, "this is the token");
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        function replaceItem(editedItem) {
            var deferred = $q.defer();
            $http({
                url: 'api/Auction/PutItem',
                method: 'PUT',
                data: editedItem,
                headers: { 'Authorization': 'Bearer ' + token }
            }).success(function (data) {
                if (data) {
                    deferred.resolve();
                }
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        }
        function replaceBid(editBid) {
            var deferred = $q.defer();
            $http({
                url: 'api/Auction/PutBid',
                method: 'PUT',
                data: editBid,
                headers: { 'Authorization': 'Bearer ' + token }
            }).success(function (data) {
                if (data) {
                    deferred.resolve();
                }
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        }
        function deleteUserBid(bid) {
            var deferred = $q.defer();
            $http({
                url: 'api/Auction/DeleteBid',
                method: 'Patch',
                data: bid,
                headers: { 'Authorization': 'Bearer ' + token }
            }).success(function (data) {
                if (data) {
                    deferred.resolve();
                }
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        }
        function deleteUserItem(item) {
            var deferred = $q.defer();
            $http({
                url: 'api/Auction/DeleteItem',
                method: 'Patch',
                data: item,
                headers: { 'Authorization': 'Bearer ' + token }
            }).success(function (data) {
                if (data) {
                    deferred.resolve();
                }
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        }
        function placeBid(bid) {
            var deferred = $q.defer();
            $http({
                url: 'api/Auction/PostBid',
                method: 'POST',
                data: bid,
                headers: { 'Authorization': 'Bearer ' + token }
            }).success(function (data) {
                if (data) {
                    bids.push(bid);
                };
                deferred.resolve();
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        }
        return service;
    };
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
                console.log("success hit");
                console.log(username);
                deferred.resolve();
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        }
        return service;
    }
})();