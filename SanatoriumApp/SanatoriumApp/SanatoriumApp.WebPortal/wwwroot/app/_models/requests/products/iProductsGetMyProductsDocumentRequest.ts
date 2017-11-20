module pinguinPortal.app._models.requests.products {

    import LanguageIdentifier = pinguinPortal.app.core.models.enums.LanguageIdentifier;

    import DocumentTypeIdentifier = pinguinPortal.app.core.models.enums.DocumentTypeIdentifier;

    export interface IProductsGetMyProductsDocumentRequest {
        access_token?: string;
        languageId: LanguageIdentifier;
        documentType: DocumentTypeIdentifier
    }
}