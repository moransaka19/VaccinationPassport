import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class CookieService {
    isExist(name){
        var dc = document.cookie;
        var prefix = name + "=";
        var begin = dc.indexOf("; " + prefix);
        if (begin == -1) {
            begin = dc.indexOf(prefix);
            if (begin != 0) return null;
        }
        else
        {
            begin += 2;
            var end = document.cookie.indexOf(";", begin);
            if (end == -1) {
            end = dc.length;
            }
        }
        return !(decodeURI(dc.substring(begin + prefix.length, end)));
    }
}