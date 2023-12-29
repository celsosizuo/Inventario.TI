import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CadastroEmpresaComponent } from './cadastro-empresa/cadastro-empresa.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'cadastro-empresa', component: CadastroEmpresaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
