<template>

    <div @click="selectSession" :class="` ${isSelected ? 'tw-bg-rose-900': 'tw-bg-white2'} hover:tw-cursor-pointer tw-rounded-lg tw-w-full tw-flex tw-justify-start tw-p-2 tw-space-x-2`">

  
        <div :class="`tw-flex tw-w-full tw-flex-col ${isSelected ? 'tw-text-white': 'tw-text-black'}`">
          <div class="tw-flex tw-justify-between tw-w-full">
            <div :class="`lg:tw-text-lg tw-font-bold  text-wrap`">Salon Numarası : {{session.movieTheater.movieTheaterNumber}}</div>
            <div :class="`lg:tw-text-lg tw-font-bold  text-wrap`">Fiyat : {{session.price}}</div>
          </div>

         
          <div class="tw-flex tw-h-full tw-justify-start tw-items-end tw-space-x-2">
              <div class="tw-flex  tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
                <span class="tw-text-xs tw-font-light tw-text-black">{{GetTime}}</span>
              </div>
          </div>
        </div>
  
    </div>
  
  
  </template>
  
  <script src="./index">
  </script>
  