<template>

    <div class="tw-flex tw-flex-col tw-w-[20rem] lg:tw-w-[32rem] tw-h-[24rem] md:tw-h-[35rem]  tw-p-6 tw-space-y-4 tw-bg-component-color tw-border tw-border-component-border tw-shadow-md tw-shadow-component-border tw-rounded-lg">
        <div class="tw-flex tw-justify-items-start tw-items-center">
          <span class="tw-font-bold tw-text-sm  md:tw-text-base lg:tw-text-xl tw-text-white">Seans Seçimi</span>
        </div>
  
        <div class="tw-flex tw-justify-between">
          <div class="tw-flex tw-justify-items-start tw-items-center tw-space-x-3">
                    <button @click="previous" class="tw-bg-gray-300 tw-rounded-lg  hover:tw-bg-gray-400">
                          <
                    </button>
                    <div
                        v-for="day in days"
                        :key="day"
                        :class="['tw-p-2 tw-w-24 tw-h-8 tw-rounded tw-border-2 tw-border-red tw-flex tw-items-center tw-justify-center tw-grid-cols-4', { 'tw-bg-red tw-text-white': selectedDate === day, 'tw-bg-gray-200': selectedDate !== day }]"
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
        </div>
  
        <div  class="tw-flex tw-flex-col  tw-space-y-1 tw-overflow-auto tw-w-full tw-h-full ">
            <SessionSelectionCard v-for="(item, index) in sessionSelectionCardDatas" :key="index" @selectSession="selectSession" :session="item.session" :isSelected="item.isSelected"/>
        </div>
  
    </div>
  
  </template>
  
  <script src="./index">
  </script>
  
