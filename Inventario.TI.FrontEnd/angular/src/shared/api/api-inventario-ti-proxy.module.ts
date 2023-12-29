import { NgModule } from "@angular/core";
import { AccountServiceProxy, AutenticacaoServiceProxy } from "./api-inventario-ti-proxy";


@NgModule({
    providers: [
        AutenticacaoServiceProxy,
        AccountServiceProxy,
    ]
})
export class ApiInventarioTIPRoxyModule { }
