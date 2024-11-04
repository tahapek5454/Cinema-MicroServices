<template>
    <div @click="choose" :class="`tw-font-bold ${GetSeatColor}
     tw-rounded-md tw-text-xs  md:tw-text-base  tw-w-7 tw-h-6 tw-text-center tw-flex tw-justify-center tw-items-center tw-cursor-pointer hover:tw-bg-lime-500 tw-duration-300`">
                        {{ seatSessionStatus.seatNumber }}
    </div>
</template>



<script src="./index"></script>
