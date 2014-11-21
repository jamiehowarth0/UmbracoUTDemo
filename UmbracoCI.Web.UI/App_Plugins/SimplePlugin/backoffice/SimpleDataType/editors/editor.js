angular.module("umbraco")
       .controller("CodeGecko.SimpleDataType.Editor", function ($scope) {

           $scope.myFunc = function (a, b) {
               return a + b;
           }
});