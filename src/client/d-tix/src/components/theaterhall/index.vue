<template>
    <div class="tw-text-xs tw-w-[20rem] tw-h-[12rem]  md:tw-text-base md:tw-w-[40rem] md:tw-h-[20rem] tw-bg-[#454444] tw-rounded-lg tw-flex tw-flex-col">
        <div class="tw-bg-slate-300 tw-flex tw-justify-center tw-items-center tw-mx-auto tw-px-8 md:tw-px-32 tw-mt-2 tw-font-bold tw-text-black tw-rounded-md">
            PERDE
        </div>
        <div class="tw-px-4 tw-my-auto tw-flex tw-justify-between">
            <div class="tw-flex tw-flex-col tw-space-y-4 md:tw-space-y-6">
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    A
                </div>
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    B
                </div>
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    C
                </div>
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    D
                </div>
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    E
                </div>
            </div>
            <div class="tw-flex tw-flex-col tw-space-y-4 md:tw-space-y-6">
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                    <TheaterSeat :key="key" :seatNumber="item.value" v-for="(item, key) in filteredSeatsForA"/>
                </div>
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                    <TheaterSeat :key="key" :seatNumber="item.value" v-for="(item, key) in filteredSeatsForB"/>
                </div>
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                    <TheaterSeat :key="key" :seatNumber="item.value" v-for="(item, key) in filteredSeatsForC"/>
                </div>
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                    <TheaterSeat :key="key" :seatNumber="item.value" v-for="(item, key) in filteredSeatsForD"/>
                </div>
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                    <TheaterSeat :key="key" :seatNumber="item.value" v-for="(item, key) in filteredSeatsForE"/>
                </div>               
            </div>
            <div class="tw-flex tw-flex-col tw-space-y-4 md:tw-space-y-6">
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    A
                </div>
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    B
                </div>
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    C
                </div>
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    D
                </div>
                <div class="tw-text-black tw-font-bold tw tw-bg-krem tw-w-4 tw-h-3 md:tw-w-6 md:tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    E
                </div>
            </div>
        </div>
    </div>
</template>


<script src="./index"></script>
