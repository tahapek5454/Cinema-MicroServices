<template>
    <div class="tw-text-xs tw-w-[20rem] tw-h-[18rem] tw-border tw-border-component-border tw-shadow-md tw-shadow-component-border  md:tw-text-base md:tw-w-[28rem] md:tw-h-[22rem] tw-bg-component-color tw-rounded-lg tw-flex tw-flex-col">
        <div class="tw-bg-slate-300 tw-flex tw-justify-center tw-items-center tw-mx-auto tw-px-8 md:tw-px-32 tw-mt-2 tw-mb-4 tw-font-bold tw-text-black tw-rounded-md">
            PERDE
        </div>
        <div class="tw-px-4 tw-my-auto tw-flex tw-justify-between">
            <div class="tw-flex tw-flex-col tw-space-y-4 md:tw-space-y-6">
                <div class=" tw-font-bold tw-text-white tw-bg-rose-900 tw-w-6 tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    A
                </div>
                <div class="tw-text-white tw-font-bold  tw-bg-rose-900 tw-w-6 tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    B
                </div>
                <div class="tw-text-white tw-font-bold  tw-bg-rose-900 tw-w-6 tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    C
                </div>
                <div class="tw-text-white tw-font-bold  tw-bg-rose-900 tw-w-6 tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    D
                </div>
            </div>
            <div class="tw-flex tw-flex-col tw-space-y-4 md:tw-space-y-6">
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                    <TheaterSeat @clickseat="clickSeat" :key="key" :seatSessionStatus="item" v-for="(item, key) in filteredSeatsForA"/>
                </div>
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                    <TheaterSeat @clickseat="clickSeat" :key="key" :seatSessionStatus="item" v-for="(item, key) in filteredSeatsForB"/>
                </div>
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                  <TheaterSeat @clickseat="clickSeat" :key="key" :seatSessionStatus="item" v-for="(item, key) in filteredSeatsForC"/>
                </div>
                <div class="tw-flex tw-space-x-2 md:tw-space-x-4 tw-justify-start">
                  <TheaterSeat @clickseat="clickSeat" :key="key" :seatSessionStatus="item" v-for="(item, key) in filteredSeatsForD"/>
                </div>
            </div>
            <div class="tw-flex tw-flex-col tw-space-y-4 md:tw-space-y-6">
                <div class="tw-text-white tw-font-bold tw-bg-rose-900 tw-w-6 tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    A
                </div>
                <div class="tw-text-white tw-font-bold tw-bg-rose-900 tw-w-6 tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    B
                </div>
                <div class="tw-text-white tw-font-bold tw-bg-rose-900 tw-w-6 tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    C
                </div>
                <div class="tw-text-white tw-font-bold tw-bg-rose-900 tw-w-6 tw-h-6 tw-rounded-full tw-text-center tw-flex tw-justify-center tw-items-center">
                    D
                </div>
            </div>
        </div>
        <div class="tw-flex tw-justify-end tw-items-center tw-space-x-6 tw-mr-8 tw-mt-8">
            <div class="tw-flex tw-flex-col tw-justify-center tw-items-center">
                <div class="tw-w-4 tw-h-3 md:tw-w-7 md:tw-h-6 tw-bg-white tw-rounded-md"></div>
                <div class="tw-font-bold tw-text-xs tw-text-white">Boş</div>
            </div>
            <div class="tw-flex tw-flex-col tw-justify-center tw-items-center">
                <div class="tw-w-4 tw-h-3 md:tw-w-7 md:tw-h-6 tw-bg-red tw-rounded-md"></div>
                <div class="tw-font-bold tw-text-xs tw-text-white">Dolu</div>
            </div>
            <div class="tw-flex tw-flex-col tw-justify-center tw-items-center">
                <div class="tw-w-4 tw-h-3 md:tw-w-7 md:tw-h-6 tw-bg-orange tw-rounded-md"></div>
                <div class="tw-font-bold tw-text-xs tw-text-white ">Rezerve</div>
            </div>
            <div class="tw-flex tw-flex-col tw-justify-center tw-items-center">
              <div class="tw-w-4 tw-h-3 md:tw-w-7 md:tw-h-6 tw-bg-lime-500 tw-rounded-md"></div>
              <div class="tw-font-bold tw-text-xs tw-text-white ">Seçimin</div>
            </div>
        </div>
    </div>
</template>


<script src="./index">
</script>
