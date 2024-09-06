<template>
    <div class="flex flex-col  bg-background">

        <div class="flex flex-col md:flex-row px-16 mt-16 justify-between">
            <div class="flex text-3xl">
                Movie Title
            </div>

            <div class="flex space-x-2 md:space-x-8">
                <div class="flex space-x-1 md:space-x-2">
                    <span class="text-sm md:text-2xl material-symbols-outlined">
                        calendar_month
                    </span>
                    <span class="text-sm md:text-lg">
                        06.09.2024
                    </span> 
                </div>

                <div class="flex space-x-1 md:space-x-2">
                    <span class="text-sm md:text-2xl material-symbols-outlined">
                        schedule
                    </span>
                    <span class="text-sm md:text-lg">
                        2 Saat 7 Dakika
                    </span> 
                </div>

                <div class="flex space-x-1 md:space-x-2">
                    <span class="text-sm md:text-2xl material-symbols-outlined">
                        movie
                    </span>
                    <span class="text-sm md:text-lg">
                        Aksiyon
                    </span> 
                </div>
            </div>
        </div>

        <div class="flex px-16 mt-4 mb-16 flex-col md:flex-row">
            <div class="basis-1/4" >
                <MovieCard :path="moviePath" :isDetail="true"/>
            </div>
            <div class="basis-3/4 flex flex-col">
                <div class="flex flex-col justify-center items-start space-y-8">
                    <div class="flex justify-start space-x-6">
                        <span class="text-2xl material-symbols-outlined">
                            movie
                        </span>
                        
                        <span class="text-2xl material-symbols-outlined">
                            masked_transitions_add
                        </span>

                        <span class="text-2xl material-symbols-outlined">
                            live_tv
                        </span>

                    </div>
                    <p class="text-left font-bold">Lorem ipsum dolor</p>
                    <p class="text-left font-bold">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Magni necessitatibus aperiam possimus consequatur harum. Aut itaque harum ducimus magnam tempore reiciendis provident cupiditate voluptatibus eos doloremque. Voluptatum modi molestias delectus.
                    Nisi delectus soluta inventore ut quasi, deleniti esse vero, autem quidem beatae error, aspernatur similique voluptatum incidunt animi vitae sapiente cum totam ex debitis minus porro! Excepturi earum porro magnam?</p>
                    <p class="text-left font-bold">Lorem ipsum dolor sit amet consectetur adipisicing elit. Perspiciatis incidunt, autem delectus ad minus laudantium veniam possimus dolorem atque ipsa dolore. Doloremque aspernatur minus quas distinctio quos hic molestias vitae.</p>
                </div>
                
                <div class="flex mt-16 justify-center items-center">
                    <button class="bg-red hover:bg-rose-900 duration-500 text-white font-bold py-2 px-4 rounded-full  justify-center items-center text-center flex">
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
  