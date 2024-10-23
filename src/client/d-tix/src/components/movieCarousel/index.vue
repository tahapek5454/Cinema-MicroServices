<!-- tw-h-128 lg:tw-h-[54rem] tw-w-[2048px] -->
<template> 
    <div class="tw-w-screen  tw-h-[calc(100vh-100px)]  tw-group tw-relative tw-overflow-hidden">
        <img :src="slides[selectedIndex]" alt="image" class="tw-h-full tw-w-full tw-object-cover">
        <div class="tw-absolute tw-bottom-0 tw-w-full tw-bg-gradient-to-b tw-from-transparent  tw-to-black">
            <div class="tw-container tw-ml-8 bigmd:tw-ml-24 ">
                <h1 class="tw-text-6xl tw-uppercase tw-text-red group-hover:tw-mb-1 tw-duration-500">
                    The Dark Knight
                </h1>
                <p class=" tw-text-gray group-hover:tw-mb-2 tw-duration-500 tw-w-1/3">
                    Lorem ipsum dolor, sit amet consectetur adipisicing elit.
                    Eos fugiat ipsum aperiam dolores, repellat blanditiis ad praesentium in voluptates ipsam!
                </p>

                <div class="tw-flex tw-space-x-8 tw-opacity-0 group-hover:tw-opacity-100 group-hover:tw-mb-20 tw-duration-700">
                    <div class="tw-flex tw-space-x-2 tw-items-center tw-cursor-pointer">
                        <p class="tw-text-gray tw-uppercase  hover:tw-text-red tw-duration-500">Detaylı İncele</p>
                        <div class="tw-flex tw-h-8 tw-w-8 tw-rounded-full tw-text-center tw-justify-center tw-items-center tw-bg-red tw-text-white">
                            <span class="material-symbols-outlined">
                                frame_inspect
                            </span>
                        </div>
                    </div>
                    <div class="tw-flex tw-space-x-2 tw-items-center tw-cursor-pointer">
                        <p class="tw-text-gray tw-uppercase  hover:tw-text-red tw-duration-500">Hızlı Rezervasyon</p>
                        <div class="tw-flex tw-h-8 tw-w-8 tw-rounded-full tw-text-center tw-justify-center itw-tems-center tw-bg-red tw-text-white">
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
        <div @click="next" class="tw-cursor-pointer tw-absolute tw-flex tw-justify-center tw-items-center tw-text-center tw-w-8 tw-h-8 tw-rounded-full tw-top-1/3 tw-right-5 tw-bg-red tw-text-white2 tw-opacity-0 group-hover:tw-opacity-100 tw-duration-500">
            <span class="material-symbols-outlined">
                arrow_forward_ios
            </span>
        </div>
        <div @click="previous" class="tw-cursor-pointer tw-absolute tw-flex tw-items-center tw-justify-center tw-text-center tw-w-8 tw-h-8 tw-rounded-full tw-top-1/3 tw-left-5 tw-bg-red tw-text-white2 tw-opacity-0 group-hover:tw-opacity-100 tw-duration-500">
            <span class="material-symbols-outlined">
                arrow_back_ios_new
            </span>
        </div>
    </div>
</template>



<script src="./index"></script>