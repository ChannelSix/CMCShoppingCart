import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable()
export class AddApiUrlInterceptor implements HttpInterceptor {

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const clonedRequest = request.clone({ 
            url: `${environment.apiUrl}/${request.url}`,
            // headers: new HttpHeaders({
            //     'Content-Type': 'application/json'
            // })
        });
        return next.handle(clonedRequest);
    }
}