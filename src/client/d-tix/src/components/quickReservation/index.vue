<template>
  <div>
      <Modal :isOpen="isOpenModal"  @close="$emit('close')" :witdh="'tw-w-[calc(100vw-30px)]'" :height="`tw-h-[44rem]`" >
        <div class="tw-w-full tw-h-full tw-flex tw-flex-col">
          <div class="tw-flex tw-justify-center md:tw-space-x-36 tw-items-center  tw-border-b-2 tw-border-b-white2 tw-pb-3">
            <div @click="sectionStep=0" :class="`tw-rounded-lg tw-p-2 hover:tw-bg-rose-900 ${sectionStep===0 ? 'tw-bg-rose-900' : ''} hover:tw-cursor-pointer tw-duration-500`">
              <span class="tw-font-bold tw-text-xs md:tw-text-base tw-text-white">
                Şube/Film/Tarih Seçimi
              </span>
            </div>
            <div @click="sectionStep=1" :class="`tw-rounded-lg tw-p-2 hover:tw-bg-rose-900 ${sectionStep===1 ? 'tw-bg-rose-900' : ''} hover:tw-cursor-pointer tw-duration-500`">
              <span class="tw-font-bold tw-text-xs md:tw-text-base tw-text-white">
              Koltuk Seçimi
              </span>
            </div>
            <div @click="sectionStep=2" :class="`tw-rounded-lg tw-p-2 hover:tw-bg-rose-900 ${sectionStep===2 ? 'tw-bg-rose-900' : ''} hover:tw-cursor-pointer tw-duration-500`">
              <span class="tw-font-bold tw-text-xs md:tw-text-base tw-text-white">
              Özet
              </span>
            </div>
            <div @click="$toast.error('Şu anda hizmet verememekteyiz.')" :class="`tw-rounded-lg tw-p-2 hover:tw-bg-rose-900 ${sectionStep===3 ? 'tw-bg-rose-900' : ''} hover:tw-cursor-pointer tw-duration-500`">
              <span class="tw-font-bold tw-text-xs md:tw-text-base tw-text-white">
              Ödeme
              </span>
            </div>
          </div>
          <div class="tw-w-full tw-h-full tw-overflow-y-auto  tw-py-4">
            <div class="tw-w-full tw-h-full">
              <div v-if="sectionStep==0" class="tw-flex tw-justify-center tw-flex-wrap tw-flex-col tw-space-y-4 md:tw-space-y-0 md:tw-flex-row  tw-space-x-2">
                <BranchSelection @selectBranchForReservation="selectBranchForReservation"/>
                <MovieSelection @selectMovieForReservation="selectMovieForReservation"/>
                <MovieSelection/>
              </div>
              <div v-else-if="sectionStep==1" class="tw-flex tw-justify-center tw-items-center tw-w-full tw-h-full">
                <TheaterHall/>
              </div>
              <div v-else-if="sectionStep==2" class="tw-flex tw-justify-center tw-items-center tw-w-full tw-h-full">
                <TicketSummary/>
              </div>
            </div>
          </div>
          <div class="tw-flex tw-w-full tw-h-auto  tw-justify-between">
            <v-btn
                @click="next(-1)"

                color="#881337"
            >
              Geri
            </v-btn>
            <v-btn
                @click="next(1)"

                color="#881337"
            >
              {{sectionStep==3 ? 'Rezervasyonu Tamamla' : 'İleri'}}
            </v-btn>
          </div>
        </div>
      </Modal>
  </div>
</template>

<script src="./index">
</script>
