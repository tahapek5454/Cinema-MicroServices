<template>
    <div class="container mx-auto">
        <div class="flex items-center justify-center custom-scrollbar">
            <div class="overflow-x-auto ">
                <ul class="flex space-x-10">
                    <li v-for="(item, index) in movieList" :key="index" class="flex-shrink-0">
                        <MovieCard :path="item"/>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<style scoped>
.custom-scrollbar {
    max-width: 100%;
    overflow-x: auto;
    scrollbar-width: thin;
    scrollbar-color: #3d3d3d #000000;
  }
  
  .custom-scrollbar::-webkit-scrollbar {
    width: 12px;
    height: 12px;
  }
  
  .custom-scrollbar::-webkit-scrollbar-thumb {
    background-color: #3d3d3d;
    border-radius: 6px;
  }
  
  .custom-scrollbar::-webkit-scrollbar-thumb:hover {
    background-color: #3d3d3d;
  }
  
  .custom-scrollbar::-webkit-scrollbar-track {
    background-color: #000000;
  }
  
  .custom-scrollbar::-webkit-scrollbar-corner {
    background-color: transparent;
  }
</style>

<script src="./index"></script>