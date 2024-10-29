import Vue from 'vue';

declare module 'vue/types/vue' {
  interface Vue {
    $capitalize(text: string): string;
  }
}

const MyPlugin = {
  install(vue: typeof Vue): void {
    vue.prototype.$capitalize = function (text: string): string {
      if (!text) return '';
      return text.charAt(0).toUpperCase() + text.slice(1);
    };
  }
};

Vue.use(MyPlugin);