<!-- HomeView.vue -->
<template>
    <div class="tw-bg-background">
        <div class="tw-hidden lg:tw-flex tw-justify-center">
            <MovieCarousel></MovieCarousel>
        </div>

        <div class="tw-py-10 tw-px-10 md:tw-px-0">
            <div class="tw-container tw-ml-10 tw-my-5">
                <h1 class="tw-text-2xl tw-uppercase">Vizyondakiler</h1>
            </div>
            <MovieCardList/>
        </div>

        <div class="tw-py-10 tw-px-10 md:tw-px-0">
            <div class="tw-container tw-ml-10 tw-my-5">
                <h1 class="tw-text-2xl tw-uppercase">Yakında</h1>
            </div>
            <MovieCardList :hasAnimation="true"/>
        </div>

        <div class="tw-py-10 tw-px-10 md:tw-px-0">
            <div class="tw-container tw-ml-10 tw-my-5">
                <h1 class="tw-text-2xl tw-uppercase">Kampanyalar</h1>
            </div>
            <Campaign/>
        </div>

        <div class="tw-py-10 tw-px-10 md:tw-px-0">
            <MobileAdvertisement/>
        </div>
    </div>  
</template>


<script src="./index"></script>
