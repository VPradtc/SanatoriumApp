module pinguinPortal.app.models {
    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;

    export interface ICurrentCompanyInfo {
        id: number;
        typeId: CompanyTypeIdentifier;
    }

}