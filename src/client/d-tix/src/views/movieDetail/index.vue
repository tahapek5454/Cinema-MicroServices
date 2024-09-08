<template>
    <div class="tw-flex tw-flex-col  tw-bg-background">

        <div class="tw-flex tw-flex-col md:tw-flex-row tw-px-16 tw-mt-16 tw-justify-between">
            <div class="tw-flex tw-text-3xl">
                Movie Title
            </div>

            <div class="tw-flex tw-space-x-2 md:tw-space-x-8">
                <div class="tw-flex tw-space-x-1 md:tw-space-x-2">
                    <span class="tw-text-sm md:tw-text-2xl material-symbols-outlined">
                        calendar_month
                    </span>
                    <span class="tw-text-sm md:tw-text-lg">
                        06.09.2024
                    </span> 
                </div>

                <div class="tw-flex tw-space-x-1 md:tw-space-x-2">
                    <span class="tw-text-sm md:tw-text-2xl material-symbols-outlined">
                        schedule
                    </span>
                    <span class="tw-text-sm md:tw-text-lg">
                        2 Saat 7 Dakika
                    </span> 
                </div>

                <div class="tw-flex tw-space-x-1 md:tw-space-x-2">
                    <span class="tw-text-sm md:tw-text-2xl material-symbols-outlined">
                        movie
                    </span>
                    <span class="tw-text-sm md:tw-text-lg">
                        Aksiyon
                    </span> 
                </div>
            </div>
        </div>

        <div class="tw-flex tw-px-16 tw-mt-4 tw-mb-16 tw-flex-col md:tw-flex-row tw-space-y-10 md:tw-space-y-0">
            <div class="tw-basis-1/4" >
                <MovieCard :path="moviePath" :isDetail="true"/>
            </div>
            <div class="tw-basis-3/4 tw-flex tw-flex-col">
                <div class="tw-flex tw-flex-col tw-justify-center tw-items-start tw-space-y-8">
                    <div class="tw-flex tw-justify-start tw-space-x-6">
                        <span class="tw-text-2xl material-symbols-outlined">
                            movie
                        </span>
                        
                        <span class="tw-text-2xl material-symbols-outlined">
                            masked_transitions_add
                        </span>

                        <span class="tw-text-2xl material-symbols-outlined">
                            live_tv
                        </span>

                    </div>
                    <p class="tw-text-left tw-font-bold">Lorem ipsum dolor</p>
                    <p class="tw-text-left tw-font-bold">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Magni necessitatibus aperiam possimus consequatur harum. Aut itaque harum ducimus magnam tempore reiciendis provident cupiditate voluptatibus eos doloremque. Voluptatum modi molestias delectus.
                    Nisi delectus soluta inventore ut quasi, deleniti esse vero, autem quidem beatae error, aspernatur similique voluptatum incidunt animi vitae sapiente cum totam ex debitis minus porro! Excepturi earum porro magnam?</p>
                    <p class="tw-text-left tw-font-bold">Lorem ipsum dolor sit amet consectetur adipisicing elit. Perspiciatis incidunt, autem delectus ad minus laudantium veniam possimus dolorem atque ipsa dolore. Doloremque aspernatur minus quas distinctio quos hic molestias vitae.</p>
                </div>
                
                <div class="tw-flex tw-mt-16 tw-justify-center tw-items-center">
                    <button @click="show" class="tw-bg-red hover:tw-bg-rose-900 tw-duration-500 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full  tw-justify-center tw-items-center tw-text-center tw-flex">
                        <span class="material-symbols-outlined mr-2">
                            local_activity
                        </span>
                        Bilet Al
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>
  
<script src="./index"></script>
  