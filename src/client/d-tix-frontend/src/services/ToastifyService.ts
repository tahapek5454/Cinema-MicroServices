import { toast, type Id, type ToastOptions, type ToastPosition, type ToastType } from 'vue3-toastify';




export class ToastifyService{
    promise(
        promise: Promise<any>,
        pendingMessage: string = 'İşem Başladı',
        successMessage: string = 'Başarılı',
        errorMessage: string = 'Hata',
        customSettings?: Partial<CustomSettings>
    ): Promise<any>{
        return toast.promise(
            promise,
            {
              pending: pendingMessage,
              success: successMessage,
              error: errorMessage,
            },
            customSettings ? customSettings : {}
        );
    }

    success(message: string = "İşlem Başarılı", customSettings?: Partial<CustomSettings>): Id{
        return toast(message, 
        {
            ...customSettings,
            type: 'success'
        } as ToastOptions);
    }

    error(message: string = "İşlem Başarısız", customSettings?: Partial<CustomSettings>): Id{
        return toast(message,
            {
                ...customSettings,
                type: 'error'
            }as ToastOptions
        )
    }

    info(message: string = "Bilgilendirme", customSettings?: Partial<CustomSettings>): Id{
        return toast(message,
            {
                ...customSettings,
                type: 'info'
            }as ToastOptions
        )
    }

    warning(message: string = "Uyarı", customSettings?: Partial<CustomSettings>): Id{
        return toast(message,
            {
                ...customSettings,
                type: 'warning'
            }as ToastOptions
        )
    }

    loading(message: string = "Lütfen Bekleyiniz...", customSettings?: Partial<CustomSettings>): Id{
        return toast.loading(message, customSettings ? customSettings : {})
    }

    update(id: Id, customSettings: Partial<UpdateSettings>){
        toast.update(id, customSettings)
    }
}



export interface CustomSettings{
    autoClose?: number;
    position?: ToastPosition;
}

export interface UpdateSettings{
    autoClose: number;
    type: ToastType;
}