module pinguinPortal.app.core.models.localization {

    import LanguageIdentifier = app.core.models.enums.LanguageIdentifier;

    export abstract class LocalizationObservable {

        constructor(
            protected readonly $q: ng.IQService) {
        }

        private readonly renderers: Array<IApplicationLanguageObserver> = [];

        public add(renderer: IApplicationLanguageObserver): void {
            if (this.renderers.indexOf(renderer) < 0) {
                this.renderers.push(renderer);

                this.loadCurrentLanguage()
                    .then((languageId) => renderer.render(languageId));
            }
        }

        public notify(): void {
            this.loadCurrentLanguage()
                .then((languageId) => this.$q.all(this.renderers.map(x => x.render(languageId))));
        }

        public remove(observer: IApplicationLanguageObserver): void {
            let removeAt = this.renderers.indexOf(observer);
            this.renderers.splice(removeAt, 1);
        }

        protected abstract loadCurrentLanguage(): ng.IPromise<LanguageIdentifier>;
    }
}
