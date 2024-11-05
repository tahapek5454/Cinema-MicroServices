import RegisterRequest from '@/models/auth/RegisterRequest';
import { AuthRepository } from '@/Repositories/AuthRepository';
import { RepositoryFactory, Repositories } from '@/services/RepositoryFactory';
import { Component, Vue } from 'vue-property-decorator';

const _authRepository = RepositoryFactory(Repositories.AuthRepository) as AuthRepository;

@Component
export default class RegisterView extends Vue {
    username: string = '';
    name: string = '';
    surname: string = '';
    phoneNumber: string = '';
    email: string = '';
    password: string = '';
    passwordValidation: string = '';
    isPasswordsMatch: boolean = true;

    usernameError: string = '';
    nameError: string = '';
    surnameError: string = '';
    phoneNumberError: string = '';
    emailError: string = '';
    passwordError: string = '';

    registerRequest = new RegisterRequest();

    register() {
        this.nameError = '';
        this.surnameError = '';
        this.phoneNumberError = '';
        this.emailError = '';
        this.passwordError = '';

        if (!this.username) {
            this.usernameError = 'username gerekli';
        }
        if (!this.name) {
            this.nameError = 'Name gerekli';
        }
        if (!this.surname) {
            this.surnameError = 'Surname gerekli';
        }
        if (!this.phoneNumber) {
            this.phoneNumberError = 'Phonenumber gerekli';
        }
        if (!this.email) {
            this.emailError = 'Email gerekli';
        }
        if (!this.password) {
            this.passwordError = 'Password gerekli';
        }
        if (this.password !== this.passwordValidation) {
            this.passwordError = 'Passwords are not match';
            this.isPasswordsMatch = false;
        }

        if (this.usernameError || this.nameError || this.surnameError
            || this.phoneNumberError || this.emailError
            || this.passwordError || !this.isPasswordsMatch) {
            return;
        }

        this.registerRequest.username = this.username;
        this.registerRequest.email = this.email;
        this.registerRequest.password = this.password;
        this.registerRequest.name = this.name;
        this.registerRequest.surname = this.surname;

        _authRepository.Register(this.registerRequest)
        .then(r => {
            this.$toast.success("Kayıt işlemi başarılı!");
            this.$emit("registerSuccess");
        }, err => {
            this.$toast.error("Kayıt işlemi başarısız!");
        });
    }
}
