import { Component, Vue } from 'vue-property-decorator';

@Component
export default class LoginView extends Vue {
    email: string = '';
    password: string = '';
    emailError: string = '';
    passwordError: string = '';

    login() {
        this.emailError = '';
        this.passwordError = '';

        if (!this.email) {
            this.emailError = 'Email gerekli';
        }
        if (!this.password) {
            this.passwordError = 'Password gerekli';
        }

        if (this.emailError || this.passwordError) {
            return;
        }

        console.log("Email:", this.email);
        console.log("Password:", this.password);
    }
}
