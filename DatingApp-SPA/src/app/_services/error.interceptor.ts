import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  intercept(
    req: import('@angular/common/http').HttpRequest<any>,
    next: import('@angular/common/http').HttpHandler
  ): import('rxjs').Observable<import('@angular/common/http').HttpEvent<any>> {
    return next.handle(req).pipe(
        catchError(error => {
            if (error.status === 401){
                return throwError(error.StatusText);
            }
           
            if (error instanceof HttpErrorResponse){
                const applicationerror = error.headers.get('Application-error');
                if (applicationerror){
                    return throwError(applicationerror);
                }
            }
            const serverError = error.error;
            let modelstateErrors = '';
            if(serverError.error && typeof serverError.errors === 'object'){
                for (const key in serverError.errors){
                    if (serverError.errors[key]){
                        modelstateErrors += serverError.errors[key] + '\n';
                    }
                }
            }
            return throwError(modelstateErrors || serverError || 'Server Error');
          })
    )
  }
}

export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
        multi: true

}