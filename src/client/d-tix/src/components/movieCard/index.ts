import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class MovieCard extends Vue {
  @Prop() path!: string;
  @Prop({ default: false }) isDetail!: boolean;

  goToDetail(){
    this.$router.push({path:'/movieDetail'});
  }
}