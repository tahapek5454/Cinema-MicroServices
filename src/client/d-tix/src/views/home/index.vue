<!-- HomeView.vue -->
<template>
    <div class="bg-background">

    <div class="flex justify-center">
        <MovieCarousel></MovieCarousel>
    </div>

    <div class="py-10 px-10 md:px-0">
        <div class="container ml-10 my-5">
            <h1 class="text-2xl uppercase">Vizyondakiler</h1>
        </div>
        <MovieCardList/>
    </div>

    <div class="py-10 px-10 md:px-0">
        <div class="container ml-10 my-5">
            <h1 class="text-2xl uppercase">Yakında</h1>
        </div>
        <MovieCardList :hasAnimation="true"/>
    </div>

    </div>  
</template>
  


<script src="./index"></script>
