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
        <div v-if="error" class="error">{{ error }}</div>
    </div>
</template>

<script src="./index"></script>
