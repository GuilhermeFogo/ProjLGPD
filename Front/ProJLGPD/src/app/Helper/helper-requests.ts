import { CookieService } from "../Services/cookie/cookie.service";

export abstract class HelperRequests {
    private cookie: CookieService;

    constructor(cookie: CookieService){
        this.cookie = cookie;
    }

    public Ajudarequest(){
        const cookies: string ="Bearer"+" "+ this.cookie.getValueCookie("Session");
        return cookies;
    }


}
