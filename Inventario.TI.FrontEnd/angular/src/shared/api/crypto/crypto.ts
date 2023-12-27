export class Crypto {

    static encryptValue(value: string): string {
        return btoa(unescape(encodeURIComponent(btoa(unescape(encodeURIComponent(value))))));
    }
    static decryptValue(value: string): string {
        return decodeURIComponent(escape(atob(decodeURIComponent(escape(atob(value))))));
    }   
}