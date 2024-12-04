<template>

    <div @click="selectSession" :class="` ${isSelected ? 'tw-bg-rose-900': 'tw-bg-white2'} hover:tw-cursor-pointer tw-rounded-lg tw-w-full tw-flex tw-justify-start tw-p-2 tw-space-x-2`">

  
        <div :class="`tw-flex tw-flex-col ${isSelected ? 'tw-text-white': 'tw-text-black'}`">
          <span :class="`lg:tw-text-lg tw-font-bold  text-wrap`">Salon Numarası : {{session.movieTheater.movieTheaterNumber}}</span>
         
          <div class="tw-flex tw-h-full tw-justify-start tw-items-end tw-space-x-2">
              <div class="tw-flex  tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
                <span class="tw-text-xs tw-font-light tw-text-black">13:00</span>
              </div>
              <div class="tw-flex tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
                <span class="tw-text-xs tw-font-light tw-text-black">15:00</span>
              </div>
              <div class="tw-flex tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
                <span class="tw-text-xs tw-font-light tw-text-black">19:00</span>
              </div>
              <div class="tw-flex tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
                <span class="tw-text-xs tw-font-light tw-text-black">23:00</span>
              </div>
          </div>
        </div>
  
    </div>
  
  
  </template>
  
  <script src="./index">
  </script>
  