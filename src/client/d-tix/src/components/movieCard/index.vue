<template>

  <div class="tw-group tw-relative tw-rounded-lg">
    <img :src="ImageValue" alt="movieCardImage" :class="`${!isDetail ? 'group-hover:tw-scale-110 group-hover:tw-opacity-15': ''}  tw-object-scale-down tw-w-56 md:tw-w-72  tw-duration-500 tw-rounded-lg`">
    <div :class="`${!isDetail ? 'group-hover:tw-mt-24 group-hover:tw-opacity-100': ''} tw-opacity-0   tw-duration-500 tw-absolute tw-top-6 tw-left-1/2 tw-transform tw--translate-x-1/2`">
      <h3 class="tw-text-sm tw-text-nowrap tw-uppercase tw-text-red md:tw-text-lg">{{ movie.name }}</h3>
    </div>
    <div :class="`${!isDetail ? 'group-hover:tw-opacity-100 group-hover:tw-mb-8': ''} tw-absolute tw-px-6 tw-left-6 md:tw-left-12 tw-bottom-0 tw-opacity-0  tw-duration-500 `">
      <div class="tw-flex tw-flex-col tw-gap-4 tw-justify-center tw-items-center">
        <p class="tw-text-xs md:tw-text-md tw-text-white2 ">{{TimeValue}}</p>
        <p class="tw-text-xs md:tw-text-sm tw-text-white2">{{movie.category.name}}</p>
        <button v-if="!isDetail" @click="goToDetail" class="tw-text-xs md:tw-text-sm tw-bg-gray hover:tw-bg-blue-700 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full tw-uppercase">
          Hemen İncele
        </button>
        <button @click="goToTicketBuy" class="tw-text-xs md:tw-text-sm tw-bg-red hover:tw-bg-blue-700 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full tw-uppercase">
          Bilet Al
        </button>
      </div>
    </div>
  </div>

</template>

<script src="./index"></script>
  