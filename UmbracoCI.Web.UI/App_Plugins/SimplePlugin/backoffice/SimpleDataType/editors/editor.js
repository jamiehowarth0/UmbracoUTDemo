angular.module("umbraco")
       .controller("CodeGeckoSimpleDataTypeEditor", function ($scope) {

           $scope.myFunc = function (a, b) {
               return a + b;
           }
});