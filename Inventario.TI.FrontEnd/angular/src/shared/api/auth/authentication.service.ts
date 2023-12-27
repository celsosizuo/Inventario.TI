import { Injectable, Injector } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { Store } from '../cache/store';
import { JsonStore } from '../cache/json.store';


@Injectable()
export class AuthenticationService { 

    private static readonly STORAGE_KEY_USER = 'user-session';
    private static readonly STORAGE_KEY_CURRENT_LANGUAGE = 'current-language';
    private static readonly STORAGE_KEY_LANGUAGE = 'language-resource';
    private static readonly STORAGE_KEY_PHOTO_USER = 'user-photo';


    static getJwtFullHeaders(contentHeaders: any): HttpHeaders {

        contentHeaders = '';

        return new HttpHeaders({
            'Content-Type': 'application/json',
            Accept: 'application/json',
            'Accept-Language': AuthenticationService.getCulture(),
            Authorization: AuthenticationService.getJwTToken()
        });
    }

    static getCulture(): string {

        let language = Store.getItem(AuthenticationService.STORAGE_KEY_CURRENT_LANGUAGE);

        if (!language) {

            language = 'pt-BR';
            AuthenticationService.setCulture(language);

        }

        return language;
    }
    
    static getJwTToken(): string {

        const UsuarioModel = JsonStore.getItem(AuthenticationService.STORAGE_KEY_USER);

        if (UsuarioModel) {
            return 'Bearer  ' + UsuarioModel.token;
        }

        return '';
    }

    static setCulture(culture: string) {
        Store.setItem(AuthenticationService.STORAGE_KEY_CURRENT_LANGUAGE, culture);
    }
}