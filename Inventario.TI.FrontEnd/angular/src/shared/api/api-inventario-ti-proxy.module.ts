import { NgModule } from "@angular/core";
import { AutenticacaoServiceProxy } from "./api-inventario-ti-proxy";


@NgModule({
    providers: [
        AutenticacaoServiceProxy
    ]
})
export class ApiInventarioTIPRoxyModule { }
