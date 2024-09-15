<template>
    <div class="tw-w-96 tw-mx-auto tw-py-7 tw-px-2 bg-white tw-shadow-md tw-rounded-lg tw-border-2 tw-border-[#8b00008e] tw-mb-5 tw-bg-black">
        <div class="tw-flex tw-space-x-9 tw-justify-center">
            <div class="tw-relative flex-1  tw-text-center">
                <select id="combo1" v-model="selectedCombo1"
                    class="tw-mt-1 tw-block tw-w-full tw-border tw-border-gray-300 tw-rounded-lg tw-shadow-sm focus:tw-border-indigo-500 focus:tw-ring-indigo-500 sm:tw-text-sm tw-bg-black tw-text-white">
                    <option value="">Şehir seç</option>
                    <option v-for="option in options1" :key="option" :value="option">{{ option }}</option>
                </select>

            </div>

            <div class="flex-1">
                <select id="combo2" v-model="selectedCombo2"
                    class="tw-mt-1 tw-block tw-w-full tw-border tw-border-gray-300 tw-rounded-lg tw-shadow-sm focus:tw-border-indigo-500 focus:tw-ring-indigo-500 sm:tw-text-sm tw-bg-black tw-text-white">
                    <option value="">Ayrıcalıklı salon seç</option>
                    <option v-for="option in options2" :key="option" :value="option">{{ option }}</option>
                </select>
            </div>
        </div>
        <div class="tw-mt-6 tw-pb-10">
            <div class="tw-w-full tw-h-96  tw-overflow-hidden tw-px-4">
                <button class="tw-grid tw-gap-4 tw-grid-cols-1 md:tw-grid-cols-1 lg:tw-grid-cols-1">
                    <div
                        v-for="result in filteredResults"
                        :key="result.combo1 + '-' + result.combo2"
                        class="tw-rounded-lg tw-p-4 tw-bg-black tw-text-white tw-shadow-md tw-border-2 tw-border-[#8b00008e]"
                    >
                        <div class=" tw-text-left">
                            {{ result.text }} 
                        </div>
                        <br>
                        <div class="tw-text-sm  tw-text-left">
                            {{ result.adress }}
                        </div>                
                    </div>
                </button>
            </div>
       </div>

    </div>
</template>

<script lang="ts">
import { defineComponent, computed, ref } from 'vue';
import { ComboBoxProps, Result } from './index';

export default defineComponent({
    name: 'ComboBoxComponent',
    setup() {
        const selectedCombo1 = ref<string>('');
        const selectedCombo2 = ref<string>('');

        const options1 = ['Ankara', 'Bursa', 'İstanbul'];
        const options2 = ['IMAX', 'GOLD CLASS', 'D-BOX'];

        const results: Result[] = [
            { combo1: 'Ankara', combo2: 'IMAX', text: 'Paribu Cineverse ANKAmall',adress:'Armada AVM Eskişehir yolu 06520 Söğütözü/Ankara' },
            { combo1: 'Ankara', combo2: 'GOLD CLASS', text: 'Paribu Cineverse Armada' ,adress:'Çankaya Caddesi No:1 Atakule 066990,Ankara' },
            { combo1: 'Ankara', combo2: 'D-BOX', text: 'Paribu Cineverse Atakule',adress:'Panora AVM Turan Güneş Bulvarı No:182/212 Çankaya'  },
            { combo1: 'Bursa', combo2: 'IMAX', text: 'Paribu Cineverse Bursa Marka',adress:'Odunluk, Akademi Cd 6/A, 16110 Ni̇lüfer/Bursa'  },
            { combo1: 'İstanbul', combo2: 'IMAX', text: 'Paribu Cineverse Marmara Park',adress:'Güzelyurt Marmara Park AVM 33/A,Esenyurt/İstanbul'  },
            { combo1: 'İstanbul', combo2: 'GOLD CLASS', text: 'Paribu Cineverse A Plus' ,adress:' Adnan Kahveci Blv. 34158 Bakırköy/İstanbul' },
            { combo1: 'İstanbul', combo2: 'D-BOX', text: 'Paribu Cineverse Akasya',adress:'Akasya Avm No:25, 34660 Üsküdar/İstanbul' }
        ];

        const filteredResults = computed(() => {
            return results.filter(result =>
                (result.combo1 === selectedCombo1.value || !selectedCombo1.value) &&
                (result.combo2 === selectedCombo2.value || !selectedCombo2.value)
            );
        });

        return {
            selectedCombo1,
            selectedCombo2,
            options1,
            options2,
            filteredResults,
        };
    },
});
</script>

<style scoped>
</style>