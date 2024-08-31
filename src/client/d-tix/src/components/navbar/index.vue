<template>

<div class="font-bold">
    <header class="bg-white">
        <nav class="flex justify-between items-center  ">
            <div>
               D-TIX
            </div>
            <div :class="`absolute md:static  min-h-[60vh] md:min-h-fit left-0 bg-white ${topPosition} w-full md:w-auto  items-center px-5`">
                <ul class="flex flex-col md:flex-row md:items-center gap-8 md:gap-[4vw]">
                    <li class="hover:text-gray-500">Filmler</li>
                    <li class="hover:text-gray-500">Kategoriler</li>
                    <li class="hover:text-gray-500">Onlar Bunlar</li>
                </ul>
            </div>
            <div class="flex items-center gap-6">
                <button class="bg-[#a6c1ee] text-white px-5 py-2 rounded-full hover:bg-[#87acec]">Sign in</button>
                <ion-icon @click="changeMenuExpandIcon" :name="menuExpandIconName" class="text-3xl cursor-pointer md:hidden"></ion-icon>
            </div>
        </nav>

    </header>

</div>

</template>

<style></style>

<script src="./index"></script>

