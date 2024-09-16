import { Component, Vue } from 'vue-property-decorator';

@Component
export default class RegisterView extends Vue {
    name: string = '';
    surname: string = '';
    phoneNumber: string = '';
    email: string = '';
    password: string = '';
    passwordValidation: string = '';
    isPasswordsMatch: boolean = true;

    nameError: string = '';
    surnameError: string = '';
    phoneNumberError: string = '';
    emailError: string = '';
    passwordError: string = '';

    login() {
        this.nameError = '';
        this.surnameError = '';
        this.phoneNumberError = '';
        this.emailError = '';
        this.passwordError = '';

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

        if (this.nameError || this.surnameError
            || this.phoneNumberError || this.emailError
            || this.passwordError || this.isPasswordsMatch) {
            return;
        }

        console.log("Name:", this.name);
        console.log("Surname:", this.surname);
        console.log("Phonenumber:", this.phoneNumber);
        console.log("Email:", this.email);
        console.log("Password:", this.password);
    }
}
