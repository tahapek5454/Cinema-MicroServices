import type { ErrorDto } from "./ErrorDto";

export interface ResponseDto<T>{
    data?: T;
    statusCode?: number;
    error?: ErrorDto;
    isSuccessful?: boolean;
}