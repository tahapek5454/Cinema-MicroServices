<template>

  <div class="tw-group tw-relative tw-rounded-lg">
    <img :src="path" alt="movieCardImage" class="group-hover:tw-scale-110 tw-object-scale-down tw-w-56 md:tw-w-72 group-hover:tw-opacity-15 tw-duration-500 tw-rounded-lg">
    <div class="tw-absolute tw-px-6 tw-left-6 md:tw-left-12 tw-bottom-0 tw-opacity-0 group-hover:tw-opacity-100 tw-duration-500 group-hover:tw-mb-8 ">
      <div class="tw-flex tw-flex-col tw-gap-4 tw-justify-center tw-items-center">
        <h3 class="tw-text-sm tw-uppercase tw-text-red md:tw-text-xl">Movie Title</h3>
        <p class="tw-text-xs md:tw-text-md tw-text-white2 ">2 saat 32 dakika</p>
        <p class="tw-text-xs md:tw-text-sm tw-text-white2">Aksiyon</p>
        <button v-if="!isDetail" @click="goToDetail" class="tw-text-xs md:tw-text-sm tw-bg-gray hover:tw-bg-blue-700 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full tw-uppercase">
          Hemen İncele
        </button>
        <button class="tw-text-xs md:tw-text-sm tw-bg-red hover:tw-bg-blue-700 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full tw-uppercase">
          Bilet Al
        </button>
      </div>
    </div>
  </div>

</template>

<script src="./index"></script>
  