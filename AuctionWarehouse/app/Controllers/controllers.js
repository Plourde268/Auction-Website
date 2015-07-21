(function () {
    angular.module('Auction')
    .controller('WelcomeController', Welcome)
    .controller('ItemsController', Items)
    .controller('SelectedItemController', SelectedItem)
    .controller('UserItemsController', UserItems)
    .controller('ItemsByCatController', ItemsByCat)
    .controller('AddItemController', Add)
    .controller('UserCurrBidsController', UserCurrBids)
    .controller('SelectedItemToEditController', SelectedItemToEdit)
    .controller('SelectedBidToEditController', SelectedBidToEdit)
    .controller('ContactController', Contact)
    .controller('RegisterController', Register)
    .controller('LoginController', Login);

    function Welcome() {
        var vm = this;
        vm.message = '10-4 good buddy';
    }
    function Items(DbService, $location, $rootScope) {
        var vm = this;

        vm.message = 'List of all of the items in the virtual Warehouse';
        DbService.getItems().then(function (items) {
            console.log(items, "items inner loop")
            vm.auctionItems = items;
        })
        vm.grabbedItem = function (index) {
            $rootScope.index = index;
            console.log(index);
            DbService.storeIndex(index);
            $location.path('/selectedItem');
        }
    }
    function UserCurrBids(DbService, $location) {
        var vm = this;
        vm.message = 'Displays all bids made by user';
        DbService.getBids().then(function (bids) {
            console.log(bids);
            vm.userBids = bids;
        })
        vm.grabUserBid = function (index) {
            console.log(index);
            DbService.storeUserBidIndex(index);
            $location.path('/selectedBidToEdit');
        }
    }
    function UserItems(DbService, $location, $rootScope) {
        var vm = this;
        vm.message = 'List of all Categories, when category is selected user will be redirected to a display of items in that category';
        DbService.getUserItems().then(function (items) {
            console.log(items, "items came back");
            vm.userItems = items;
        })
        vm.grabItemToEdit = function (index) {
            $rootScope = index
            //itemIndex = index;
            console.log(index);
            DbService.storeUserIndex(index);
            $location.path('/selectedItemToEdit');
        }
    }
    function SelectedItem(DbService, $location, $rootScope) {
        var vm = this;
        vm.message = 'User selected item';
        vm.item = DbService.getItem();
        vm.addBid = function () {
            var bid = {
                ItemId: vm.item.ItemId,
                Amount: vm.amount
            };
            console.log(bid.ItemId);
            DbService.placeBid(bid).then(redirectToCurrBids, displayError)
        }
        function redirectToCurrBids() {
            vm.isLoading = false;
            $location.path('/userCurrBids');
        }
        function displayError() {
            vm.isLoading = false;
        }
    }
    function SelectedItemToEdit(DbService, $rootScope, $location) {
        var vm = this;
        vm.message = 'routing works';
        vm.userItem = DbService.getUserItem();
        console.log(vm.userItem);
        vm.deleteItem = function () {
            DbService.deleteUserItem(vm.userItem).then(redirectToUserItems, displayError);
        }
        vm.editItem = function (){
            var editedItem = {
                ItemId: vm.userItem.ItemId,
                Name: vm.userItem.Name,
                Description: vm.userItem.Description,
                MinPrice: vm.userItem.Availible,
                BidExpiration: vm.userItem.BidExpiration
            }
            DbService.replaceItem(editedItem).then(redirectToUserItems, displayError);
        }
        function redirectToUserItems() {
            vm.isLoading = false;
            $location.path('/userItems');
        }
        function displayError() {
            vm.isLoading = false;
        }
    };

    function SelectedBidToEdit(DbService, $rootScope, $location) {
        var vm = this;
        vm.message = 'Routing is working';
        vm.userBid = DbService.getUserBids();
        console.log(vm.userBid);
        vm.deleteBid = function () {
            DbService.deleteUserBid(vm.userBid).then(redirectToCurrBids, displayError)
        }
        vm.editBid = function () {
            var editBid = {
                BidId: vm.userBid.BidId,
                ItemName: vm.userBid.ItemName,
                MinPrice: vm.userBid.MinPrice,
                BidExpiration: vm.userBid.BidExpiration,
                Amount: vm.userBid.Amount
            }
            DbService.replaceBid(editBid).then(redirectToCurrBids, displayError);
        }
        function redirectToCurrBids() {
            vm.isLoading = false;
            $location.path('/userCurrBids');
        }
        function displayError() {
            vm.isLoading = false;
        }
    }

    function ItemsByCat() {
        var vm = this;
        vm.message = 'Category Name';
    }

    function Add(DbService, $location, $rootScope) {
        var vm = this;
        vm.isLoading = false;
        vm.message = 'Allows a seller to post an item';
        vm.addItems = function () {
            vm.isLoading = true;
            var item = {
                Name: vm.name,
                Description: vm.description,
                MinPrice: vm.minPrice,
                //BidExpiration: vm.bidExpiration
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