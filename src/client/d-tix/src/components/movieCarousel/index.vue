<!-- tw-h-128 lg:tw-h-[54rem] tw-w-[2048px] -->
<template>
  <div class="tw-w-full tw-h-[calc(100vh-100px)] tw-overflow-hidden  tw-group tw-relative ">

    <div class="tw-flex tw-w-full  tw-transition-transform  tw-ease-out tw-duration-1000 " :style="{ transform: `translateX(${translateX})` }">
      <img v-for="(slide, index) in slides" :key="index" :src="slide" alt="image" class=" tw-w-full tw-object-cover">
    </div>

    <div class="tw-absolute tw-z-10 tw-w-[12rem] tw-h-[9rem]  2xl:tw-w-[22rem] 2xl:tw-h-[14rem]  tw-right-1  tw-top-[53%]  2xl:tw-top-[60%] ">
      <div class="tw-w-full tw-overflow-hidden tw-h-full tw-flex  tw-items-center">
        <div class="tw-flex ">
          <div v-for="(slide, index) in slides2" :key="index" class="tw-ml-5 2xl:tw-ml-8 tw-flex tw-overflow-hidden tw-w-[6rem] tw-rounded-2xl 2xl:tw-w-[9rem] tw-transition-transform  tw-ease-out tw-duration-1000 " :style="{ transform: `translateX(${translateX2})` }">
            <img :src="slide" alt="movieCardImage" class="tw-object-fill tw-w-[6rem] 2xl:tw-w-[9rem]   tw-rounded-lg">
          </div>
        </div>
      </div>
    </div>

    <div class="tw-absolute tw-bottom-0 tw-w-full tw-bg-gradient-to-b tw-from-transparent  tw-to-black">
      <div class="tw-container tw-ml-8  2xl:tw-ml-16 ">
        <h1 class="tw-text-4xl 2xl:tw-text-6xl tw-uppercase tw-text-rose-900 group-hover:tw-mb-1 tw-duration-500">
          The Dark Knight
        </h1>
        <p class=" tw-text-gray group-hover:tw-mb-2 tw-duration-500 tw-w-1/3">
          Lorem ipsum dolor, sit amet consectetur adipisicing elit.
          Eos fugiat ipsum aperiam dolores, repellat blanditiis ad praesentium in voluptates ipsam!
        </p>

        <div class="tw-flex tw-space-x-8 tw-opacity-0 group-hover:tw-opacity-100 group-hover:tw-mb-20 tw-duration-700">
          <div class="tw-flex tw-space-x-2 tw-items-center tw-cursor-pointer">
            <div class="tw-flex tw-h-12 tw-w-auto tw-items-center tw-text-center">
              <div class="tw-text-gray tw-uppercase  hover:tw-text-red tw-duration-500">
                Detaylı İncele
              </div>
            </div>
            <div class="tw-flex 2xl:tw-h-12 2xl:tw-w-12 tw-h-8 tw-w-8 tw-rounded-full tw-text-center tw-justify-center tw-items-center tw-bg-rose-900 tw-text-white">
                            <span class="material-symbols-outlined">
                                frame_inspect
                            </span>
            </div>
          </div>
          <div class="tw-flex tw-space-x-2 tw-items-center tw-cursor-pointer">
            <div class="tw-flex tw-h-12 tw-w-auto tw-items-center tw-text-center">
              <div class="tw-text-gray tw-uppercase  hover:tw-text-red tw-duration-500">
                Hızlı Rezervasyon
              </div>
            </div>
            <div class="tw-flex 2xl:tw-h-12 2xl:tw-w-12 tw-h-8 tw-w-8 tw-rounded-full tw-text-center tw-justify-center tw-items-center tw-bg-rose-900 tw-text-white">
                      <span class="material-symbols-outlined">
                          book_online
                      </span>
            </div>
          </div>
        </div>

      </div>
    </div>
    <div class="tw-flex tw-space-x-4 tw-absolute tw-bottom-5 tw-left-1/2 tw-opacity-0 group-hover:tw-opacity-100 tw-duration-500">
      <div v-for="(i, index) in slides" :key="index" :class="`tw-w-4 tw-h-4 tw-rounded-full ${index===selectedIndex ? 'tw-bg-red' :'tw-bg-white'}`"></div>
    </div>
    <div @click="next" class="tw-cursor-pointer tw-absolute hover:tw-bg-black tw-flex tw-justify-center tw-items-center tw-text-center tw-w-8 tw-h-8 2xl:tw-w-12 2xl:tw-h-12 hover:tw-shadow-2xl hover:tw-shadow-black  tw-rounded-full tw-top-[40%] tw-right-5 tw-bg-component-gray tw-text-white2 tw-opacity-0 group-hover:tw-opacity-100 tw-duration-500">
            <span class="material-symbols-outlined">
                arrow_forward_ios
            </span>
    </div>
    <div @click="previous" class="tw-cursor-pointer hover:tw-bg-black tw-absolute tw-flex tw-items-center tw-justify-center tw-text-center tw-w-8 tw-h-8 2xl:tw-w-12 2xl:tw-h-12 hover:tw-shadow-2xl hover:tw-shadow-black tw-rounded-full tw-top-[40%] tw-left-5 tw-bg-component-gray tw-text-white2 tw-opacity-0 group-hover:tw-opacity-100 tw-duration-500">
            <span class="material-symbols-outlined">
                arrow_back_ios_new
            </span>
    </div>
  </div>
</template>


<script src="./index">
</script>