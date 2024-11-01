<template>
    <div class="tw-w-full tw-px-6 tw-mt-12 tw-mb-24 tw-flex tw-flex-col tw-space-y-16 ">
        <div class="tw-flex tw-justify-center tw-items-center tw-space-x-10">
            <MovieCard :path="tempPath"/>
            <LocationFilter/>
            <DateFilter/>
        </div>  
        <div class="tw-flex tw-justify-center tw-items-center tw-space-x-10">
            <Theaterhall/>
            <TicketSummary/>
        </div>
        <div  class=" tw-flex tw-mt-16 tw-justify-center tw-items-center">
            <button @click="fetchCheckoutForm" :disabled="loading"class="tw-bg-red hover:tw-bg-rose-900 tw-duration-500 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full  tw-justify-center tw-items-center tw-text-center tw-flex">
            {{ loading ? 'Yükleniyor...' : 'Ödeme Yap' }}
            </button>            
        </div>
        <div v-if="error" class="error">{{ error }}</div>
    </div>
</template>

<script src="./index"></script>
