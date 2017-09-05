module pinguinPortal.app.core.controls {

    interface IDateLabelBinding {
        durationThresholdMinutes: number,
        text: string,
    }

    class AgoDateLabelDirectiveController {
        static $inject = [
            '$scope',
        ];

        constructor(
            private readonly vm: ng.IScope) {

            vm.getDateLabel = this.getDateLabel.bind(this);
        }

        public getDateLabel(): any {
            var notificationDate = new Date(this.vm.dateToStartWith);
            var currentDate = new Date();

            var timeDiffMinutes = Math.floor((currentDate.getTime() - notificationDate.getTime()) / (1000 * 60));

            var targetBinding = this.dateLabelBindings.filter(binding => binding.durationThresholdMinutes <= timeDiffMinutes)[0];

            var labelParameter = targetBinding.durationThresholdMinutes !== 0
                ? Math.floor(timeDiffMinutes / targetBinding.durationThresholdMinutes)
                : null;

            return {
                text: targetBinding.text,
                parameter: labelParameter,
            };
        }

        private readonly dateLabelBindings: IDateLabelBinding[] = [
            {
                durationThresholdMinutes: 60 * 48,
                text: 'dashboard.daysAgo',
            },
            {
                durationThresholdMinutes: 60,
                text: 'dashboard.hoursAgo',
            },
            {
                durationThresholdMinutes: 2,
                text: 'dashboard.minutesAgo',
            },
            {
                durationThresholdMinutes: 0,
                text: 'dashboard.momentsAgo',
            },
        ];
    }

    function AgoDateLabelDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                dateToStartWith: '<'
            },
            templateUrl: 'app/_core/controls/ago-date-label-control/ago-date-label-control.html',
            controller: AgoDateLabelDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixAgoDateLabel', AgoDateLabelDirective);
}