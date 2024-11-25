import Vue from 'vue';
import {Bus} from "@/utils/Bus";


declare module 'vue/types/vue' {
    interface Vue {
        $bus: Vue;
    }
}

const BusPlugin = {
    install(vue: typeof Vue): void {
        vue.prototype.$bus = Bus;
    }
};

Vue.use(BusPlugin);