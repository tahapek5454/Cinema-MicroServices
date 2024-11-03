<template>
  <div class="tw-bg-transparent tw-p-6 tw-w-[24rem] lg:tw-w-[60rem] tw-h-[36rem] tw-overflow-y-auto tw-space-y-3">
      <span class="tw-font-bold lg:tw-text-xl">Tüm Yorumlar</span>

      <div v-for="(item, index) in comments" :key="index" class="tw-bg-component-gray tw-w-full tw-h-auto tw-text-wrap tw-p-6 tw-flex tw-flex-col tw-rounded-lg tw-space-y-6">
          <span>{{item.comment}}</span>
          <div class="tw-flex tw-justify-start tw-items-center tw-space-x-5">
            <span class="material-symbols-outlined tw-text-white2 tw-text-5xl">
              account_circle
            </span>
            <div class="tw-flex tw-flex-col tw-space-y-2">
                <span>
                  {{item.userName}}
                </span>
                <span class="tw-text-xs tw-text-[#7A7E80]">
                    {{textDate(item.createdDate)}}
                </span>
            </div>
            <div class="tw-flex tw-space-y-1 tw-space-x-2">
                <span class="material-symbols-outlined tw-text-2xl hover:tw-text-rose-900 tw-duration-500 hover:tw-cursor-pointer">
                  favorite
                </span>
                <span>
                        {{item.likeCount}}
                </span>
            </div>
          </div>
      </div>
  </div>
</template>



<script src="./index">
</script>
