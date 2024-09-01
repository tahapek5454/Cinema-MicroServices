<template>
    <div class="h-128 w-[2048px]  group relative overflow-hidden">
        <img :src="slides[selectedIndex]" alt="image" class="h-full w-full object-cover">
        <div class="absolute bottom-0 w-full bg-gradient-to-b from-transparent to-black">
            <div class="container ml-8 bigmd:ml-24 ">
                <h1 class="text-6xl uppercase text-red group-hover:mb-1 duration-500">
                    The Dark Knight
                </h1>
                <p class=" text-gray group-hover:mb-2 duration-500 w-1/3">
                    Lorem ipsum dolor, sit amet consectetur adipisicing elit.
                    Eos fugiat ipsum aperiam dolores, repellat blanditiis ad praesentium in voluptates ipsam!
                </p>

                <div class="flex space-x-8 opacity-0 group-hover:opacity-100 group-hover:mb-20 duration-700">
                    <div class="flex space-x-2 items-center cursor-pointer">
                        <p class="text-gray uppercase  hover:text-red duration-500">Detaylı İncele</p>
                        <div class="flex h-8 w-8 rounded-full text-center justify-center items-center bg-red text-white">
                            <span class="material-symbols-outlined">
                                frame_inspect
                            </span>
                        </div>
                    </div>
                    <div class="flex space-x-2 items-center cursor-pointer">
                        <p class="text-gray uppercase  hover:text-red duration-500">Hızlı Rezervasyon</p>
                        <div class="flex h-8 w-8 rounded-full text-center justify-center items-center bg-red text-white">
                            <span class="material-symbols-outlined">
                                book_online
                            </span>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="flex space-x-4 absolute bottom-5 left-1/2 opacity-0 group-hover:opacity-100 duration-500">
                <div v-for="(i, index) in slides" :key="index" :class="`w-4 h-4 rounded-full ${index===selectedIndex ? 'bg-red' :'bg-white'}`"></div>
        </div>
        <div @click="next" class="cursor-pointer absolute flex justify-center items-center text-center w-8 h-8 rounded-full top-1/3 right-5 bg-red text-white2 opacity-0 group-hover:opacity-100 duration-500">
            <span class="material-symbols-outlined">
                arrow_forward_ios
            </span>
        </div>
        <div @click="previous" class="cursor-pointer absolute flex items-center justify-center text-center w-8 h-8 rounded-full top-1/3 left-5 bg-red text-white2 opacity-0 group-hover:opacity-100 duration-500">
            <span class="material-symbols-outlined">
                arrow_back_ios_new
            </span>
        </div>
    </div>
</template>



<script src="./index"></script>