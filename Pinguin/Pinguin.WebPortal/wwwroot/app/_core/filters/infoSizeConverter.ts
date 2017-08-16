module pinguinPortal.app.filters {

    export function infoSizeConverter(): (value: number) => string {

        var dictionary = {
            'GB': 1000000000,
            'MB': 1000000,
            'KB': 1000,
        };

        return function (value: number): string {
            var result = '';

            if (value === null
                || value === undefined
                || value === 0) {
                return result;
            }

            for (var key in dictionary) {
                var divider: number = (<any>dictionary)[key];

                if (value / (divider) > 1) {
                    result = (value / divider).toFixed(1) + key;

                    return result;
                }
            }

            return value + 'B';
        };
    }

    angular.module('pinguinPortal').filter('infoSizeConverter', infoSizeConverter);
}
