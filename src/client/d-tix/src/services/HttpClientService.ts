
import axios from "@/utils/AxiosIstance";
import type { AxiosResponse } from "axios";

export class HttpClientService {

  private url(requestParameters: Partial<RequestParameters>): string {
    return `${requestParameters.serverName
      ? requestParameters.serverName
      : ServerNames.MovieServer
      }/${requestParameters.accessModify
        ? requestParameters.accessModify
        : AccessModify.Private
      }api/${requestParameters.controller}${requestParameters.action ? `/${requestParameters.action}` : ""
      }`;
  }



  protected async getAsync<T>(
    requestParameters: Partial<RequestParameters>,
    id?: string
  ): Promise<T> {
    let url: string = "";

    url = `${this.url(requestParameters)}${id ? `/${id}` : ""}${requestParameters.queryString ? `?${requestParameters.queryString}` : ""
      }`;

    const response: AxiosResponse<T> = await axios.get<T>(
      url
    );

    return response.data;
  }

  protected async postAsync<T, R>(
    requestParameters: Partial<RequestParameters>,
    body: Partial<T>
  ): Promise<R> {
    let url: string = "";

    url = `${this.url(requestParameters)}${requestParameters.queryString ? `?${requestParameters.queryString}` : ""
      }`;

    const response: AxiosResponse<R> = await axios.post<R>(
      url,
      body
    );

    return response.data;
  }

  protected async putAsync<T, R>(
    requestParameters: Partial<RequestParameters>,
    body: Partial<T>
  ): Promise<R> {
    let url: string = "";

    url = `${this.url(requestParameters)}${requestParameters.queryString ? `?${requestParameters.queryString}` : ""
      }`;

    const response: AxiosResponse<R> = await axios.put<R>(
      url,
      body
    );

    return response.data;
  }

  protected async deleteAsync<T>(
    requestParameters: Partial<RequestParameters>,
    id: string
  ): Promise<T> {
    let url: string = "";

    url = `${this.url(requestParameters)}/${id}${requestParameters.queryString ? `?${requestParameters.queryString}` : ""
      }`;

    const response: AxiosResponse<T> = await axios.delete<T>(
      url
    );

    return response.data;
  }
}

export class RequestParameters {
  serverName?: ServerNames;
  accessModify?: AccessModify;
  controller?: string;
  action?: string;
  queryString?: string;
  headers?: any;
}

export enum ServerNames {
  AuthServer = "authserver",
  FileServer = "fileserver",
  MovieServer = "movieserver",
  AiServer = "aiserver",
  SessionServer = "sessionserver",
  BranchServer = "branchserver",
  CategoryServer = "categoryserver",
  PaymentServer  = "paymentserver"
}

export enum AccessModify {
  Public = "public/",
  Private = "",
}