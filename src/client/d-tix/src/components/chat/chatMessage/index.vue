<template>
    <div class="tw-flex">
        <span v-if="type != 'User'" music="true" @click="()=>console.log('music')" class="tw-text-xl material-symbols-outlined tw-cursor-pointer hover:tw-text-rose-900 tw-duration-500">
                music_note
        </span> 
        <div :class="`tw-flex tw-w-full ${type == 'User' ? 'tw-justify-end': 'tw-justify-start'}`">
            <div :class="`tw-p-2 tw-w-64 tw-h-auto ${type == 'User' ? 'tw-bg-rose-900': 'tw-bg-[#4d4d4d]'} tw-rounded-lg`">
                <span :messageId="msgId" message="true" class="tw-font-sans  tw-w-full tw-text-wrap">{{msg}}</span>
            </div>
        </div>
        <span v-if="type == 'User'" music="true" @click="()=>console.log('music')" class="tw-text-xl material-symbols-outlined tw-cursor-pointer hover:tw-text-rose-900 tw-duration-500">
                music_note
        </span>
    </div>
</template>


<script src="./index">
</script>
  