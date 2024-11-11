<template>

  <div @click="selecteBranch"
    :class="` ${isSelected ? 'tw-bg-rose-900' : 'tw-bg-white2'} hover:tw-cursor-pointer tw-rounded-lg tw-w-full tw-flex tw-justify-start tw-p-2 tw-space-x-2`">
    <div :class="`tw-flex tw-flex-col tw-space-y-3 ${isSelected ? 'tw-text-white' : 'tw-text-black'}`">
      <span :class="`lg:tw-text-lg tw-font-bold  text-wrap`">{{ branch.name }}</span>
      <span class="tw-mt-0.5 tw-text-xs tw-font-light tw-text-neutral-500 text-wrap">{{ branch.address }}</span>
      <div class="tw-flex tw-h-full tw-justify-start tw-items-end tw-space-x-2">
        <div :class="`tw-flex  tw-justify-center tw-items-center tw-w-32 tw-rounded-lg ${isSelected ? 'tw-bg-white2' : 'tw-bg-rose-900'} `">
          <span :class="`tw-text-xs tw-font-light ${isSelected ? 'tw-text-black' : 'tw-text-white'}`">Gold Class</span>
        </div>
        <div :class="`tw-flex tw-justify-center tw-items-center tw-w-32 tw-rounded-lg ${isSelected ? 'tw-bg-white2' : 'tw-bg-rose-900'} `">
          <span :class="`tw-text-xs tw-font-light ${isSelected ? 'tw-text-black' : 'tw-text-white'}`">Geniş Koltuk</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script src="./index">
</script>
