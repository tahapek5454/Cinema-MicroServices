<template>
    <div class="tw-w-full tw-h-[52rem] tw-flex tw-justify-center tw-items-center tw-border tw-border-red tw-space-y-5">

      <div class=" tw-rounded-xl tw-w-[40rem] tw-h-[48rem] tw-shadow-xl shadow tw-shadow-white2 tw-bg-black  tw-px-3 tw-flex tw-flex-col tw-text-white2">
          
          <div class="tw-rounded-lg tw-w-full tw-p-4  tw-flex tw-items-center tw-text-center tw-space-x-2">
            <img src="/absoluteImages/dmate.png" alt="robot" class="tw-rounded-full tw-w-12">
            <span class="tw-text-white2 tw-font-sans tw-font-bold tw-text-lg tw-mt-2">D-MATE</span>  
          </div>

          <!-- Messajlaşma -->
          <div class="tw-p-4 tw-w-full tw-h-[37rem] tw-rounded-lg tw-bg-background tw-space-y-20 tw-text-xs tw-text-white2 tw-overflow-y-auto" >

            <div class="tw-flex">
              <span class="tw-text-xl material-symbols-outlined tw-cursor-pointer hover:tw-text-rose-900 tw-duration-500">
                        music_note
              </span> 
              <div class="tw-flex tw-w-full tw-justify-start">
                <div class="tw-p-2 tw-w-64 tw-h-auto tw-bg-rose-900 tw-rounded-lg">
                  <span class=" tw-font-sans  tw-w-full tw-text-wrap">Selamlar size nasıl yardımcı olabilirim.</span> 
                </div>
              </div>
            </div>
            
            
            <div class="tw-flex">
              <div class="tw-flex tw-w-full tw-justify-end">
                <div class="tw-p-2 tw-w-64 tw-h-auto tw-bg-[#3b3a39] tw-rounded-lg">
                  <span class=" tw-font-sans  tw-w-full tw-text-wrap">Vizyondaki en iyi filmi bana söyler misin ?</span> 
                </div>
              </div>
              <span class="tw-text-xl material-symbols-outlined tw-cursor-pointer hover:tw-text-rose-900 tw-duration-500">
                        music_note
              </span> 
            </div>

      

          </div>
             <!-- Messajlaşma -->


          <div class="tw-flex tw-w-full tw-p-4  tw-justify-around   ">
     
              <div class="tw-w-[21rem] tw-flex">
                  <v-text-field class="tw-text-xs tw-font-sans"
                  filled
                  rounded
                  dense
                  clearable
                  color="#881337"
                ></v-text-field>
              </div>
          
              <div class="tw-flex tw-space-x-7 tw-pt-1">

                <span class="tw-pl-2 tw-text-3xl tw-cursor-pointer material-symbols-outlined hover:tw-text-emerald-400 tw-duration-500">
                          send
                </span>
  

            
                <span class="tw-text-3xl tw-cursor-pointer material-symbols-outlined hover:tw-text-rose-900 tw-duration-500">
                  mic
                </span>
        

            
                <span class="tw-text-3xl tw-cursor-pointer material-symbols-outlined hover:tw-text-blue tw-duration-500">
                  photo_camera
                </span>

              </div>        
          </div> 
      </div>

 

    </div>
</template>

<script src="./index"></script>

<style scoped>

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
