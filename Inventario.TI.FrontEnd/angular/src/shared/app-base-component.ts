import { Injectable, Injector } from "@angular/core";
import { LoadingScreenService } from "./loading-screen/loading-screen.service";
import { AuthenticationService } from "./api/auth/authentication.service";
import { MessageService, PrimeNGConfig } from "primeng/api";
import { TipoMensagem } from "../app/toast/enumtipomensagem";

@Injectable()
export abstract class AppBaseComponent {
    private loadingScreenService: LoadingScreenService;
    private messageService: MessageService;
    private primengConfig: PrimeNGConfig;
    authService: AuthenticationService;

    constructor(injector: Injector) {
        this.loadingScreenService = injector.get(LoadingScreenService);
        this.authService = injector.get(AuthenticationService);
        this.messageService = injector.get(MessageService);
        this.primengConfig = injector.get(PrimeNGConfig);
    }

    startLoading(initialLoading: boolean = false) {
        this.loadingScreenService.startLoading(initialLoading);
    }

    stopLoading() {
        this.loadingScreenService.stopLoading();
    }

    showMessage(tipo: string, titulo: string, mensagem: string) {
        this.messageService.add({severity:tipo, summary:titulo, detail: mensagem});
      }    

    protected verifyError(error: any) {

        this.stopLoading();

        const message = error && error.response ? error.response : this.lang('MSG_ERRO');

        if (error.status === 401) {
            AuthenticationService.signOut();
        } else if (error.status === 403) {
            this.showMessage(TipoMensagem.Aviso, 'Atenção', this.lang('MSG_ERRO_USUARIO_SEM_PERMISSAO'));
        } else {
            if (error.exception) {

                if (error.exception instanceof Blob) {
                    this.verifyErrorBlobToJson(error.exception);
                } else {
                    if (error.exception) {
                        console.error(error.exception);
                    }
                    this.showMessage(TipoMensagem.Aviso, 'Atenção', this.lang('MSG_ERRO'));
                }
            } else {
                if (error && error.status === 400) {
                    let mensagem = JSON.parse(message);
                    this.showMessage(TipoMensagem.Aviso, 'Atenção', mensagem.message);
                } else {
                    this.showMessage(TipoMensagem.Erro, 'Atenção', this.lang('MSG_ERRO'));
                }
            }
        }
    }

    lang(key: string): string {
        const langResource = this.authService.getLanguageResource();

        if (langResource) {
          const value = langResource[key];

          if (value) {
            return value;
          }
        }
        return key;
    }

    private verifyErrorBlobToJson(blob: Blob) {
        const reader = new FileReader();
        reader.onload = (event: any) => {
          const result = event.target.result as string;
          this.verifyError(JSON.parse(result));
        };
        reader.readAsText(blob);
      }    
}