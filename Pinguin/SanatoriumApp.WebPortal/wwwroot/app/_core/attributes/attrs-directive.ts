module pinguinPortal.app.core.attribures {

    function AttrsDirective($parse: ng.IParseService, $compile: ng.ICompileService): ng.IDirective {
        return {
            priority: 1000,
            link: function ($scope: ng.IScope, $element: JQuery, $attrs: ng.IAttributes): void {
                var attrs = $parse($attrs.ixAttrs)($scope);

                for (var attrName in attrs) {
                    $attrs.$set(attrName, attrs[attrName]);
                }
                $element.removeAttr('ix-attrs');
                $compile($element)($scope);
            }
        };
    }

    AttrsDirective.$inject = ['$parse', '$compile'];

    angular.module('pinguinPortal').directive('ixAttrs', AttrsDirective);
}