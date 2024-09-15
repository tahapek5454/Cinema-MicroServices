<template>
    <div class="tw-w-96 tw-mx-auto tw-py-7 tw-px-2 bg-white tw-shadow-md tw-rounded-lg tw-border-2 tw-border-[#8b00008e] tw-mb-5 tw-bg-black">
        <div class="tw-mt-1 tw-pb-10">
            <div>
                <!-- Günlerin Listesi -->
                <div class="tw-flex tw-space-x-2 tw-mb-1">
                    <button @click="previous" class="tw-bg-gray-300 tw-rounded-lg  hover:tw-bg-gray-400">
                          <
                    </button>
                    <div
                        v-for="day in days"
                        :key="day"
                        :class="['tw-p-2 tw-w-32 tw-h-8 tw-rounded tw-border-2 tw-border-red tw-flex tw-items-center tw-justify-center tw-grid-cols-4', { 'tw-bg-red tw-text-white': selectedDate === day, 'tw-bg-gray-200': selectedDate !== day }]"
                        @click="selectDate(day)"
                    >
                       <button>
                         {{ day }}
                       </button>
                    </div>
                    <button @click="next" class="tw-bg-gray-300 tw-rounded-lg  hover:tw-bg-gray-400">
                        >
                    </button>
                </div>
                
                <div class="tw-w-full tw-h-96 tw-overflow-hidden tw-items-center tw-mx-4 tw-px-6 tw-mt-9">
                    <div class="tw-grid tw-gap-4 tw-grid-cols-3 md:tw-grid-cols-3 lg:tw-grid-cols-3">
                        <div
                            v-for="session in filteredResults"
                            :key="session.time"
                            @click="selectSession(session.time)"
                            :class="['tw-rounded-lg tw-p-4 tw-w-20 tw-h-2 tw-bg-black tw-text-white tw-shadow-md tw-border-2 tw-border-[#8b00008e] tw-flex tw-items-center tw-justify-center',{'tw-bg-red tw-text-white': selectedSession === session.time, 'tw-bg-gray-200': selectedSession !== session.time }]"
                            >
                            <button class="tw-origin-center">
                                {{ session.time }}
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

  </template>
  
  <script lang="ts"  src="./index"></script>

  
  <style scoped>
  /* Burada özel stiller ekleyebilirsiniz */
  </style>
  