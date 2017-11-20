module pinguinPortal.app.core.models.localization {

    import LanguageIdentifier = app.core.models.enums.LanguageIdentifier;

    export interface IApplicationLanguageObserver {
        render(languageId: LanguageIdentifier): ng.IPromise<any>;
    }
}
