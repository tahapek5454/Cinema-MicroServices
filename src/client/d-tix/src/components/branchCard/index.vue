<template>
  <div class="tw-w-[18rem] tw-p-1 tw-group tw-h-[22rem] lg:tw-w-[24rem] lg:tw-h-[22rem] tw-flex tw-flex-col  tw-border tw-border-component-border hover:tw-scale-110 hover:tw-shadow-2xl hover:tw-shadow-white tw-duration-500 tw-rounded-lg tw-bg-gradient-to-b tw-from-component-gray  tw-to-component-color tw-to-90% ">
    <div class="tw-w-full tw-h-1/2 tw-rounded-lg">
      <img src="/branchImages/Sinema-Salonu.png" alt="salon" class="tw-object-cover tw-h-full tw-w-full  tw-rounded-lg">
    </div>
    <div class="tw-w-full tw-h-1/2  tw-p-3 tw-flex tw-flex-col tw-space-y-2">
      <span class="tw-text-base lg:tw-text-lg tw-font-bold">{{branche.name}}</span>
      <span class="tw-text-xs lg:tw-text-sm">{{branche.district.name}}/{{branche.district.city.name}}</span>
      <span class="tw-text-xs">{{branche.address}}</span>
      <span class="tw-text-xs">{{branche.description}}</span>
      <div class="tw-w-full tw-h-full tw-flex tw-space-x-2 tw-items-center">
          <span class="material-symbols-outlined">
            star
          </span>
          <span class="material-symbols-outlined">
            star
          </span><span class="material-symbols-outlined">
            star
          </span><span class="material-symbols-outlined">
            star
          </span><span class="material-symbols-outlined">
            star
          </span>
      </div>
    </div>
  </div>
</template>


<script src="./index">
</script>
