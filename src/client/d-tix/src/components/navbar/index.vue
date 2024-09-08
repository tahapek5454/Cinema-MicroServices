<template>
    <div class="tw-font-bold tw-text-gray-light">
        <header class="tw-bg-dark">
            <nav class="tw-flex tw-justify-between tw-py-2 tw-px-4">
                <div>
                    <img width="50px" src="@/assets/YENILOGO.svg" alt="Logo">
                </div>
                <div
                    :class="`tw-absolute tw-z-40 bigmd:tw-z-0 bigmd:tw-static  tw-min-h-[60vh] bigmd:tw-min-h-fit tw-left-0 tw-bg-dark ${topPosition} tw-w-full bigmd:tw-w-auto tw-flex  tw-items-center tw-px-5 tw-transition-all tw-duration-500`">
                    <ul class="tw-flex tw-flex-col bigmd:tw-flex-row bigmd:tw-items-center tw-gap-8 bigmd:tw-gap-[2vw]">
                        <li class="hover:tw-text-gray-500">Filmler</li>
                        <li class="hover:tw-text-gray-500">Kategoriler</li>
                        <li class="hover:tw-text-gray-500">Sinemalar</li>

                        <!-- <div class="tw-group tw-border-r tw-px-4 tw-mx-4 tw-py-1 tw-border-red">
                            <input type="text" class="tw-transition tw-duration-500 tw-bg-transparent tw-border-b tw-border-red tw-w-32 md:tw-w-44 focus:tw-outline-none ">
                            <span class="tw--ml-4 group-hover:tw-ml-0 tw-transition-all tw-duration-500 group-hover:tw-text-red material-symbols-outlined">search</span>
                        </div> -->
                        <div class="">
                            <v-autocomplete
                                v-model="values"
                                :items="items"
                                deletable-chips
                                multiple
                                small-chips
                                class="tw-min-w-10"
                            ></v-autocomplete>
                        </div>    
                        <v-btn
      depressed
      color="primary"
    >
      Primary
    </v-btn>
                    </ul>
                </div>
                <div class="tw-flex tw-items-center tw-gap-6">
                    <span class="tw-text-3xl tw-cursor-pointer material-symbols-outlined">
                        account_circle
                    </span>
                    <span class="tw-text-3xl tw-cursor-pointer material-symbols-outlined">
                        book_online
                    </span>
                    <span class="tw-text-3xl tw-cursor-pointer material-symbols-outlined">
                        login
                    </span>
                    <span class="tw-text-3xl tw-cursor-pointer material-symbols-outlined">
                        logout
                    </span>
                    <span  @click="changeMenuExpandIcon" class="tw-text-3xl tw-cursor-pointer bigmd:tw-hidden material-symbols-outlined">
                        {{ menuExpandIconName }}
                    </span>                 
                </div>
            </nav>
        </header>
    </div>
</template>

<style></style>

<script src="./index"></script>
