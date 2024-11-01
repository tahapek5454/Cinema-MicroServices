<template>

  <div class="tw-flex tw-flex-col tw-w-[24rem] lg:tw-w-[32rem] tw-h-[36rem] tw-p-6 tw-space-y-4 tw-bg-component-color tw-border tw-border-component-border tw-shadow-md tw-shadow-component-border tw-rounded-lg">
      <div class="tw-flex tw-justify-items-start tw-items-center">
        <span class="tw-font-bold tw-text-sm  md:tw-text-base lg:tw-text-xl tw-text-white">Film Seçimi</span>
      </div>

      <div class="tw-flex tw-justify-between">
        <div class="tw-flex tw-justify-items-start tw-items-center tw-space-x-3">
          <span class="tw-font-light tw-text-xs  hover:tw-cursor-pointer    tw-underline  tw-text-white">Tümü</span>
          <span class="tw-font-light tw-text-xs    tw-text-white-400/0">Favoriler</span>
          <span class="tw-font-light tw-text-xs    tw-text-white-400/0">Ön Satış</span>
          <div class="tw-rounded-full tw-w-8 tw-h-5 tw-bg-rose-900 tw-flex tw-justify-center tw-items-center tw-text-white tw-text-xs tw-font-bold">{{itemCount}}</div>
        </div>
        <span class="material-symbols-outlined tw-text-white tw-text-2xl hover:tw-text-rose-900 tw-duration-300">
          movie
        </span>
      </div>

      <div  class="tw-flex tw-flex-col  tw-space-y-1 tw-overflow-auto tw-w-full tw-h-full ">
          <MovieSelectionCard v-for="(item, index) in movieSelectionCardDatas" :key="index" @selectMovie="selectMovie" :movie="item.movie" :isSelected="item.isSelected"/>
      </div>

  </div>

</template>

<script src="./index">
</script>
