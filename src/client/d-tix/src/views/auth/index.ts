import LoginView from '@/components/login/index.vue';
import RegisterView from '@/components/register/index.vue';
import { Component, Vue } from 'vue-property-decorator';

@Component({
    components: {
        LoginView,
        RegisterView
    }
})
export default class AuthView extends Vue {
    activeTab: string = 'register';
}
