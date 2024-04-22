import { makeAutoObservable, reaction } from "mobx";
import { ServerError } from "../models/serverError";

export default class CommonStore {
    error: ServerError | null = null;
    token: string | null | undefined = localStorage.getItem("jwt");
    appLoaded = false

    constructor() {
        makeAutoObservable(this);

        reaction(
            () => this.token, // what we want to react to
            token => {   // what do you want to do 
                if(token){
                    localStorage.setItem("jwt", token)
                }else{
                    localStorage.removeItem("jwt")
                }
            }
        )
    }

    setServerError(error: ServerError) {
        this.error = error;
    }

    setToken (token: string | null) {
/*         if(token) localStorage.setItem("jwt", token) THIS WİLL HANDLED BYU REACTION
 */        this.token = token
    }

    setAppLoaded () {
        this.appLoaded = true
    }
}