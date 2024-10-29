<template>
    <div  @mouseenter="pauseAnimation" @mouseleave="resumeAnimation" class="tw-container tw-mx-auto">
        <div class="tw-flex tw-items-center tw-justify-center">
            <div class="tw-overflow-x-auto custom-scrollbar scroller custom-shadow " :data-animated="hasAnimation" ref="scroller">          
                    <ul class="tw-flex tw-space-x-10 scroller__inner " :style="`animation-play-state: ${animation_status};`">
                      <li  v-for="(item, index) in movies" :key="index" class="tw-flex-shrink-0">
                          <MovieCard :movie="item"/>
                      </li>
                    </ul>
            </div>
        </div>
    </div>
</template>

<style scoped>


.custom-shadow{
  -webkit-mask: linear-gradient(
    90deg,
    transparent,
    white 5%,
    white 90%,
    transparent
  );
  mask: linear-gradient(90deg, transparent, white 5%, white 90%, transparent);
}

.scroller[data-animated="true"]{
  --_animation-direction: forwards;
  --_animation-duration: 40s;
}

.scroller[data-animated="true"] .scroller__inner {
  width: max-content;
  flex-wrap: nowrap;
  animation: scroll var(--_animation-duration, 40s)
    var(--_animation-direction, forwards) linear infinite;
}


@keyframes scroll {
  to {
    transform: translate(calc(-50% - 2.5rem));
  }
}

.custom-scrollbar {
    max-width: 100%;
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