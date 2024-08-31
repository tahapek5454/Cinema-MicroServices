<template>
    <div class="font-bold text-gray-light">
        <header class="bg-dark">
            <nav class="flex justify-between py-2 px-4">
                <div>
                    <img width="50px" src="@/assets/YENILOGO.svg" alt="Logo">
                </div>
                <div
                    :class="`absolute md:static  min-h-[60vh] md:min-h-fit left-0 bg-dark ${topPosition} w-full md:w-auto flex  items-center px-5 transition-all duration-500`">
                    <ul class="flex flex-col md:flex-row md:items-center gap-8 md:gap-[4vw]">
                        <li class="hover:text-gray-500">Filmler</li>
                        <li class="hover:text-gray-500">Kategoriler</li>
                        <li class="hover:text-gray-500">Sinemalar</li>
                        <li class="hover:text-gray-500">Kampanyalar</li>
                        <li class="hover:text-gray-500">Salonlar</li>
                    </ul>
                </div>
                <div class="flex items-center gap-6">
                    <ion-icon name="log-in-outline" class="text-3xl cursor-pointer"></ion-icon>
                    <ion-icon name="person-add-outline" class="text-3xl cursor-pointer"></ion-icon>
                    <ion-icon @click="changeMenuExpandIcon" :name="menuExpandIconName"
                        class="text-3xl cursor-pointer md:hidden"></ion-icon>
                </div>
            </nav>
        </header>
    </div>
</template>

<style></style>

<script src="./index"></script>
