<template>
    <div class="tw-flex">
        <span v-if="type != 'User' && !isPlay" music="true" @click="speech" class="tw-text-xl material-symbols-outlined tw-cursor-pointer hover:tw-text-rose-900 tw-duration-500">
                music_note
        </span> 
        <span v-if="type != 'User' && isPlay" music="true" @click="cancelSpeech" class="tw-text-xl material-symbols-outlined tw-cursor-pointer hover:tw-text-rose-900 tw-duration-500">
                music_off
        </span>
        <div :class="`tw-flex tw-w-full ${type == 'User' ? 'tw-justify-end': 'tw-justify-start'}`">
            <div :class="`tw-p-2 tw-max-w-64 tw-h-auto ${type == 'User' ? 'tw-bg-rose-900': 'tw-bg-[#4d4d4d]'} tw-rounded-lg`">
                <div v-if="msg=='...'" class='tw-flex tw-space-x-2 tw-justify-start tw-items-center'>
                  <div class='tw-h-2 tw-w-2 tw-bg-white tw-rounded-full tw-animate-bounce'></div>
                  <div class='tw-h-2 tw-w-2 tw-bg-white tw-rounded-full tw-animate-bounce [animation-delay:-0.30s]'></div>
                  <div class='tw-h-2 tw-w-2 tw-bg-white tw-rounded-full tw-animate-bounce'></div>
                </div>
                <span v-else :messageId="msgId" message="true" class="tw-font-sans  tw-w-full tw-text-wrap">{{msg}}</span>
            </div>
        </div>
        <span v-if="type == 'User' && !isPlay" music="true" @click="speech" class="tw-text-xl material-symbols-outlined tw-cursor-pointer hover:tw-text-rose-900 tw-duration-500">
                music_note
        </span>
        <span v-if="type == 'User' && isPlay" music="true" @click="cancelSpeech" class="tw-text-xl material-symbols-outlined tw-cursor-pointer hover:tw-text-rose-900 tw-duration-500">
                music_off
        </span>
    </div>
</template>


<script src="./index">
</script>
  