import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Observable, switchMap, map, catchError, throwError } from 'rxjs';

@Injectable()
export abstract class ServiceBase {
  constructor(
    protected configService: ConfigService,
    protected httpClient: HttpClient
  ) {}

  protected getData<T>(
    urlFragment: string,
    errorMessage: string
  ): Observable<T> {
    const result = this.configService.buildUrl(urlFragment).pipe(
      switchMap((url: string) =>
        this.httpClient.get(url).pipe(
          map((res: any) => {
            return res;
          }),
          catchError((error) => this.handleError(errorMessage, error))
        )
      ),
      catchError((error) => this.handleError(errorMessage, error))
    );
    return result;
  }

  protected postData<T>(url: string, data: T, errorMessage: string) {
    return this.configService.buildUrl(url).pipe(
      switchMap((urlAddress: string) =>
        this.httpClient.post(urlAddress, data).pipe(
          map((res: any) => res),
          catchError((error) => this.handleError(errorMessage, error))
        )
      ),
      catchError((error) => this.handleError(errorMessage, error))
    );
  }

  protected handleError(message: string, error: any) {
    console.log(message);
    return throwError(() => error);
  }
}
