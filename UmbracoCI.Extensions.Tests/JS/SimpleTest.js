/// <reference path="umbraco-references.js" />
/// <reference path="../../UmbracoCI.Web.UI/App_Plugins/SimplePlugin/backoffice/SimpleDataType/editors/editor.js" />

var ctrl, ctrlScope, injector, simpleMock;

module("Simple Angular provider", {
    setup: function () {
        var appModule = angular.module("umbraco");
        injector = angular.injector(["ng", "umbraco"]);

        ctrlScope = injector.get("$rootScope").$new();
        ctrl = injector.get("$controller")("CodeGeckoSimpleDataTypeEditor", { $scope: ctrlScope });
    },
    teardown: function () {

    }
});
test("Manipulate-mocked-object", function () {
    ok(ctrlScope.myFunc(1, 2) === 3);
})