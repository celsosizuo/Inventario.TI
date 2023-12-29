import { Component, Injector, OnInit } from '@angular/core';
import { AppBaseComponent } from '../../shared/app-base-component';
import { AccountServiceProxy, ContaModel, Empresa, Usuario } from '../../shared/api/api-inventario-ti-proxy';
import { TipoMensagem } from '../toast/enumtipomensagem';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-cadastro-empresa',
  templateUrl: './cadastro-empresa.component.html',
  styleUrl: './cadastro-empresa.component.scss',
  providers: [MessageService],
})
export class CadastroEmpresaComponent extends AppBaseComponent implements OnInit {
  
  private accountService: AccountServiceProxy;
  
  senha: string = '';
  confimarSenha: string = '';
  campoSenha: boolean = false;
  model: ContaModel = new ContaModel();
  campos: string[] = []

  constructor(injector: Injector) {
    super(injector);
    this.inicializarModel();
    this.accountService = injector.get(AccountServiceProxy);
  }

  ngOnInit(): void {
    this.campos = [];
  }

  cadastrarEmpresa() {
    if(this.validarCampos()) {
      this.accountService.cadastrarEmpresa(this.model).subscribe(result => {
        if(result) {
          this.showMessage(TipoMensagem.Sucesso, 'Sucesso', 'Empresa cadastrada com sucesso!');
          this.campos = [];
        }
      }, (error) => {
        this.verifyError(error);
      });
    }
  }


  private validarSenhaDigitada() : boolean {
    if(this.senha === this.confimarSenha) {
      this.model.usuario.senha = this.senha;
      return true;
    }

    this.campoSenha = true;
    this.showMessage(TipoMensagem.Aviso, 'Aviso', 'As senhas não conferem, favor digitar novamente');
    return false;
  }

  private inicializarModel() {
    this.model.empresa = new Empresa();
    this.model.usuario = new Usuario();

    this.model.empresa.ativo = false;
    this.model.usuario.ativo = false;
  }

  private validarCampos() {
    this.campos = [];
    let retorno : boolean = true;

    if(!this.model.empresa.cnpj) {
      this.campos.push('cnpj');
      retorno = false;
    }

    if(!this.model.empresa.razaoSocial) {
      this.campos.push('razaoSocial');
      retorno = false;
    }

    if(!this.model.usuario.nome) {
      this.campos.push('nome');
      retorno = false;
    }

    if(!this.model.usuario.login) {
      this.campos.push('login');
      retorno = false;
    }

    if(!this.senha) {
      this.campos.push('senhabranco');
      retorno = false;
    }

    if(this.senha === this.confimarSenha) {
      this.model.usuario.senha = this.senha;
    } else {
      this.campos.push('senha');
      retorno = false;
    }

    return retorno;
  }

  checaCampoValido(campo: string) {
    if(this.campos.find(x => x === campo)) {
      return true;
    }
    return false;
  }

  teste(campo : string) {
    let posicao = this.campos.indexOf(campo);
    this.campos.splice(posicao, 1);
  }
}
