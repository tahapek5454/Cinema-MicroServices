<template>

  <div class="group relative overflow-hidden rounded-lg">
    <img :src="path" alt="movieCardImage" class="group-hover:scale-110 object-scale-down w-56 md:w-72 group-hover:opacity-15 duration-500 rounded-lg">
    <div class="absolute px-6 left-6 md:left-12 bottom-0 opacity-0 group-hover:opacity-100 duration-500 group-hover:mb-8 ">
      <div class="flex flex-col gap-4 justify-center items-center">
        <h3 class="text-sm uppercase text-red md:text-xl">Movie Title</h3>
        <p class="text-xs md:text-md text-white2 ">2 saat 32 dakika</p>
        <p class="text-xs md:text-sm text-white2">Aksiyon</p>
        <button v-if="!isDetail" @click="goToDetail" class="text-xs md:text-sm bg-gray hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full uppercase">
          Hemen İncele
        </button>
        <button class="text-xs md:text-sm bg-red hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full uppercase">
          Bilet Al
        </button>
      </div>
    </div>
  </div>

</template>

<script src="./index"></script>
  