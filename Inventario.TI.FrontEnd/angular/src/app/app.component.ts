import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'inventario-ti-frontend';
  items: MenuItem[] = [];

  ngOnInit(): void {
    this.items = [
      { label: 'Página Inicial', icon: 'pi pi-home', routerLink: '/' },
      { label: 'Produtos', icon: 'pi pi-list', routerLink: '/produtos' },
      { label: 'Contato', icon: 'pi pi-envelope', routerLink: '/contato' },
    ];
  }
}
