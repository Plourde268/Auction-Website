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
    function Items() {
        var vm = this;

        vm.message = 'List of all of the items in the virtual Warehouse';
    }
    function SelectedItem() {
        var vm = this;

        vm.message = 'User selected item';
    }
    function Categories() {
        var vm = this;

        vm.message = 'List of all Categories, when category is selected user will be redirected to a display of items in that category';
    }
    function ItemsByCat() {
        var vm = this;

        vm.message = 'Category Name';
    }
    function Add() {
        var vm = this;

        vm.message = 'Allows a seller to post an item';
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
    function Login() {
        var vm = this;

        vm.message = 'Allows retrning users to sign in';
    }
})();