<template>

  <div class="tw-flex tw-flex-col tw-w-[20rem] lg:tw-w-[32rem] tw-h-[24rem] md:tw-h-[35rem]  tw-p-6 tw-space-y-4 tw-bg-component-color tw-border tw-border-component-border tw-shadow-md tw-shadow-component-border tw-rounded-lg">
      <div class="tw-flex tw-justify-items-start tw-items-center">
        <span class="tw-font-bold tw-text-sm  md:tw-text-base lg:tw-text-xl tw-text-white">Sinema Seçimi</span>
      </div>

      <div class="tw-flex tw-justify-between">
        <div class="" style="width: 45%;">
            <label for="">Şehir</label>
            <v-autocomplete
                v-model="city"
                :items="cities"
                item-text="name"
                item-value="id"
                deletable-chips
                single
                small-chips
                dense
                class="tw-min-w-10"
                color="#881337"
                item-color="#881337"
                @change="(event) => cityChanged(event)"
            ></v-autocomplete>
        </div>  
        <div class="" style="width: 45%;">
            <label for="">İlçe</label>
            <v-autocomplete
                v-model="district"
                :items="districts"
                item-text="name"
                item-value="id"
                deletable-chips
                single
                small-chips
                dense
                class="tw-min-w-10"
                color="#881337"
                item-color="#881337"
                @change="(event) => distrinctChanged(event)"
            ></v-autocomplete>
        </div> 
      </div>

      <div  class="tw-flex tw-flex-col  tw-space-y-1 tw-overflow-auto tw-w-full tw-h-full ">
          <BranchSelectionCard v-for="(item, index) in branchSelectionCardDatas" :key="index" @selectBranch="selectBranch" :branch="item.branch" :isSelected="item.isSelected"/>
      </div>

  </div>

</template>

<script src="./index">
</script>
