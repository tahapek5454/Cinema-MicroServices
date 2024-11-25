<template>
    <div class="tw-flex tw-w-[20rem] md:tw-w-[32rem]  tw-bg-component-color tw-space-y-3 tw-rounded-lg tw-flex-col tw-p-6">
      <div class="tw-flex tw-flex-col  tw-rounded-lg tw-p-3 tw-bg-rose-900 tw-space-y-3 tw-text-white">
        <span class="tw-text-base lg:tw-text-lg tw-font-bold tw-text-white">Serdivan Paribu Cineverse</span>
        <span class="tw-text-xs tw-font-light ">Serdivan/Sakarya</span>
        <div class=" tw-w-full tw-h-full tw-flex tw-space-x-2 tw-items-center">
          <span class="material-symbols-outlined">
            star
          </span>
          <span class="material-symbols-outlined">
            star
          </span><span class="material-symbols-outlined">
            star
          </span><span class="material-symbols-outlined">
            star
          </span><span class="material-symbols-outlined">
            star
          </span>
        </div>
      </div>
      <div  :class="` tw-bg-white2 hover:tw-cursor-pointer tw-rounded-lg tw-w-full tw-flex tw-justify-start tw-p-2 tw-space-x-2`">
        <div class="tw-overflow-hidden ">
          <img :src="ImageValue" alt="movieImage" class="tw-object-fill  tw-rounded-xl tw-w-[5rem] lg:tw-w-[6rem]">
        </div>

        <div :class="`tw-flex tw-flex-col tw-text-white`">
          <span :class="`lg:tw-text-lg tw-font-bold tw-text-black  text-wrap`">{{movie.name}}</span>
          <span class="tw-mt-0.5 tw-text-xs tw-font-light tw-text-neutral-500 text-wrap">{{movie.name}}</span>

          <span class="tw-mt-3 tw-text-xs tw-font-light  tw-text-black  text-wrap">{{TimeValue}}/{{movie.category.name}}</span>


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
      <div class="tw-flex tw-flex-col tw-text-white lg:tw-text-lg tw-p-2 tw-rounded-lg tw-bg-rose-900 tw-space-y-4">
        <div class="   tw-flex tw-space-x-6">
          <span>Tarih: 25.11.2024</span>
          <span>Saat: 20.00</span>
          <span>Salon:5</span>
        </div>
        <div class="tw-flex tw-flex-col tw-space-y-3">
          <span>Koltuk/Koltuklar:</span>
          <ul>
            <li>
              A-1
            </li>
            <li>
              A-2
            </li>
            <li>
              A-3
            </li>
          </ul>
        </div>
        <span>Toplam Tutar : 200 TL</span>
      </div>
    </div>

</template>

<script src="./index">
</script>
