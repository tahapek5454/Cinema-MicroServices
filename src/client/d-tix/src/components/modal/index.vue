<template>
  <div>
      <div
          v-if="isOpen"
          class="tw-fixed tw-inset-0 tw-bg-slate-800 tw-opacity-80 tw-z-[51]"
      ></div>
      <Transition name="bounce">
        <div
          v-if="isOpen"
          class="tw-fixed tw-inset-0 tw-z-[52] tw-flex tw-items-center tw-justify-center "
      >
        <div :class="`tw-bg-[#181818] tw-max-w-[calc(100vw-30px)] ${WitdhMeasure} ${HeightMeasure} tw-max-h-[calc(100vh-20px)]  ${center ? 'tw-flex tw-flex-col tw-justify-center tw-items-center': ''}   tw-rounded-lg tw-p-4 tw-shadow-lg tw-overflow-y-auto`">
          <slot></slot>
          <button
              @click="$emit('close')"
              class="tw-absolute tw-top-3 tw-right-3 tw-text-white2 hover:tw-text-gray-800 tw-text-4xl"
          >
            ✖
          </button>
        </div>
      </div>
      </Transition>
  </div>
</template>
<!--tw-max-h-[calc(100vh-20px)]-->

<style scoped>
.bounce-enter-active {
  animation: bounce-in 0.5s;
}
.bounce-leave-active {
  animation: bounce-in 0.5s reverse;
}
@keyframes bounce-in {
  0% {
    transform: scale(0);
  }
  50% {
    transform: scale(1.25);
  }
  100% {
    transform: scale(1);
  }
}
</style>


<script src="./index">
</script>
