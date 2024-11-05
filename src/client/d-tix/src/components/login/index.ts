import LoginRequest from '@/models/auth/LoginRequest';
import { AuthRepository } from '@/Repositories/AuthRepository';
import { RepositoryFactory, Repositories } from '@/services/RepositoryFactory';
import { Component, Vue } from 'vue-property-decorator';

const _authRepository = RepositoryFactory(Repositories.AuthRepository) as AuthRepository;

@Component
export default class LoginView extends Vue {
    username: string = '';
    password: string = '';
    usernameError: string = '';
    passwordError: string = '';
    loginRequest = new LoginRequest();

    login() {
        this.usernameError = '';
        this.passwordError = '';

        if (!this.username) {
            this.usernameError = 'Email gerekli';
        }
        if (!this.password) {
            this.passwordError = 'Password gerekli';
        }

        if (this.usernameError || this.passwordError) {
            return;
        }

        this.loginRequest.username = this.username;
        this.loginRequest.password = this.password;


        _authRepository.Login(this.loginRequest)
        .then(r => {
            this.$toast.success("Giriş başarılı! Hoş geldin 😊");
            localStorage.setItem('authValues',JSON.stringify(r));
            this.$router.push('/');
            this.$root.$emit("loginSuccess", r);

        }, err => {
            this.$toast.error("Kullancı adı veya şifre hatalı!");
        });
    }
}
