module pinguinPortal.app.filters {

    export function tailFilter()
        : (value: string, length: string) => string {

        return function (value: string, length: string): string {
            if (value === undefined
                || value === null) {
                return '';
            }

            var maxLength = parseInt(length);

            if (maxLength === undefined) {
                return value;
            }

            if (value.length <= maxLength) {
                return value;
            }

            var formattedValue = value.substr(0, maxLength);
            var tail = '...';

            return formattedValue.concat(tail);
        };
    }

    angular.module('pinguinPortal').filter('tail', tailFilter);
}