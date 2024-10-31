import { Component, Vue, Prop } from 'vue-property-decorator';


@Component
export default class TheaterSeat extends Vue {
  @Prop() seatNumber!: string;

  choose(){
    this.$toast.success("Seçildi.");
  }
}