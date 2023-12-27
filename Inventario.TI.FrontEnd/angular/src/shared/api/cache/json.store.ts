import { Store } from './store';

export abstract class JsonStore extends Store {

    static override getItem(key: string): any {

        const item = super.getItem(key);

        if (item) {

            const content = item;
            const user = JSON.parse(content);
            return user;

        }

        return null;
    }

    static override setItem(key: string, json: any) {

        const content = JSON.stringify(json);
        super.setItem(key, content);

    }
  
    static override removeItem(key: string) {
        super.removeItem(key);
    }  
    
    
}