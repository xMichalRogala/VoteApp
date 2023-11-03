import { Injectable } from '@angular/core';

import { of } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable()
export class ConfigService {
  public buildUrl(fragment: string): any {
    return of(`${environment.apiAddress}/${fragment}`);
  }
}
