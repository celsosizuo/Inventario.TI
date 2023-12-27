import { Crypto } from '../crypto/crypto';

export abstract class Store {
    static getItem(key: string): string {

        const item = sessionStorage.getItem(key);

        if (item) {

            const content = Crypto.decryptValue(item);

            if (content === '[object Object]') {
                return 'null';
            }

            return content;
        }

        return 'null';
    }

    static setItem(key: string, value: string) {

        const content = Crypto.encryptValue(value);

        if (content !== '[object Object]') {
            sessionStorage.setItem(key, content);
        }
    }

    static removeItem(key: string) {
        sessionStorage.removeItem(key);
    }   
}