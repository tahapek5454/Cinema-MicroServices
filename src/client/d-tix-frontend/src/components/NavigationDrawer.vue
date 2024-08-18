<template>
    <v-layout>
      <v-app-bar
        color="background"
        prominent
        border-color
        :elevation="24"
        scroll-behavior="fade-image"
        scroll-threshold="403"
        
      >
        <v-app-bar-nav-icon variant="text" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>

        <v-app-bar-title>Logo Gelicek</v-app-bar-title>

        <template v-if="$vuetify.display.mdAndUp">
        <v-spacer></v-spacer>
        <router-link to="/hedef-sayfa" class="custom-link">Filmler</router-link>
        <v-spacer></v-spacer>
        <router-link to="/hedef-sayfa" class="custom-link">Sinemalar</router-link>
        <v-spacer></v-spacer>
        <router-link to="/hedef-sayfa" class="custom-link">Kampanyalar</router-link>
        <v-spacer></v-spacer>
        <router-link to="/hedef-sayfa" class="custom-link">Ayrıcalıklı Salonlar</router-link>
        <v-spacer></v-spacer>

        <v-btn icon="mdi-magnify" variant="text"></v-btn>
        
        <v-btn icon="mdi-home" variant="text"></v-btn>

        <v-btn icon="mdi-filter" variant="text"></v-btn>
        
        <v-btn
          class="ma-2 custom-button"
        >
          Giriş Yap
          <v-icon
            icon="mdi-login"
            end
          ></v-icon>
        </v-btn>
        <v-btn
          class="ma-2 custom-button"
        >
          Kayıt Ol
          <v-icon
            icon="mdi-account-plus"
            end
          ></v-icon>
        </v-btn>
        </template>

        <v-btn icon="mdi-dots-vertical" variant="text"></v-btn>
      </v-app-bar>

      <v-navigation-drawer
        v-model="drawer"
        :location="$vuetify.display.mobile ? 'left' : undefined"
        temporary
      >

        <v-list
          density="compact"
          nav
        >
          <v-list-item title="D-TIX" subtitle="Keyifli Seyirler Dileriz."></v-list-item>
          <v-list-item prepend-icon="mdi-view-dashboard" title="Ana Sayfa" value="home"></v-list-item>



          <v-list-group value="Categories">
          <template v-slot:activator="{ props }">
            <v-list-item
              v-bind="props"
              title="Kategoriler"
              prepend-icon="mdi-animation"
            ></v-list-item>
          </template>

          <v-list-item
            prepend-icon="mdi-drama-masks"
            title="Komedi"
            value="title"
          ></v-list-item>

          <v-list-item
            prepend-icon="mdi-alert-circle"
            title="Korku"
            value="title"
          ></v-list-item>

          <v-list-item
            prepend-icon="mdi-car-traction-control"
            title="Aksiyon"
            value="title"
          ></v-list-item>

          <v-list-item
            prepend-icon="mdi-drama-masks"
            title="Drama"
            value="title"
          ></v-list-item>

        </v-list-group>


   

        <v-list-item prepend-icon="mdi-view-dashboard" title="Haftanın Yenileri" value="home"></v-list-item>
      



        </v-list>
      

        <template v-slot:append>
          <v-list>  
          <v-list-item prepend-icon="mdi-view-dashboard" title="Rezervasyonlarım" value="home"></v-list-item>
          <v-list-item prepend-icon="mdi-forum" title="Hakkımızda" value="about"></v-list-item>
          <div class="pa-2">
            <v-btn block class="mb-4 custom-button">
              Çıkış Yap
              <v-icon
                icon="mdi-exit-to-app"
                end
              ></v-icon>
            </v-btn>
          </div>
        </v-list>
        </template>
      </v-navigation-drawer>
    </v-layout>
</template>

<script  lang="ts">
import { defineComponent } from 'vue';
import Base from '@/Base.vue';
export default defineComponent({

  name: "NavigationDrawer",
  extends: Base,


  data: () => ({
      drawer: false,
      group: null,
    }),

    watch: {
      group () {
        this.drawer = false
      },
    },

})
</script>

<style scoped>
.custom-link {
  font-size: 1.2rem; /* Normalden biraz daha büyük */
  color: #ffffff; /* Beyaz ya da istediğiniz bir renk */
  text-decoration: none; /* Alt çizgiyi kaldırır */
  transition: all 0.3s ease; /* Geçiş efektleri için yumuşak bir animasyon */
}

.custom-link:hover {
  text-shadow: 0px 0px 8px rgba(255, 255, 255, 0.8); /* Beyaz bir gölge efekti */
  color: #ffffff; /* Rengin hover durumunda değişmemesi için */
  background-color: unset;
}

.custom-button{
  font-size: 1.2rem;
}
</style>