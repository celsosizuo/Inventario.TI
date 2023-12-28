import { Injectable, OnInit } from '@angular/core';
import { MessageService, PrimeNGConfig } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private messageService: MessageService, private primengConfig: PrimeNGConfig){
    this.primengConfig.ripple = true;
   }

  showSuccess(message: string) {
    this.messageService.add({
      severity: 'success',
      summary: 'Sucesso',
      detail: message,
    });
  }
}
