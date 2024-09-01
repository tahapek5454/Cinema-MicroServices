<template>
    <div class="font-bold text-gray-light">
        <header class="bg-dark">
            <nav class="flex justify-between py-2 px-4">
                <div>
                    <img width="50px" src="@/assets/YENILOGO.svg" alt="Logo">
                </div>
                <div
                    :class="`absolute z-40 bigmd:z-0 bigmd:static  min-h-[60vh] bigmd:min-h-fit left-0 bg-dark ${topPosition} w-full bigmd:w-auto flex  items-center px-5 transition-all duration-500`">
                    <ul class="flex flex-col bigmd:flex-row bigmd:items-center gap-8 bigmd:gap-[2vw]">
                        <li class="hover:text-gray-500">Filmler</li>
                        <li class="hover:text-gray-500">Kategoriler</li>
                        <li class="hover:text-gray-500">Sinemalar</li>
                        <div class="group border-r px-4 mx-4 py-1 border-red">
                            <input type="text" class="transition duration-500 bg-transparent border-b border-red w-32 md:w-44 focus:outline-none ">
                            <span class="-ml-4 group-hover:ml-0 transition-all duration-500 group-hover:text-red material-symbols-outlined">search</span>
                        </div>

                        
                    </ul>
                </div>
                <div class="flex items-center gap-6">
                    <span class="text-3xl cursor-pointer material-symbols-outlined">
                        account_circle
                    </span>
                    <span class="text-3xl cursor-pointer material-symbols-outlined">
                        book_online
                    </span>
                    <span class="text-3xl cursor-pointer material-symbols-outlined">
                        login
                    </span>
                    <span class="text-3xl cursor-pointer material-symbols-outlined">
                        logout
                    </span>
                    <span  @click="changeMenuExpandIcon" class="text-3xl cursor-pointer bigmd:hidden material-symbols-outlined">
                        {{ menuExpandIconName }}
                    </span>                 
                </div>
            </nav>
        </header>
    </div>
</template>

<style></style>

<script src="./index"></script>
