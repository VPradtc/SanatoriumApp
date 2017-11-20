module pinguinPortal.app.auth.models {
/* tslint:disable:variable-name */

    export abstract class AuthRequest {

        constructor(
            public readonly grant_type: string,
        ) {
        }
    }
}
/* tslint:enable:variable-name */
