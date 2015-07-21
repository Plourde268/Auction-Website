(function () {
    angular.module('Auction', ['ngRoute']).config(Config);

    function Config($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/app/Views/welcome.html',
            controller: 'WelcomeController',
            controllerAs: 'vm'
        })
        .when('/items', {
            templateUrl: '/app/Views/items.html',
            controller: 'ItemsController',
            controllerAs: 'vm'
        })
        .when('/selectedItem', {
            templateUrl: '/app/Views/selectedItem.html',
            controller: 'SelectedItemController',
            controllerAs: 'vm'
        })
        .when('/selectedItemToEdit', {
            templateUrl: '/app/Views/selectedItemToEdit.html',
            controller: 'SelectedItemToEditController',
            controllerAs: 'vm'
        })
        .when('/selectedBidToEdit', {
            templateUrl: '/app/Views/selectedBidToEdit.html',
            controller: 'SelectedBidToEditController',
            controllerAs: 'vm'
        })
        .when('/userItems', {
            templateUrl: '/app/Views/userItems.html',
            controller: 'UserItemsController',
            controllerAs: 'vm'
        })
        .when('/itemsByCat', {
            templateUrl: '/app/Views/itemsByCat.html',
            controller: 'ItemsByCatController',
            controllerAs: 'vm'
        })
        .when('/add', {
            templateUrl: 'app/Views/add.html',
            controller: 'AddItemController',
            controllerAs: 'vm'
        })
        .when('/userCurrBids', {
            templateUrl: 'app/Views/userCurrBids.html',
            controller: 'UserCurrBidsController',
            controllerAs: 'vm'
         })
        .when('/contact', {
            templateUrl: 'app/Views/contact.html',
            controller: 'ContactController',
            controllerAs: 'vm'
        })
        .when('/register', {
            templateUrl: '/app/Views/register.html',
            controller: 'RegisterController',
            controllerAs: 'vm'
        })
        .when('/login', {
            templateUrl: '/app/Views/login.html',
            controller: 'LoginController',
            controllerAs: 'vm'
        })
        .otherwise({
            redirectTo: '/'
        });
    }

})();