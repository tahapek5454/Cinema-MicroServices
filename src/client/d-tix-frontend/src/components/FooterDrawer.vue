<template>
  <v-footer>
    <div class="footer-content">
      <v-row>
        <v-col cols="3" class="d-flex flex-column align-start">
          <h2>D-TIX</h2>
          <br></br>
          <div>
            <a href="https://twitter.com/yourprofile" target="_blank">
            <v-icon class="icon">mdi-twitter</v-icon> 
            </a>
            <a href="https://instagram.com/yourprofile" target="_blank">
              <v-icon class="icon">mdi-instagram</v-icon>
            </a>
            <a href="https://youtube.com/yourchannel" target="_blank">
              <v-icon class="icon">mdi-youtube</v-icon> 
            </a>
            <a href="https://linkedin.com/in/yourprofile" target="_blank">
              <v-icon class="icon">mdi-linkedin</v-icon> 
            </a>
          </div>
        </v-col>
        <v-col cols="3" class="d-flex flex-column align-start">
          <h3>Vizyonda</h3>
          <v-list>
            <v-list-item-group v-if="filmsCurrentlyShowing.length">
              <v-list-item v-for="item in filmsCurrentlyShowing" :key="item">
                <v-list-item-content>
                  <v-list-item-title>{{ item }}</v-list-item-title>
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
            <v-list-item v-else>No data available</v-list-item>
          </v-list>
        </v-col>
        <v-col cols="3" class="d-flex flex-column align-start">
          <h3>Yakında</h3>
          <v-list>
            <v-list-item-group v-if="upcomingMovies.length">
              <v-list-item v-for="item in upcomingMovies" :key="item">
                <v-list-item-content>
                  <v-list-item-title>{{ item }}</v-list-item-title>
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
            <v-list-item v-else>No data available</v-list-item>
          </v-list>        
        </v-col>
        <v-col cols="3" class="d-flex flex-column align-start">
          <h3>Kurumsal</h3>
          <v-btn
            v-for="link in corporate"
            :key="link"
            class="my-1"
            color="white"
            rounded="xl"
            variant="text"
          >
            {{ link }}
          </v-btn>
        </v-col>
      </v-row>
    </div>
    <div class="footer-image">
      <img src="/footer_image.png" alt="Footer Image" />
    </div>
  </v-footer>
</template>
  
<script  lang="ts">
import { defineComponent } from 'vue';
import Base from '@/Base.vue';
export default defineComponent({

  name: "FooterDrawer",
  extends: Base,
  data: () => ({
  links: [
    'Home'
  ],
  filmsCurrentlyShowing: [
    'Ters Yüz',
    'Kral Şakir',
    'Küçük Denizkızı Ponyo'
  ],
  upcomingMovies: [
    'Spirited Away',
    'My Neighbor Totoro',
    'Howl\'s Moving Castle'        
  ],
  corporate:[
    'Hakkımızda',
    'İnsan Kaynakları',
    'Özel Etkinlikler',
    'Toplu Bilet Satışı',
  ]
})

});
</script>

  
<style scoped>
footer {
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
  background: #0c0c0c;
  padding: 0;
  margin: 0;
  height: 250px; /* Footer yüksekliğini 90px olarak ayarla */
  border-top-width: 8px;
  border-color: #440101;
}
.footer-content {
  justify-content: center;
  width: 100%;
  height: 220px; /* Footer içeriğini yüksekliğe göre ortala */
  padding: 0; /* İçerik etrafında biraz boşluk bırak */
  margin: 0;
  bottom: 0;
}
.footer-image {
  width: 100%; 
  background-color: #0c0c0c;
  margin: 0;
  padding: 0;
  bottom: 0;
  position: fixed;
}
.footer-image img {
  width: 100%; 
  height: 50px;
  max-height: 50px;
  margin: 0;
  padding: 0;
  bottom: 0;
  position: fixed;

}
.icon {
  font-size: 18px; /* İkon boyutu */
  color: white; /* İkon rengi */
  transition: color 0.3s; /* Hover efekti için geçiş */
}
</style>


  