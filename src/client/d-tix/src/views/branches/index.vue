<template>
  <div class="tw-relative  tw-w-full tw-h-auto tw-items-center  tw-flex tw-justify-center">
    <div class="tw-grid  tw-p-6 tw-grid-cols-1 lg:tw-grid-cols-4 tw-gap-8">
      <BranchCard v-for="(item, index) in branches" :key="index" :branche="item"/>
    </div>
  </div>
</template>


<script src="./index">
</script>
