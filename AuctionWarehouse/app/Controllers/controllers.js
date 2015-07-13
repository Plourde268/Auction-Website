(function () {
    angular.module('Auction')
    .controller('WelcomeController', Welcome)
    .controller('ItemsController', Items)
    .controller('SelectedItemController', SelectedItem)
    .controller('CategoriesController', Categories)
    .controller('ItemsByCatController', ItemsByCat)
    .controller('AddItemController', Add)
    .controller('UserCurrBidsController', UserCurrBids)
    .controller('ContactController', Contact)
    .controller('RegisterController', Register)
    .controller('LoginController', Login);

    function Welcome() {
        var vm = this;

        vm.message = '10-4 good buddy';
    }
    function Items(DbService, $location) {
        var vm = this;

        vm.message = 'List of all of the items in the virtual Warehouse';

        DbService.getItems().then(function (items) {
            vm.auctionItems = items;
        })

        vm.grabbedItem = function (index) {
            console.log(index);
            DbService.storeIndex(index);
            $location.path('/selectedItem');
        }
    }
    function SelectedItem(DbService) {
        var vm = this;

        vm.message = 'User selected item';

        vm.item = DbService.getItem();
    }

    function Categories() {
        var vm = this;

        vm.message = 'List of all Categories, when category is selected user will be redirected to a display of items in that category';
    }
    function ItemsByCat() {
        var vm = this;

        vm.message = 'Category Name';
    }
    function Add(DbService, $location) {
        var vm = this;

        vm.isLoading = false;

        vm.message = 'Allows a seller to post an item';

        vm.addItems = function () {
            vm.isLoading = true;

            var item = {
                Name: vm.name,
                Description: vm.description,
                Category: { CatName: vm.category },
                ImageUrl: vm.imageUrl,
                MinPrice: vm.minPrice
            };

            DbService.addItem(item).then(redirectToAllItems, displayError)
        };
        function redirectToAllItems() {
            vm.isLoading = false;
            $location.path('/items');
        }
        function displayError() {
            vm.isLoading = false;
        }
    }
    function UserCurrBids() {
        var vm = this;

        vm.message = 'Displays all bids made by user';
    }
    function Contact() {
        var vm = this;

        vm.message = 'Allows users to share any concerns/comments';
    }
    function Register() {
        var vm = this;

        vm.message = 'Register as a buyer or a seller';
    }
    function Login(loginService, $location) {
        var vm = this;

        vm.message = 'Allows retrning users to sign in';

        vm.login = function () {
            loginService.login(vm.username, vm.password).then(loginSuccess, loginFail);
        }
        function loginSuccess() {
            $location.path("/items");
        }
        function loginFail() {
            console.log("login doesnt work");
        }
    }
})();