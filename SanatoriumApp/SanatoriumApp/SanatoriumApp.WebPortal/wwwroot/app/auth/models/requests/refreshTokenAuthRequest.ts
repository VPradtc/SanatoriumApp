module pinguinPortal.app.auth.models {
/* tslint:disable:variable-name */

    export class RefreshTokenAuthRequest extends AuthRequest {
        constructor(
            grant_type: string
            , public readonly refresh_token: string
            , public readonly client_id: string
        ) {
            super(grant_type);
        }
    }
}

/* tslint:enable:variable-name */
