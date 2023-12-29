import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingScreenService {
  private ploading: boolean = false;
  private pInitialLoading: boolean = false;
  loadingStatus: Subject<boolean> = new Subject();

  get initialLoading(): boolean {
      return this.pInitialLoading;
  }

  get loading(): boolean {
      return this.ploading;
  }
  set loading(value) {
      this.ploading = value;
      this.loadingStatus.next(value);
  }

  startLoading(initialLoading: boolean = false) {
      this.pInitialLoading = initialLoading;
      this.loading = true;
  }

  stopLoading() {
      this.pInitialLoading = false;
      this.loading = false;
  }
}
