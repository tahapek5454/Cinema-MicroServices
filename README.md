# D-TIX

## Summary
The project simulates purchasing tickets for a cinema movie online from start to finish. These scenarios are implemented using the latest technologies, fully integrating real-life processes. **The project is entirely for educational purposes.**



## Technologies and Architecture
+ The project adopts a microservice architecture.
+ Key technologies used in the project: Vue.js 2, Vuetify, Tailwind CSS, .Net 9, EfCore, CQRS, MSSQL, MongoDb, OpenAI, Docker, Kubernetes...

## Important Considerations Before Running the Project
+ The latest commit configuration includes settings to deploy the project in a Kubernetes environment.
+ To run the project in a **local** environment:
    + Method 1
        + Revert to commit **261d5b0835a125d046d3ce440ea9ef4b05735580**.
        + Adjust the appsettings.json files of the microservices according to your local environment.
    + Method 2
        + Adjust the appsettings.json files of the microservices according to your local environment.
        + Configure the API Gateway ocelot.json to match the local environment.
        + Modify the embedded addresses in the file located at 'src/server/MicroServices/Cinema.Services.PaymentAPI/Controllers/PaymentsController.cs' in the Payment microservice.
        + Update the embedded host in the file at 'src/client/d-tix/src/constDatas.ts' in the client part.
        + Change the SignalR protocol in 'src/client/d-tix/src/services/SignalRService.ts' in the client part.
        + Update the SignalR target address in 'src/client/d-tix/src/components/theaterhall/index.ts' in the client part.
        + Modify the base addresses in 'src/client/d-tix/src/utils/AxiosIstance.ts' in the client part.
