import { type ToastContainerOptions } from 'vue3-toastify';

const  customToastyConfig={
    autoClose: 3000,
    theme: 'dark',
    multiple: true,
    limit : 2,
    position: 'top-right',
    type: "success",
    transition: 'slide',
    dangerouslyHTMLString: true
} as ToastContainerOptions


export default customToastyConfig;