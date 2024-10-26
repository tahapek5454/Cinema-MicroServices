import Vue from 'vue';



export default abstract class Base extends Vue {
  abstract created(): void;
  abstract mounted(): void;
  abstract destroyed():  void;

  showLoading() {
    this.$root.$emit("spinner", true);
  }

  hideLoading(){
    this.$root.$emit("spinner", false);
  }
}
