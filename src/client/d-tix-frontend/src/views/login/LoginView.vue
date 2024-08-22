
<template>
  <v-container class="d-flex justify-center align-center" style="height: 100vh; margin-right: 700px;">
    <v-card class="login-panel" outlined rounded>
      <v-card-title class="d-flex justify-center align-center"> 
        <img src="../../assets/img/resim.png" alt="" style="height: 64px; width: 64px;">
      </v-card-title>
      <v-card-text>
        <v-form>
          <v-text-field
            v-model="username"
            label="Telefon Numarası/E-mail Adresi"
            outlined
            dense
            hide-details
            color="white"
          ></v-text-field>

          <v-text-field
            v-model="password"
            label="Şifre"
            type="password"
            outlined
            dense
            hide-details
            color="white"
          ></v-text-field>

          <v-btn
            class="mt-4"
            color="#440101"
            block
            @click="login"
          >
            Giriş Yap
          </v-btn>
        </v-form>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      password: '',
    };
  },
  methods: {
    login() {
      // Handle login logic here
      console.log('Username:', this.username);
      console.log('Password:', this.password);
    },
  },
};
</script>

<style scoped>
.login-panel {
  background-color: black;
  border-color: #440101;
  border-width: 5px;
  width: 500px;
  height: 400px;
}

.v-text-field {
  border-radius: 100px;
}

.v-text-field input {
  color: white !important;
}

.v-text-field label {
  color: white !important;
}

.v-text-field .v-input__control .v-input__slot {
  background-color: #c08a8a !important;
}
</style>
