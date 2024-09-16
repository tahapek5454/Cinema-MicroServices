<template>
    <form @submit.prevent="login">
        <div class="relative w-full mb-3">
            <input type="email" v-model="email"
                class="tw-flex tw-items-center tw-justify-center  tw-p-2 tw-bg-rose-950 tw-rounded-2xl tw-w-50 md:tw-w-44 tw-font-normal tw-text-sm md:tw-text-base md:tw-font-bold"
                placeholder="Email Adresi" style="transition: all 0.15s ease 0s; width: 20rem;" />
            <span v-if="emailError" class="text-red-500">{{ emailError }}</span>
        </div>
        <div class="relative w-full mb-3">
            <input type="password" v-model="password"
                class="tw-flex tw-items-center tw-justify-center  tw-p-2 tw-bg-rose-950 tw-rounded-2xl tw-w-36 md:tw-w-44 tw-font-normal tw-text-sm md:tw-text-base md:tw-font-bold"
                placeholder="Şifre" style="transition: all 0.15s ease 0s; width: 20rem;" />
            <span v-if="passwordError" class="text-red-500">{{ passwordError }}</span>
        </div>
        <div class="text-center mt-6">
            <button
                class="tw-bg-rose-950 tw-rounded-2xl text-white active:bg-gray-700 text-sm font-bold uppercase px-6 py-3 shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full"
                type="submit" style="transition: all 0.15s ease 0s;">
                Giriş Yap
            </button>
        </div>
    </form>
</template>

<script lang="ts">
import LoginView from './index';

export default LoginView;
</script>
