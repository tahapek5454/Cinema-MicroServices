<template>
    <div class="tw-flex tw-flex-col  tw-bg-background">

        <div class="tw-flex tw-flex-col md:tw-flex-row tw-px-16 tw-mt-16 tw-justify-between">
            <div class="tw-flex tw-text-3xl">
                {{movie.name}}
            </div>

            <div class="tw-flex tw-space-x-2 md:tw-space-x-8">
                <div class="tw-flex tw-space-x-1 md:tw-space-x-2">
                    <span class="tw-text-sm md:tw-text-2xl material-symbols-outlined">
                        calendar_month
                    </span>
                    <span class="tw-text-sm md:tw-text-lg">
                        {{DateValue}}
                    </span> 
                </div>

                <div class="tw-flex tw-space-x-1 md:tw-space-x-2">
                    <span class="tw-text-sm md:tw-text-2xl material-symbols-outlined">
                        schedule
                    </span>
                    <span class="tw-text-sm md:tw-text-lg">
                        {{TimeValue}}
                    </span> 
                </div>

                <div class="tw-flex tw-space-x-1 md:tw-space-x-2">
                    <span class="tw-text-sm md:tw-text-2xl material-symbols-outlined">
                        movie
                    </span>
                    <span class="tw-text-sm md:tw-text-lg">
                        {{ movie.category.name }}
                    </span> 
                </div>
            </div>
        </div>

        <div class="tw-flex  tw-px-16 tw-mt-6 tw-mb-16 tw-space-x-8 tw-flex-col md:tw-flex-row tw-space-y-10 md:tw-space-y-0">
            <div class="tw-basis-[18%]" >
                <MovieCard :movie="movie" :isDetail="true"/>
            </div>
            <div class="tw-basis-[57%] tw-flex tw-flex-col">
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
                    <p class="tw-text-left tw-text-white2 tw-text-2xl tw-font-bold">{{ movie.name }}</p>
                    <div class="tw-flex tw-space-x-2">
                      <div class="tw-flex tw-justify-center tw-items-center tw-w-16 tw-rounded-lg tw-bg-white hover:tw-scale-110 tw-duration-300">
                          <span class="tw-font-bold tw-text-black">IMAX</span>
                      </div>
                      <div class="tw-flex tw-justify-center tw-items-center tw-w-16 tw-rounded-lg tw-bg-white hover:tw-scale-110 tw-duration-300">
                        <span class="tw-font-bold tw-text-black">4DX</span>
                      </div>
                      <div class="tw-flex tw-justify-center tw-items-center tw-w-16 tw-rounded-lg tw-bg-white hover:tw-scale-110 tw-duration-300">
                        <span class="tw-font-bold tw-text-black">MPX</span>
                      </div>
                      <div class="tw-flex tw-justify-center tw-items-center tw-w-16 tw-rounded-lg tw-bg-white hover:tw-scale-110 tw-duration-300">
                        <span class="tw-font-bold tw-text-black">BJK</span>
                      </div>
                    </div>
                    <p class="tw-text-left tw-font-bold">{{ movie.description }}</p>
                    <p class="tw-text-left tw-font-bold">Lorem ipsum dolor sit amet consectetur adipisicing elit. Perspiciatis incidunt, autem delectus ad minus laudantium veniam possimus dolorem atque ipsa dolore. Doloremque aspernatur minus quas distinctio quos hic molestias vitae.</p>
                </div>
                
                <div class="tw-flex tw-flex-col md:tw-flex-row tw-space-y-3 md:tw-space-y-0 tw-mt-16 tw-space-x-8 tw-justify-center tw-items-center">
                    <button @click="goToTicketBuy" class="tw-bg-red hover:tw-bg-rose-900 tw-duration-500 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full  tw-justify-center tw-items-center tw-text-center tw-flex">
                        <span class="material-symbols-outlined mr-2">
                            local_activity
                        </span>
                        Bilet Al
                    </button>

                  <button @click="goToTicketBuy" class="tw-bg-red hover:tw-bg-rose-900 tw-duration-500 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full  tw-justify-center tw-items-center tw-text-center tw-flex">
                        <span class="material-symbols-outlined mr-2">
                            live_tv
                        </span>
                    Fragmanı İzle
                  </button>

                  <button @click="goToTicketBuy" class="tw-bg-red hover:tw-bg-rose-900 tw-duration-500 tw-text-white tw-font-bold tw-py-2 tw-px-4 tw-rounded-full  tw-justify-center tw-items-center tw-text-center tw-flex">
                        <span class="material-symbols-outlined mr-2">
                            chat
                        </span>
                    Yorumla
                  </button>
                </div>
            </div>
            <div class="tw-basis-1/4">
              <MovieEntries/>
            </div>
        </div>

        <div class="tw-hidden md:tw-flex tw-my-16 tw-justify-around tw-items-center">
          <img src="/absoluteImages/kova.svg" alt="kova" class="tw-w-96">
          <img src="/campaignImages/halk.jpg" alt="halk" class="tw-rounded-lg tw-w-128 hover:tw-scale-110 tw-duration-500">
          <img src="/absoluteImages/kova.svg" alt="kova" class="tw-w-96">
        </div>
    </div>
</template>

<script src="./index">
</script>
  