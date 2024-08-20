<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavigationDrawer from './components/NavigationDrawer.vue';
import FooterDrawer from './components/FooterDrawer.vue';

</script>

<template>
  <NavigationDrawer/>
  <RouterView />
  <FooterDrawer/>
</template>

