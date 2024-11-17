<template>
  <div class="tw-relative  tw-w-full tw-h-screen tw-items-center  tw-flex tw-justify-center">
    <div class="tw-grid tw-z-10 tw-p-6 tw-grid-cols-2 lg:tw-grid-cols-4 tw-gap-8">
      <CategoryCard v-for="(item, index) in categories" :key="index" :name="item.name" :icon="`comedy_mask`"/>
    </div>
    <img src="/absoluteImages/trex.webp" alt="trex" class="tw-hidden lg:tw-block tw-top-[5%] tw-z-[1] tw-absolute tw-right-3 tw-w-[30rem] 2xl:tw-w-[42rem]">
    <img src="/absoluteImages/godzilla.webp" alt="tree" class="tw-hidden lg:tw-block tw-top-[5%] tw-z-[1] tw-absolute tw-left-3 tw-w-[28rem] 2xl:tw-w-[36rem]">
  </div>
</template>


<script src="./index">
</script>
