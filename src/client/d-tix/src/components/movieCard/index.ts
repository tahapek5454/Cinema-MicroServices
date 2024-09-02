import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class MovieCard extends Vue {
  @Prop() path!: string;

  w:string = '/movieCardImages/dw.jpg'
}