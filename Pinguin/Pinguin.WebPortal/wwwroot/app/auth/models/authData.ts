module pinguinPortal.app.auth.models {
    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;

    export class AuthData {
        public firstName: string;
        public lastName: string;
        public role: CompanyTypeIdentifier;
        public isAuthenticated: boolean;
        public accessToken: string;
        public refreshToken: string;
    }
}
