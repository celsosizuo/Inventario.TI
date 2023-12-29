import { Component, Injector, OnInit, inject } from '@angular/core';
import { AutenticacaoServiceProxy, LoginModel } from '../../shared/api/api-inventario-ti-proxy';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { TipoMensagem } from '../toast/enumtipomensagem';
import { AppBaseComponent } from '../../shared/app-base-component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers: [MessageService],
})
export class LoginComponent extends AppBaseComponent implements OnInit {
  private autenticacaoService: AutenticacaoServiceProxy;
  loginModel: LoginModel;
  usuario: string = '';
  senha: string = '';

  constructor(injector: Injector) {
    super(injector);

    // this.toastService = injector.get(ToastService);
    this.autenticacaoService = injector.get(AutenticacaoServiceProxy);
    this.loginModel = new LoginModel();
  }
 
  ngOnInit() {
    // this.primengConfig.ripple = true;
  }

  efetuarLogin() {
    this.startLoading();
    if(!this.validarCampos()) {
      return;
    }
    
    this.autenticacaoService.autenticar(this.loginModel).subscribe(result => {
      this.stopLoading();
      if(result) {
        console.log('result', result);
      } else {
        console.log('não result');
      }
    }, (error) => {
      this.verifyError(error);
    })
  }

  validarCampos() : boolean {
    if(!this.loginModel.usuario) {
      this.showMessage(TipoMensagem.Aviso, 'Campo obrigatório', 'O campo usuário é de preenchimento obrigatório');
      return false;
    }

    if(!this.loginModel.senha) {
      this.showMessage(TipoMensagem.Aviso, 'Campo obrigatório', 'O campo senha é de preenchimento obrigatório');
      return false;
    }

    return true;
  }
}
