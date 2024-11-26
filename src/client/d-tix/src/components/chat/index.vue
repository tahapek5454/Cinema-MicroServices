<template>
    <div>
<!--        Quick Reservation Section-->
        <QuickReservation :isOpenModal="isOpenModal" @close="isOpenModal=false"/>
<!--        Chat Section-->
      <Transition name="bounce">
        <VueDragResize  v-if="render"
                        dragHandle=".drag"
                     :minw="300"
                     :minh="300"
                     :w="400"
                     :h="500"
                     :Z="49"
                     :x="10"
                     :y="100"
                     class="tw-fix" >

            <div v-if="render" class="tw-z-50   tw-mb-4 tw-mr-4    tw-rounded-xl tw-w-full tw-h-full tw-shadow-xl shadow tw-shadow-white2 tw-bg-black  tw-px-3 tw-flex tw-flex-col tw-text-white2">
                <div class="tw-rounded-lg tw-w-full tw-p-4 drag  tw-flex tw-justify-between tw-items-center tw-text-center ">
                    <div class="tw-flex tw-space-x-2">
                        <img src="/absoluteImages/dmate.png" alt="robot" class="tw-rounded-full tw-w-12">
                        <div class="tw-flex tw-flex-col tw-space-y-1">
                          <span class="tw-text-white2 tw-font-sans tw-font-bold tw-text-lg tw-mt-2">D-MATE</span>
                          <span v-show="isWriting" class="tw-text-white2 tw-font-sans tw-font-thin tw-text-xs">Yazıyor ...</span>
                        </div>
                    </div>
                    <div class="tw-flex tw-space-x-5">
                        <span @click="minimize" class="material-symbols-outlined tw-text-3xl hover:tw-text-rose-900 tw-duration-500 hover:tw-cursor-pointer">
                            remove
                        </span>
                        <span @click="close" class="material-symbols-outlined tw-text-3xl hover:tw-text-rose-900 tw-duration-500 hover:tw-cursor-pointer">
                            close
                        </span>
                        <span @click="isOpenModal=true" class="material-symbols-outlined tw-text-2xl hover:tw-text-rose-900 tw-duration-500 hover:tw-cursor-pointer">
                            crop
                        </span>
                    </div>
                </div>

                <!-- Messajlaşma -->
                <div class="tw-p-4 tw-w-full tw-h-[37rem] tw-rounded-lg tw-bg-background tw-space-y-5 tw-text-xs tw-text-white2 tw-overflow-y-auto" >
                  <ChatMessage v-for="(item, index) in conversation" @openReservationModal="isOpenModal=true" :key="index" :msg="item.msg" :isReservation="item.isReservation" :msgId="item.msgId"  :type="item.type"/>
                  <ChatMessage v-if="isWriting"  msg="..."  :msgId="999"  type="Assistant"/>
                </div>
                <!-- Messajlaşma -->

                <!-- yazi yazma alani -->
                <div class="tw-flex tw-w-full tw-p-4  tw-justify-around   ">
                    <div class="tw-w-[21rem] tw-flex">
                        <v-text-field class="tw-text-xs tw-font-sans"
                        filled
                        rounded
                        dense
                        clearable
                        color="#881337"
                        v-on:keyup.enter="sendMessage"
                        v-model="message"
                        ></v-text-field>
                    </div>

                    <div class="tw-flex tw-space-x-7 tw-pt-1">
                        <span @click="sendMessage" class="tw-pl-2 tw-text-3xl tw-cursor-pointer material-symbols-outlined hover:tw-text-emerald-400 tw-duration-500">
                            send
                        </span>
                        <span @mousedown="startListening" @mouseup="stopListening" class="tw-text-3xl tw-cursor-pointer material-symbols-outlined hover:tw-text-rose-900 tw-duration-500">
                            mic
                        </span>
                        <span class="tw-text-3xl tw-cursor-pointer material-symbols-outlined hover:tw-text-blue tw-duration-500">
                            photo_camera
                        </span>
                    </div>
                </div>
            </div>
      </VueDragResize>
      </Transition>
    </div>
    
    
</template>
  
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

::-webkit-scrollbar {
  width: 20px;
}

::-webkit-scrollbar-track {
  background-color: transparent;
}


::-webkit-scrollbar-thumb {
  background-color: #d6dee1;
}


::-webkit-scrollbar-thumb {
  background-color: #d6dee1;
  border-radius: 20px;
}


::-webkit-scrollbar-thumb {
  background-color: #d6dee1;
  border-radius: 20px;
  border: 6px solid transparent;
  background-clip: content-box;
}


::-webkit-scrollbar-thumb:hover {

background-color: #535353;

}



</style>

<script src="./index">
</script>
  