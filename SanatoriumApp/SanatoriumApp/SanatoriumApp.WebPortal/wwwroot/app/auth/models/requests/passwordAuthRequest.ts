module pinguinPortal.app.auth.models {
/* tslint:disable:variable-name */

    export class PasswordAuthRequest extends AuthRequest {

        constructor(
            grant_type: string
            , public readonly email: string
            , public readonly password: string
        ) {
            super(grant_type);
        }
    }
}
/* tslint:enable:variable-name */
