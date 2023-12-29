import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoadingScreenService } from './loading-screen.service';

@Component({
  selector: 'app-loading-screen',
  templateUrl: './loading-screen.component.html',
  styleUrl: './loading-screen.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class LoadingScreenComponent implements OnInit, OnDestroy {
  
  loading: boolean = false;
  loadingSubscription: Subscription = new Subscription();

  constructor(private loadingSreenService: LoadingScreenService) { }
  
  ngOnInit(): void {
    this.loadingSubscription = this.loadingSreenService.loadingStatus.subscribe((value) => {
      this.loading = value;
    });
  }

  ngOnDestroy(): void {
    this.loadingSubscription.unsubscribe();
  }
}
