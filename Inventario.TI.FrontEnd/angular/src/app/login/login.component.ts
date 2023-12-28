import { Component, Injector, OnInit } from '@angular/core';
import { AutenticacaoServiceProxy, LoginModel } from '../../shared/api/api-inventario-ti-proxy';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { TipoMensagem } from '../toast/enumtipomensagem';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers: [MessageService],
})
export class LoginComponent implements OnInit {
  private autenticacaoService: AutenticacaoServiceProxy;
  loginModel: LoginModel;
  usuario: string = '';
  senha: string = '';

  constructor(injector: Injector, private messageService: MessageService, private primengConfig: PrimeNGConfig) {
    this.loginModel = new LoginModel();
    this.autenticacaoService = injector.get(AutenticacaoServiceProxy);
  }
 
  ngOnInit() {
    this.primengConfig.ripple = true;
  }

  efetuarLogin() {
    if(!this.validarCampos()) {
      return;
    }
    
    this.autenticacaoService.autenticar(this.loginModel).subscribe(result => {
      if(result) {
        console.log('result', result);
      } else {
        console.log('não result');
      }
    }, (error) => {
      this.showMessage(TipoMensagem.Erro, 'Erro na API', error);
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

  showMessage(tipo: string, titulo: string, mensagem: string) {
    this.messageService.add({severity:tipo, summary:titulo, detail: mensagem});
  }
}
