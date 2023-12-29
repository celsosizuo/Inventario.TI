import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { ApiInventarioTIPRoxyModule } from '../shared/api/api-inventario-ti-proxy.module';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastModule } from 'primeng/toast';
import { RippleModule } from 'primeng/ripple';
import { BrowserAnimationsModule } 
    from '@angular/platform-browser/animations';
    import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { CardModule } from 'primeng/card';
import { API_BASE_URL } from '../shared/api/api-inventario-ti-proxy';
import { environment } from '../environments/environment';
import { provideNgxMask } from 'ngx-mask';
import { LoadingScreenComponent } from '../shared/loading-screen/loading-screen.component';
import { ProgressBarModule } from 'primeng/progressbar';
import { LoadingScreenService } from '../shared/loading-screen/loading-screen.service';
import { AuthenticationService } from '../shared/api/auth/authentication.service';
import { ToastService } from './toast/toast.service';
import { MessageService } from 'primeng/api';
import { CadastroEmpresaComponent } from './cadastro-empresa/cadastro-empresa.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LoadingScreenComponent,
    CadastroEmpresaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ApiInventarioTIPRoxyModule,
    NgbModule,
    BrowserAnimationsModule,
    ToastModule,
    ButtonModule,
    RippleModule,
    FormsModule,
    InputTextModule,
    PasswordModule,
    InputGroupModule,
    InputGroupAddonModule,
    CardModule,
    ProgressBarModule,
  ],
  providers: [
    provideNgxMask(),{
      provide: API_BASE_URL,
      useFactory: () => {
        return environment.apiBaseUrl;
      }
    },
    LoadingScreenService,
    AuthenticationService,
    ToastService,
    MessageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
