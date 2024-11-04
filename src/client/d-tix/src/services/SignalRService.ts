import {HubConnection, HubConnectionBuilder} from '@microsoft/signalr'

export default class SignalRService{
    private hubConnection: HubConnection;
    constructor(domain:string, action:string, query:string | null = null) {

        const url = query==null ? `https://${domain}/${action}`:`https://${domain}/${action}?${query}`
        this.hubConnection = new HubConnectionBuilder()
            .withUrl(url)
            .withAutomaticReconnect()
            .build();
    }

    get HubConection(){
        return this.hubConnection;
    }
}