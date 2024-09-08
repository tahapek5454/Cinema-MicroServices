import Vue from "vue";
import Toast, { POSITION } from "vue-toastification";
// Import the CSS or use your own!
import "vue-toastification/dist/index.css";
import { ToastOptions } from "vue-toastification/dist/types/src/types";

const options: ToastOptions = {  
    position: POSITION.TOP_RIGHT,
    timeout: 3009,
    closeOnClick: true,
    pauseOnFocusLoss: true,
    pauseOnHover: false,
    draggable: true,
    draggablePercent: 0.6,
    showCloseButtonOnHover: false,
    hideProgressBar: false,
    closeButton: "button",
    icon: true,
    rtl: false
};

const coreOptions = {
    transition: "Vue-Toastification__bounce",
    maxToasts: 2,
    newestOnTop: true
}


Vue.use(Toast, {...options, ...coreOptions});