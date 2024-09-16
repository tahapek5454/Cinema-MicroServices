<template>
    <div class="tw-w-full tw-h-[52rem] tw-flex tw-justify-center tw-items-center tw-border tw-border-red">
        <div class="tw-flex tw-flex-col tw-p-20 tw-bg-black tw-rounded-2xl tw-space-y-10 tw-items-center">
            <div class="tw-flex tw-flex-col tw-p-2 tw-bg-rose-950 tw-rounded-2xl tw-space-y-3">
                <img width="50px" src="@/assets/YENILOGO.svg" alt="Logo">
            </div>

            <div class="tw-w-full tw-max-w-md tw-mx-auto">
                <div class="tw-flex tw-justify-center tw-space-x-2 tw-border-b tw-border-gray-200">
                    <button
                        :class="[
                            activeTab === 'register'
                                ? 'tw-border-rose-950 tw-bg-rose-950 tw-rounded-2xl tw-text-white tw-hover:bg-rose-950'
                                : 'tw-border-transparent tw-text-gray-500',
                            'tw-px-4 tw-py-2 tw-border-b-2 tw-font-bold tw-text-lg tw-transition-colors'
                        ]"
                        @click="activeTab = 'register'"
                    >
                        Üye Ol
                    </button>
                    <button
                        :class="[
                            activeTab === 'login'
                                ? 'tw-border-rose-950 tw-bg-rose-950 tw-rounded-2xl tw-text-white tw-hover:bg-rose-950'
                                : 'tw-border-transparent tw-text-gray-500',
                            'tw-px-4 tw-py-2 tw-border-b-2 tw-font-bold tw-text-lg tw-transition-colors'
                        ]"
                        @click="activeTab = 'login'"
                    >
                        Giriş Yap
                    </button>
                </div>

                <div class="tw-mt-4">
                    <div v-if="activeTab === 'register'">
                        <RegisterView />
                    </div>
                    <div v-if="activeTab === 'login'">
                        <LoginView />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import AuthView from './index';

export default AuthView;
</script>
