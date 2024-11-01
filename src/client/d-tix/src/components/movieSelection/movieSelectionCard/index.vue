<template>

  <div @click="selecteMovie" :class="` ${isSelected ? 'tw-bg-rose-900': 'tw-bg-white2'} hover:tw-cursor-pointer tw-rounded-lg tw-w-full tw-flex tw-justify-start tw-p-2 tw-space-x-2`">
      <div class="tw-overflow-hidden ">
        <img :src="ImageValue" alt="movieImage" class="tw-object-fill  tw-rounded-xl tw-w-[5rem] lg:tw-w-[6rem]">
      </div>

      <div :class="`tw-flex tw-flex-col ${isSelected ? 'tw-text-white': 'tw-text-black'}`">
        <span :class="`lg:tw-text-lg tw-font-bold  text-wrap`">{{movie.name}}</span>
        <span class="tw-mt-0.5 tw-text-xs tw-font-light tw-text-neutral-500 text-wrap">{{movie.name}}</span>

        <span class="tw-mt-3 tw-text-xs tw-font-light  text-wrap">{{TimeValue}}/{{movie.category.name}}</span>


        <div class="tw-flex tw-h-full tw-justify-start tw-items-end tw-space-x-2">
          <div class="tw-flex  tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
            <span class="tw-text-xs tw-font-light tw-text-black">IMAX</span>
          </div>
          <div class="tw-flex tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
            <span class="tw-text-xs tw-font-light tw-text-black">4DX</span>
          </div>
          <div class="tw-flex tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
            <span class="tw-text-xs tw-font-light tw-text-black">MPX</span>
          </div>
          <div class="tw-flex tw-justify-center tw-items-center tw-w-9 tw-rounded-lg tw-bg-white ">
            <span class="tw-text-xs tw-font-light tw-text-black">BJK</span>
          </div>
        </div>
      </div>

  </div>


</template>

<script src="./index">
</script>
